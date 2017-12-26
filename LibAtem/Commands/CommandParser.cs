using System;
using log4net;

namespace LibAtem.Commands
{
    public static class CommandParser
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(CommandParser));

        public static ICommand Parse(ParsedCommand rawCmd)
        {
            Type commandType = CommandManager.FindForName(rawCmd.Name);
            if (commandType == null)
            {
                Log.WarnFormat("Unknown command {1} with content {2}", rawCmd.Name, BitConverter.ToString(rawCmd.Body));
                return null;
            }

            try
            {
                ICommand cmd = (ICommand)Activator.CreateInstance(commandType);
                cmd.Deserialize(rawCmd);

                if (!rawCmd.HasFinished && !(cmd is SerializableCommandBase))
                    throw new Exception("Some stray bytes were left after deserialize");

                return cmd;
            }
            catch (Exception e)
            {
                LogManager.GetLogger(commandType).Error(e);
                return null;
            }
        }
    }
}