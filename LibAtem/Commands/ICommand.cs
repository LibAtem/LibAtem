using LibAtem.MacroOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using log4net;

namespace LibAtem.Commands
{
    public interface ICommand
    {
        void Serialize(ByteArrayBuilder cmd);

        void Deserialize(ParsedByteArray cmd);

        // IEnumerable<MacroOpBase> ToMacroOps(); // TODO - enable this once it is safe to do so
    }

    public class CommandNameAttribute : Attribute
    {
        public CommandNameAttribute(string name, int length=-1)
        {
            Name = name;
            Length = length;
        }

        public string Name { get; }
        public int Length { get; }

        public static string GetName(Type type)
        {
            CommandNameAttribute attribute = type.GetTypeInfo().GetCustomAttributes(typeof(CommandNameAttribute), true).OfType<CommandNameAttribute>().FirstOrDefault();
            if (attribute == null)
                throw new Exception(string.Format("Missing CommandNameAttribute on type: {0}", type.Name));

            return attribute.Name;
        }
    }

    public class CommandIdAttribute : Attribute
    {
        public static IEnumerable<PropertyInfo> GetProperties(Type type)
        {
            return type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(prop => prop.GetCustomAttributes<CommandIdAttribute>().Any());
        }
    }

    public class NoCommandIdAttribute : Attribute
    {
    }

    public static class CommandExtensions
    {
        public static byte[] ToByteArray(this ICommand cmd)
        {
            var builder = new CommandBuilder(CommandNameAttribute.GetName(cmd.GetType()));
            cmd.Serialize(builder);
            return builder.ToByteArray();
        }
    }

    public static class CommandManager
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(CommandManager));

        private static IReadOnlyDictionary<string, Type> commandTypes;

        private static Dictionary<string, Type> FindAllTypes()
        {
            try
            {
                var result = new Dictionary<string, Type>();
                var assembly = typeof(CommandNameAttribute).GetTypeInfo().Assembly;
                foreach (Type type in assembly.GetTypes())
                {
                    CommandNameAttribute attribute = type.GetTypeInfo().GetCustomAttributes(typeof(CommandNameAttribute), true).OfType<CommandNameAttribute>().FirstOrDefault();
                    if (attribute == null)
                        continue;

                    if (!typeof(ICommand).GetTypeInfo().IsAssignableFrom(type.GetTypeInfo()))
                        continue;

                    if (result.ContainsKey(attribute.Name))
                        Log.FatalFormat("Duplicate definition for {0}", attribute.Name);

                    result[attribute.Name] = type;
                }

                return result;
            }
            catch (Exception e)
            {
                Log.FatalFormat("Failed to find all valid command types: {0}", e.Message);
                throw;
            }
        }

        public static Type FindForName(string name)
        {
            if (commandTypes == null)
                commandTypes = FindAllTypes();

            Type res;
            return commandTypes.TryGetValue(name, out res) ? res : null;
        }
    }
}
