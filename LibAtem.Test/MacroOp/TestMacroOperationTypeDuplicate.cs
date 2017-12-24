using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using LibAtem.Common;
using LibAtem.MacroOperations;
using Xunit;
using Xunit.Abstractions;

namespace LibAtem.Test.MacroOp
{
    public class TestMacroOperationTypeDuplicate
    {
        private readonly ITestOutputHelper output;

        public TestMacroOperationTypeDuplicate(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void TestValuesAreUnique()
        {
            IEnumerable<IGrouping<int, string>> groups = Enum.GetNames(typeof(MacroOperationType)).GroupBy(v => (int) Enum.Parse<MacroOperationType>(v)).Where(g => g.Count() > 1);

            var failures = new List<string>();

            foreach (IGrouping<int, string> group in groups)
            {
                string names = string.Join(", ", group);
                failures.Add(string.Format("{0:X}: {1}", (int) Enum.Parse<MacroOperationType>(group.First()), names));
            }
            
            output.WriteLine(string.Join("\n", failures));
            Assert.Empty(failures);
        }
    }
}