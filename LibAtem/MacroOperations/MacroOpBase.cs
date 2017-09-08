using System;
using System.Reflection;
using LibAtem.Common;
using LibAtem.Serialization;
using LibAtem.Commands;
using System.Collections.Generic;
using System.Linq;

namespace LibAtem.MacroOperations
{
    public interface IMacroOperation
    {
        ICommand ToCommand();
    }

    public static class MacroOpExtensions
    {
        public static byte[] ToByteArray(this MacroOpBase cmd)
        {
            var builder = new ByteArrayBuilder();
            cmd.Serialize(builder);
            return builder.ToByteArray();
        }
    }

    public abstract class MacroOpBase : AutoSerializeBase, IMacroOperation
    {
        [Serialize(0), Int16]
        public int Length => GetLengthFromAttribute();

        [Serialize(2), Enum16]
        public MacroOperationType Id => GetAttribute().Operation;

        protected override int GetLengthFromAttribute() => GetAttribute().Length;

        private MacroOperationAttribute GetAttribute() => GetType().GetTypeInfo().GetCustomAttribute<MacroOperationAttribute>();

        public abstract ICommand ToCommand();
    }

    public class MacroOperationAttribute : Attribute
    {
        public MacroOperationType Operation { get; }
        public int Length { get; }

        public MacroOperationAttribute(MacroOperationType op, int length)
        {
            Operation = op;
            Length = length;
        }
    }

    public class MacroFieldAttribute : Attribute
    {
        public string Id { get; }
        public string Name { get; }

        public MacroFieldAttribute(string name, string id = null)
        {
            Id = id ?? char.ToLower(name[0]).ToString() + name.Substring(1);
            Name = name;
        }
    }

    public static class MacroOpManager
    {
        private static IReadOnlyDictionary<MacroOperationType, Type> macroOpTypes;

        private static IReadOnlyDictionary<MacroOperationType, Type> FindAllTypes()
        {
            var result = new Dictionary<MacroOperationType, Type>();
            var assembly = typeof(CommandNameAttribute).GetTypeInfo().Assembly;
            foreach (Type type in assembly.GetTypes())
            {
                if (!typeof(MacroOpBase).GetTypeInfo().IsAssignableFrom(type.GetTypeInfo()))
                    continue;

                MacroOperationAttribute attribute = type.GetTypeInfo().GetCustomAttributes<MacroOperationAttribute>().FirstOrDefault();
                if (attribute == null)
                    continue;
                
                result.Add(attribute.Operation, type);
            }

            return result;
        }

        public static Type FindForType(MacroOperationType opId)
        {
            if (macroOpTypes == null)
                macroOpTypes = FindAllTypes();

            Type res;
            return macroOpTypes.TryGetValue(opId, out res) ? res : null;
        }

        public static IReadOnlyDictionary<MacroOperationType, Type> FindAll()
        {
            if (macroOpTypes == null)
                macroOpTypes = FindAllTypes();

            return macroOpTypes;
        }
    }
}
