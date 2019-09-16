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
        public CommandNameAttribute(string name, int length = -1) : this(name, ProtocolVersion.Minimum, length)
        {
        }
        public CommandNameAttribute(string name, ProtocolVersion minimumVersion, int length = -1) : base(length)
        {
            Name = name;
            MinimumVersion = minimumVersion;
        }

        public string Name { get; }

        public ProtocolVersion MinimumVersion { get; }

        public static Tuple<string, ProtocolVersion> GetNameAndVersion(Type type)
        {
            CommandNameAttribute attribute = type.GetTypeInfo().GetCustomAttributes(typeof(CommandNameAttribute), true).OfType<CommandNameAttribute>().FirstOrDefault();
            if (attribute == null)
                throw new Exception(string.Format("Missing CommandNameAttribute on type: {0}", type.Name));

            return Tuple.Create(attribute.Name, attribute.MinimumVersion);
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
            var builder = new CommandBuilder(CommandNameAttribute.GetNameAndVersion(cmd.GetType()).Item1);
            cmd.Serialize(builder);
            return builder.ToByteArray();
        }
    }

    public static class CommandManager
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(CommandManager));

        private static IReadOnlyDictionary<string, List<Tuple<ProtocolVersion, Type>>> commandTypes;
        private static IReadOnlyDictionary<Type, Tuple<string, ProtocolVersion>> commandNames;

        private static void GenerateDictionaries()
        {
            try
            {
                var resultTypes = new Dictionary<string, List<Tuple<ProtocolVersion, Type>>>();
                var resultNames = new Dictionary<Type, Tuple<string, ProtocolVersion>>();
                var assembly = typeof(CommandNameAttribute).GetTypeInfo().Assembly;
                foreach (Type type in assembly.GetTypes())
                {
                    CommandNameAttribute attribute = type.GetTypeInfo().GetCustomAttributes(typeof(CommandNameAttribute), true).OfType<CommandNameAttribute>().FirstOrDefault();
                    if (attribute == null)
                        continue;

                    if (!typeof(ICommand).GetTypeInfo().IsAssignableFrom(type.GetTypeInfo()))
                        continue;

                    if (!resultTypes.TryGetValue(attribute.Name, out var resultTypesForName))
                        resultTypesForName = new List<Tuple<ProtocolVersion, Type>>();

                    if (resultTypesForName.Count(t => t.Item1 == attribute.MinimumVersion) > 0)
                        Log.FatalFormat("Duplicate definition for {0} for version {1}", attribute.Name, attribute.MinimumVersion);

                    resultTypesForName.Add(Tuple.Create(attribute.MinimumVersion, type));

                    resultTypes[attribute.Name] = resultTypesForName;
                    resultNames[type] = Tuple.Create(attribute.Name, attribute.MinimumVersion);
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

        public static IReadOnlyDictionary<string, List<Tuple<ProtocolVersion, Type>>> GetAllTypes()
        {
            if (commandTypes == null)
                GenerateDictionaries();

            return commandTypes;
        }

        public static IReadOnlyDictionary<Type, Tuple<string, ProtocolVersion>> GetAllNames()
        {
            if (commandNames == null)
                GenerateDictionaries();

            return commandNames;
        }

        public static Type FindForName(string name, ProtocolVersion protocolVersion)
        {
            if (GetAllTypes().TryGetValue(name, out List<Tuple<ProtocolVersion, Type>> options))
            {
                var validOption = options.Where(o => o.Item1 <= protocolVersion).OrderByDescending(o => o.Item1).Take(1).ToArray();
                if (validOption.Length > 0)
                {
                    return validOption[0].Item2;
                }
            }

            return null;
            // return GetAllTypes().TryGetValue(name, out var options) ? res : null;
        }

        public static Tuple<string, ProtocolVersion> FindNameAndVersionForType(ICommand cmd)
        {
            return GetAllNames().TryGetValue(cmd.GetType(), out var res) ? res : null;
        }
    }
}
