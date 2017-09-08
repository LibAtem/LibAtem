using LibAtem.Common;
using LibAtem.MacroOperations;
using LibAtem.Test.Util;
using LibAtem.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;

namespace LibAtem.Test.MacroOp
{
    public class TestSerialize
    {
        private readonly ITestOutputHelper output;

        public TestSerialize(ITestOutputHelper output)
        {
            this.output = output;
        }
        
        [Fact]
        public void TestAutoPropertySerialization()
        {
            var failures = new List<string>();

            Assembly assembly = typeof(IMacroOperation).GetTypeInfo().Assembly;
            IEnumerable<Type> types = assembly.GetTypes().Where(t => typeof(MacroOpBase).GetTypeInfo().IsAssignableFrom(t));
            foreach (Type type in types)
            {
                if (type == typeof(MacroOpBase) || type.IsAbstract)
                    continue;

                try
                {
                    output.WriteLine("Testing: {0}", type.Name);
                    TestSingle(type, 10);
                }
                catch (Exception e)
                {
                    failures.Add(string.Format("{0}: {1}", type.Name, e.Message));
                }
            }

            output.WriteLine(string.Join("\n", failures));
            Assert.Equal(0, failures.Count);
        }

        private static void TestSingle(Type t, int rounds)
        {
            for (int i = 0; i < rounds; i++)
            {
                MacroOpBase raw = (MacroOpBase) RandomPropertyGenerator.Create(t);
                MacroOpBase cmd = DeserializeSingle(raw.ToByteArray());
                if (!t.GetTypeInfo().IsAssignableFrom(cmd.GetType()))
                    throw new Exception("Deserialized operation of wrong type");

                RandomPropertyGenerator.AssertAreTheSame(raw, cmd);
            }
        }

        private static MacroOpBase DeserializeSingle(byte[] arr)
        {
            Assert.True(arr.Length > 4);

            int cmdLength = (arr[0] << 8) | arr[1];
            Assert.False(arr.Length != cmdLength || cmdLength == 0);

            byte[] cmdBody = new byte[cmdLength - 8];

            int opId = (arr[2] << 8) | arr[3];
            MacroOperationType macroOp = (MacroOperationType) opId;
            Assert.True(macroOp.IsValid());

            var parsed = new ParsedByteArray(arr);

            Type type = MacroOpManager.FindForType(macroOp);
            if (type == null)
                throw new Exception("Failed to find macroop during deserialize");

            MacroOpBase cmd = (MacroOpBase)Activator.CreateInstance(type);
            if (cmd == null)
                throw new Exception("Failed to construct macroop");

            cmd.Deserialize(parsed);
            return cmd;
        }
    }
}
