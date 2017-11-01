using LibAtem.MacroOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using LibAtem.Test.Util;
using Xunit;
using Xunit.Abstractions;
using LibAtem.Commands;

namespace LibAtem.Test.MacroOp
{
    public class TestConvertToFromCommand
    {
        private readonly ITestOutputHelper output;

        public TestConvertToFromCommand(ITestOutputHelper output)
        {
            this.output = output;
        }

        private readonly IReadOnlyList<Type> expectedNullCommand = new List<Type>() {typeof(MacroSleepMacroOp)};

        [Fact]
        public void TestStartingWithMacroOperation()
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
                    TestStartingWithMacroOperationSingle(type, 10);
                }
                catch (Exception e)
                {
                    failures.Add(string.Format("{0}: {1}", type.Name, e.Message));
                }
            }

            output.WriteLine(string.Join("\n", failures));
            Assert.Empty(failures);
        }

        private void TestStartingWithMacroOperationSingle(Type t, int rounds)
        {
            for (int i = 0; i < rounds; i++)
            {
                MacroOpBase raw = (MacroOpBase)RandomPropertyGenerator.Create(t);

                ICommand cmd = raw.ToCommand();
                bool nullCommand = cmd == null;
                bool shouldBeNull = expectedNullCommand.Contains(t);
                //Assert.Equal(shouldBeNull, nullCommand); // TODO - reenable this once possible
                if (shouldBeNull || nullCommand)
                    continue;

                var serCmd = cmd as SerializableCommandBase; // TODO - this shouldnt be needed once all Commands have appropriate macro stuff set
                Assert.NotNull(serCmd);

                MacroOpBase entry = serCmd.ToMacroOps().Single();
                if (!t.GetTypeInfo().IsAssignableFrom(entry.GetType()))
                    throw new Exception("Deserialized operation of wrong type");

                RandomPropertyGenerator.AssertAreTheSame(raw, entry);
            }
        }
    }
}