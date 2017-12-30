using System;
using System.Collections.Generic;
using System.Reflection;
using LibAtem.Util;

namespace LibAtem.Commands
{
    public class CommandQueue : UniqueQueue<CommandQueueKey, ICommand>
    {
        public void Enqueue(ICommand item)
        {
            Enqueue(new CommandQueueKey(item), item);
        }

        public void Enqueue(IReadOnlyList<ICommand> commands)
        {
            foreach (ICommand item in commands)
                Enqueue(new CommandQueueKey(item), item);
        }
    }

    public struct CommandQueueKey : IEquatable<CommandQueueKey>
    {
        public string Name { get; }
        public int Mask { get; }
        public long Id { get; }

        public CommandQueueKey(ICommand cmd)
        {
            Name = cmd.GetType().Name;
            Mask = GetMask(cmd);
            Id = GetId(cmd);
        }

        private static int GetMask(ICommand cmd)
        {
            PropertyInfo mask = cmd.GetType().GetProperty("Mask");
            if (mask == null)
                return 0;

            return (int) mask.GetValue(cmd);
        }

        private static long GetId(ICommand cmd)
        {
            int hashCode = 0;
            // TODO - this should be cached to improve performance
            foreach (PropertyInfo prop in CommandIdAttribute.GetProperties(cmd.GetType()))
                hashCode = (hashCode * 256) + (1 + Convert.ToInt32(prop.GetValue(cmd)));

            return hashCode;
        }

        #region IEquatable

        public bool Equals(CommandQueueKey other)
        {
            return string.Equals(Name, other.Name) && Mask == other.Mask && Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is CommandQueueKey && Equals((CommandQueueKey) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Mask;
                hashCode = (hashCode * 397) ^ Id.GetHashCode();
                return hashCode;
            }
        }

        #endregion IEquatable
    }
}