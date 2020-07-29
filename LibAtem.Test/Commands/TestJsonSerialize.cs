using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using LibAtem.Commands;
using LibAtem.Test.Util;
using Xunit;
using Xunit.Abstractions;
using Newtonsoft.Json;

namespace LibAtem.Test.Commands
{
    public class TestJsonSerialize
    {
        private readonly ITestOutputHelper output;

        public TestJsonSerialize(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void TestJsonSerialization()
        {
            var failures = new List<string>();

            Assembly assembly = typeof(ICommand).GetTypeInfo().Assembly;
            IEnumerable<Type> types = assembly.GetTypes().Where(t => typeof(SerializableCommandBase).GetTypeInfo().IsAssignableFrom(t));
            foreach (Type type in types)
            {
                if (type == typeof(SerializableCommandBase))
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

                string jsonStr = JsonConvert.SerializeObject(raw);
                var cmd = (ICommand)JsonConvert.DeserializeObject(jsonStr, t);
                if (!t.GetTypeInfo().IsAssignableFrom(cmd.GetType()))
                    throw new Exception("Deserialized command of wrong type");
                
                Assert.Equal(BitConverter.ToString(raw.ToByteArray()), BitConverter.ToString(cmd.ToByteArray()));
            }
        }
    }
}
