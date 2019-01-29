using System;
using System.Reflection;
using LibAtem.Common;
using LibAtem.Serialization;
using LibAtem.Commands;
using System.Collections.Generic;
using System.Linq;
using LibAtem.Util;
using log4net;

namespace LibAtem.MacroOperations
{
    public static class MacroOpExtensions
    {
        public static byte[] ToByteArray(this MacroOpBase cmd)
        {
            var builder = new ByteArrayBuilder(false);
            cmd.Serialize(builder);
            return builder.ToByteArray();
        }
    }

    public interface IMacroOp
    {
        uint Length { get; }

        MacroOperationType Id { get; }
    }

    public abstract class MacroOpBase : AutoSerializeBase, IMacroOp
    {
        [Serialize(0), UInt8]
        public uint Length => (uint) GetAttribute().Length;

        [Serialize(2), Enum16]
        public MacroOperationType Id => GetAttribute().Operation;

        // TODO cache this!
        private MacroOperationAttribute GetAttribute() => GetType().GetTypeInfo().GetCustomAttribute<MacroOperationAttribute>();

        public abstract ICommand ToCommand();
    }

    public class MacroOperationAttribute : LengthAttribute
    {
        public MacroOperationType Operation { get; }

        public MacroOperationAttribute(MacroOperationType op, int length) : base(length)
        {
            Operation = op;
        }
    }

    public class NoMacroFieldsAttribute : Attribute
    {
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
        private static readonly ILog Log = LogManager.GetLogger(typeof(MacroOpManager));

        private static IReadOnlyDictionary<MacroOperationType, Type> macroOpTypes;

        private static IReadOnlyDictionary<MacroOperationType, Type> FindAllTypes()
        {
            var result = new Dictionary<MacroOperationType, Type>();
            var assembly = typeof(MacroOperationAttribute).GetTypeInfo().Assembly;
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

            return macroOpTypes.TryGetValue(opId, out Type res) ? res : null;
        }

        public static IReadOnlyDictionary<MacroOperationType, Type> FindAll()
        {
            return macroOpTypes ?? (macroOpTypes = FindAllTypes());
        }

        public static MacroOpBase CreateFromData(byte[] arr, bool safe)
        {
            int opId = (arr[3] << 8) | arr[2];
            MacroOperationType macroOp = (MacroOperationType)opId;
            try
            {
                if (!macroOp.IsValid())
                    throw new SerializationException("FTDa", "Invalid MacroOperationType: {0}", opId);
                
                var parsed = new ParsedByteArray(arr, false);

                Type type = FindForType(macroOp);
                if (type == null)
                    throw new SerializationException("FTDa", "Failed to find MacroOperationType: {0}", macroOp);

                MacroOpBase cmd = (MacroOpBase)Activator.CreateInstance(type);

                if (!safe)
                {
                    cmd.Deserialize(parsed);
                }
                else
                {
                    AutoSerializeBase.CommandPropertySpec info = AutoSerializeBase.GetPropertySpecForType(cmd.GetType());

                    int attrLength = info.Length;
                    if (attrLength != -1 && attrLength != parsed.BodyLength)
                        Log.WarnFormat("{0}: Auto deserialize length mismatch", cmd.GetType().Name);
                    
                    foreach (AutoSerializeBase.PropertySpec prop in info.Properties)
                    {
                        try
                        {
                            prop.Setter?.DynamicInvoke(cmd, prop.SerAttr.Deserialize(parsed.ReverseBytes, parsed.Body, prop.Attr.StartByte, prop.PropInfo));
                        }
                        catch (Exception e)
                        {
                            Log.WarnFormat("{0}: Failed to deserialize property {1}: {2}", cmd.GetType().Name, prop.PropInfo.Name, e.ToString());
                        }
                    }

                }

                return cmd;
            }
            catch (Exception)
            {
                if (safe)
                    return null;

                throw;
            }
        }
    }
}
