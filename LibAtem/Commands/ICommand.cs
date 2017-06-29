using System;
using System.Linq;
using System.Reflection;

namespace LibAtem.Commands
{
    public interface ICommand
    {
        void Serialize(CommandBuilder cmd);

        void Deserialize(ParsedCommand cmd);
    }

    public class CommandNameAttribute : Attribute
    {
        public CommandNameAttribute(string name)
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
}
