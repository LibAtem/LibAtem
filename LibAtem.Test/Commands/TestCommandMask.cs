using LibAtem.Commands;
using LibAtem.Commands.MixEffects.Key;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;

namespace LibAtem.Test.Commands
{
    public class TestCommandMask
    {
        private readonly ITestOutputHelper output;

        public TestCommandMask(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void TestHasMatchingProperties()
        {
            var errors = new List<string>();

            TypeInfo baseTypeInfo = typeof(ICommand).GetTypeInfo();
            IEnumerable<Type> types = baseTypeInfo.Assembly.GetTypes().Where(t => baseTypeInfo.IsAssignableFrom(t));
            foreach (Type type in types)
            {
                TypeInfo typeInfo = type.GetTypeInfo();
                if (typeInfo.IsInterface || typeInfo.IsAbstract)
                    continue;

                PropertyInfo maskProp = typeInfo.GetProperty("Mask");
                if (maskProp == null || maskProp.PropertyType == typeof(uint))
                    continue;

                var maskItems = new List<string>();
                foreach (var i in Enum.GetValues(maskProp.PropertyType))
                    maskItems.Add(i.ToString());

                var propsList = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                    .Where(p => !p.GetCustomAttributes<CommandIdAttribute>().Any())
                    .Select(p => p.Name)
                    .Except(new[] { "Mask" })
                    .ToList();
                
                foreach (var flag in maskItems.Except(propsList))
                    errors.Add(string.Format("Unmatched flag {0}.{1}", type.FullName, flag));
                foreach (var prop in propsList.Except(maskItems))
                    errors.Add(string.Format("Unexpected property {0}.{1}", type.FullName, prop));
            }

            errors.ForEach(output.WriteLine);
            Assert.Empty(errors);
        }
    }
}