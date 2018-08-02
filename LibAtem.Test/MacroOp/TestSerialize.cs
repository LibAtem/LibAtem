using LibAtem.MacroOperations;
using LibAtem.Test.Util;
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

            Assembly assembly = typeof(MacroOpBase).GetTypeInfo().Assembly;
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
                    failures.Add(e.StackTrace);
                    failures.Add(string.Format("{0}: {1}", type.Name, e.Message));
                }
            }

            output.WriteLine(string.Join("\n", failures));
            Assert.Empty(failures);
        }

        private static void TestSingle(Type t, int rounds)
        {
            for (int i = 0; i < rounds; i++)
            {
                MacroOpBase raw = (MacroOpBase) RandomPropertyGenerator.Create(t);
                MacroOpBase cmd = DeserializeSingle(raw.ToByteArray());
                if (!t.GetTypeInfo().IsInstanceOfType(cmd))
                    throw new Exception("Deserialized operation of wrong type");

                RandomPropertyGenerator.AssertAreTheSame(raw, cmd);
            }
        }

        private static MacroOpBase DeserializeSingle(byte[] arr)
        {
            Assert.True(arr.Length >= 4);

            int cmdLength = arr[0];
            Assert.False(arr.Length != cmdLength || cmdLength == 0);

            return MacroOpManager.CreateFromData(arr, false);
        }
    }
}
