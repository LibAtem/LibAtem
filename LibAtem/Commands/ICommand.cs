using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using log4net;
using LibAtem.Serialization;

namespace LibAtem.Commands
{
    public interface ICommand
    {
        void Serialize(ByteArrayBuilder cmd);

        void Deserialize(ParsedByteArray cmd);

        // IEnumerable<MacroOpBase> ToMacroOps(); // TODO - enable this once it is safe to do so
    }

    public class CommandNameAttribute : LengthAttribute
    {
        public CommandNameAttribute(string name, int length = -1) : base(length)
        {
            Name = name;
        }

        public string Name { get; }

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
            var builder = new CommandBuilder(CommandManager.FindNameForType(cmd));
            cmd.Serialize(builder);
            return builder.ToByteArray();
        }
    }

    public static class CommandManager
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(CommandManager));

        private static IReadOnlyDictionary<string, Type> commandTypes;
        private static IReadOnlyDictionary<Type, string> commandNames;

        private static void GenerateDictionaries()
        {
            try
            {
                var resultTypes = new Dictionary<string, Type>();
                var resultNames = new Dictionary<Type, string>();
                var assembly = typeof(CommandNameAttribute).GetTypeInfo().Assembly;
                foreach (Type type in assembly.GetTypes())
                {
                    CommandNameAttribute attribute = type.GetTypeInfo().GetCustomAttributes(typeof(CommandNameAttribute), true).OfType<CommandNameAttribute>().FirstOrDefault();
                    if (attribute == null)
                        continue;

                    if (!typeof(ICommand).GetTypeInfo().IsAssignableFrom(type.GetTypeInfo()))
                        continue;

                    if (resultTypes.ContainsKey(attribute.Name))
                        Log.FatalFormat("Duplicate definition for {0}", attribute.Name);

                    resultTypes[attribute.Name] = type;
                    resultNames[type] = attribute.Name;
                }

                commandTypes = resultTypes;
                commandNames = resultNames;
            }
            catch (Exception e)
            {
                Log.FatalFormat("Failed to find all valid command types: {0}", e.Message);
                throw;
            }
        }

        public static IReadOnlyDictionary<string, Type> GetAllTypes()
        {
            if (commandTypes == null)
                GenerateDictionaries();

            return commandTypes;
        }

        public static IReadOnlyDictionary<Type, string> GetAllNames()
        {
            if (commandNames == null)
                GenerateDictionaries();

            return commandNames;
        }

        public static Type FindForName(string name)
        {
            return GetAllTypes().TryGetValue(name, out Type res) ? res : null;
        }

        public static string FindNameForType(ICommand cmd)
        {
            return GetAllNames().TryGetValue(cmd.GetType(), out string res) ? res : null;
        }
    }
}
