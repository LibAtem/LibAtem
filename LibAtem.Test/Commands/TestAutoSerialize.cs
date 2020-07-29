using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using LibAtem.Commands;
using LibAtem.Commands.CameraControl;
using LibAtem.Test.Util;
using Xunit;
using Xunit.Abstractions;

namespace LibAtem.Test.Commands
{
    public class TestAutoSerialize
    {
        private readonly ITestOutputHelper output;

        public TestAutoSerialize(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void TestAutoPropertySerialization()
        {
            var failures = new List<string>();

            Assembly assembly = typeof(ICommand).GetTypeInfo().Assembly;
            IEnumerable<Type> types = assembly.GetTypes().Where(t => typeof(SerializableCommandBase).GetTypeInfo().IsAssignableFrom(t));
            foreach (Type type in types)
            {
                if (type == typeof(SerializableCommandBase))
                    continue;

                if (type != typeof(CameraControlDeviceOptionsSetCommand))
                    continue;

                try
                {
                    // output.WriteLine("Testing: {0}", type.Name);
                    TestSingle(type, 10);
                }
                catch (Exception e)
                {
                    failures.Add(string.Format("{0}: {1}", type.Name, e.Message));
                    if (Debugger.IsAttached)
                    {
                        //the debugger no longer breaks here
                        throw;
                    }
                }
            }

            output.WriteLine(string.Join("\n", failures));
            Assert.Empty(failures);
        }

        private static void TestSingle(Type t, int rounds)
        {
            for (int i = 0; i < rounds; i++)
            {
                ICommand raw = (ICommand)RandomPropertyGenerator.Create(t);
                var nameAndVersion = CommandManager.FindNameAndVersionForType(raw);
                ICommand cmd = DeserializeSingle(nameAndVersion.Item2, raw.ToByteArray());
                if (!t.GetTypeInfo().IsAssignableFrom(cmd.GetType()))
                    throw new Exception("Deserialized command of wrong type");

                RandomPropertyGenerator.AssertAreTheSame(raw, cmd);
            }
        }

        private static ICommand DeserializeSingle(ProtocolVersion version, byte[] arr)
        {
            Assert.True(ParsedCommand.ReadNextCommand(arr, 0, out ParsedCommandSpec? parsed));
            Assert.NotNull(parsed);

            Type type = CommandManager.FindForName(parsed.Value.Name, version);
            if (type == null)
                throw new Exception("Failed to find command during deserialize");

            ICommand cmd = (ICommand)Activator.CreateInstance(type);
            if (cmd == null)
                throw new Exception("Failed to construct command");

            ParsedCommand parsed2 = new ParsedCommand(parsed.Value);
            cmd.Deserialize(parsed2);
            return cmd;
        }
    }
}
