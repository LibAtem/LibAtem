using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using LibAtem.Commands;
using Xunit;
using Xunit.Abstractions;

namespace LibAtem.Test.Commands
{
    public class TestCommandIdAttribute
    {
        private readonly ITestOutputHelper output;

        public TestCommandIdAttribute(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void TestAllCommandsHaveAttributes()
        {
            var missingAttribute = new List<string>();
            var hasBoth = new List<string>();

            TypeInfo baseTypeInfo = typeof(ICommand).GetTypeInfo();
            IEnumerable<Type> types = baseTypeInfo.Assembly.GetTypes().Where(t => baseTypeInfo.IsAssignableFrom((Type) t));
            foreach (Type type in types)
            {
                TypeInfo typeInfo = type.GetTypeInfo();
                if (typeInfo.IsInterface || typeInfo.IsAbstract)
                    continue;

                bool hasNoCmdAttribute = typeInfo.GetCustomAttributes<NoCommandIdAttribute>().Any();

                bool hasCmdAttributes = typeInfo.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                    .Any(prop => prop.GetCustomAttributes<CommandIdAttribute>().Any());

                if (hasNoCmdAttribute && hasCmdAttributes)
                    hasBoth.Add(type.Name);
                if (!hasNoCmdAttribute && !hasCmdAttributes)
                    missingAttribute.Add(type.Name);
            }

            if (missingAttribute.Any())
            {
                output.WriteLine("\nMissing attributes: ");
                output.WriteLine(string.Join("\n", missingAttribute));
                Assert.Equal(0, missingAttribute.Count);
            }
            if (hasBoth.Any())
            {
                output.WriteLine("\nHas both attributes: ");
                output.WriteLine(string.Join("\n", hasBoth));
                Assert.Equal(0, hasBoth.Count);
            }
        }
    }
}