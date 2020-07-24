using System;
using log4net;

namespace LibAtem.Commands
{
    public static class CommandParser
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(CommandParser));

        public static ICommand Parse(ProtocolVersion protocolVersion, ParsedCommandSpec rawCmd)
        {
            Type commandType = CommandManager.FindForName(rawCmd.Name, protocolVersion);
            if (commandType == null)
            {
                Log.WarnFormat("Unknown command {0} with content {1}", rawCmd.Name, BitConverter.ToString(rawCmd.Body));
                return null;
            }

            try
            {
                return ParseInner(rawCmd, commandType);
            }
            catch (Exception e)
            {
                LogManager.GetLogger(commandType).Error(e);
                return null;
            }
        }

        public static ICommand ParseUnsafe(ProtocolVersion protocolVersion, ParsedCommandSpec rawCmd)
        {
            Type commandType = CommandManager.FindForName(rawCmd.Name, protocolVersion);
            if (commandType == null)
                throw new ArgumentOutOfRangeException(string.Format("Unknown command {0}", rawCmd.Name));

            return ParseInner(rawCmd, commandType);
        }

        private static ICommand ParseInner(ParsedCommandSpec rawCmd, Type commandType)
        {
            ICommand cmd = (ICommand)Activator.CreateInstance(commandType);
            var rawCmd2 = new ParsedCommand(rawCmd); 
            cmd.Deserialize(rawCmd2);

            if (!rawCmd2.HasFinished && !(cmd is SerializableCommandBase))
                throw new Exception("Some stray bytes were left after deserialize");

            return cmd;
        }
    }
}