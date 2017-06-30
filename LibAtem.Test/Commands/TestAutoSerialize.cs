using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using LibAtem.Commands;
using LibAtem.Test.Util;
using Xunit;

namespace LibAtem.Test.Commands
{
    public class TestAutoSerialize
    {
        private static readonly Type[] SkipTypes =
        {
        };

//        [Fact]
//        public void TestCommandSerialization()
//        {
//            Assembly assembly = typeof(ICommand).GetTypeInfo().Assembly;
//            IEnumerable<Type> types = assembly.GetTypes().Where(t => typeof(ICommand).GetTypeInfo().IsAssignableFrom(t))
//                .Where(t => !SkipTypes.Contains(t));
//
//            var failures = new StringBuilder();
//
//            foreach (Type type in types)
//            {
//                if (type == typeof(ICommand))
//                    continue;
//                try
//                {
//                    ICommand cmd = (ICommand)Activator.CreateInstance(type);
//                    Assert.NotNull(cmd);
//
//                    byte[] byteArray = cmd.ToByteArray();
//                    if (byteArray.Length % 2 != 0)
//                        throw new Exception("Expected command length to be an even number");
//
//                    var cmd2 = DeserializeSingle(byteArray);
//
//                    // TODO assert contents matches!
//                }
//                catch (Exception e)
//                {
//                    failures.AppendFormat("{0}: {1}\n", type.Name, e.Message);
//                }
//            }
//
//            string str = failures.ToString();
//            Console.Error.WriteLine(str);
//            Assert.Equal("", str);
//        }

        [Fact]
        public void TestAutoPropertySerialization()
        {
            Assembly assembly = typeof(ICommand).GetTypeInfo().Assembly;
            IEnumerable<Type> types = assembly.GetTypes().Where(t => typeof(SerializableCommandBase).GetTypeInfo().IsAssignableFrom(t));
            foreach (Type type in types)
            {
                if (type == typeof(SerializableCommandBase))
                    continue;

                Console.WriteLine("Testing: {0}", type.Name);
                TestSingle(type, 10);
            }
        }

        private static void TestSingle(Type t, int rounds)
        {
            for (int i = 0; i < rounds; i++)
            {
                ICommand raw = RandomCommandGenerator.Create(t);
                ICommand cmd = DeserializeSingle(raw.ToByteArray());
                Assert.NotNull(cmd);
                Assert.True(t.GetTypeInfo().IsAssignableFrom(cmd.GetType()), "Deserialized command of wrong type");

                RandomCommandGenerator.AssertAreTheSame(raw, cmd);
            }
        }
        
        private static ICommand DeserializeSingle(byte[] arr)
        {
            Assert.True(arr.Length > 8);

            int cmdLength = (arr[0] << 8) | arr[1];
            Assert.False(arr.Length < cmdLength || cmdLength == 0);

            byte[] cmdBody = new byte[cmdLength - 8];
            Array.Copy(arr, 8, cmdBody, 0, cmdLength - 8);

            string name = Encoding.ASCII.GetString(arr, 4, 4);
            var parsed = new ParsedCommand(arr[2], arr[3], name, cmdBody);

            Type type = CommandManager.FindForName(name);
            Assert.NotNull(type);

            ICommand cmd = (ICommand)Activator.CreateInstance(type);
            Assert.NotNull(cmd);
            cmd.Deserialize(parsed);

            return cmd;
        }
    }
}
