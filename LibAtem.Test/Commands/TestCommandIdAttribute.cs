using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            IEnumerable<Type> types = baseTypeInfo.Assembly.GetTypes().Where(t => baseTypeInfo.IsAssignableFrom(t));
            foreach (Type type in types)
            {
                TypeInfo typeInfo = type.GetTypeInfo();
                if (typeInfo.IsInterface || typeInfo.IsAbstract)
                    continue;

                bool hasNoCmdAttribute = typeInfo.GetCustomAttributes<NoCommandIdAttribute>().Any();

                bool hasCmdAttributes = CommandIdAttribute.GetProperties(type).Any();

                if (hasNoCmdAttribute && hasCmdAttributes)
                    hasBoth.Add(type.Name);
                if (!hasNoCmdAttribute && !hasCmdAttributes)
                    missingAttribute.Add(type.Name);
            }

            if (missingAttribute.Any())
            {
                output.WriteLine("\nMissing attributes: ");
                output.WriteLine(string.Join("\n", missingAttribute));
                Assert.Empty(missingAttribute);
            }
            if (hasBoth.Any())
            {
                output.WriteLine("\nHas both attributes: ");
                output.WriteLine(string.Join("\n", hasBoth));
                Assert.Empty(hasBoth);
            }
        }

        [Fact]
        public void TestAllCommandIdAttributeTypes()
        {
            var badTypes = new List<string>();

            TypeInfo baseTypeInfo = typeof(ICommand).GetTypeInfo();
            IEnumerable<Type> types = baseTypeInfo.Assembly.GetTypes().Where(t => baseTypeInfo.IsAssignableFrom(t));
            foreach (Type type in types)
            {
                TypeInfo typeInfo = type.GetTypeInfo();
                if (typeInfo.IsInterface || typeInfo.IsAbstract)
                    continue;

                IEnumerable<PropertyInfo> props = CommandIdAttribute.GetProperties(type);
                foreach (PropertyInfo prop in props)
                {
                    Type propType = prop.PropertyType;
                   
                    
                    bool isValid = typeof(uint) == propType || propType.GetTypeInfo().IsEnum;
                    if (!isValid)
                        badTypes.Add(string.Format("{0}: {1} has invalid type {2}", type.Name, prop.Name, propType.Name));
                }
            }

            if (badTypes.Any())
            {
                output.WriteLine("Bad types: ");
                output.WriteLine(string.Join("\n", badTypes));
                Assert.Empty(badTypes);
            }
        }
    }
}