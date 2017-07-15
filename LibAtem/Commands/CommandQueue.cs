using System;
using System.Collections.Generic;
using System.Linq;
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
    }

    public struct CommandQueueKey : IEquatable<CommandQueueKey>
    {
        public string Name { get; }
        public int Mask { get; }
        public int Id { get; }

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

        private static int GetId(ICommand cmd)
        {
            return CommandIdAttribute.GetProperties(cmd.GetType()).Select(p => Convert.ToInt32(p.GetValue(cmd))).Sum();
        }

        #region IEquatable

        public bool Equals(CommandQueueKey other)
        {
            return string.Equals((string) Name, (string) other.Name) && Mask == other.Mask && Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(null, obj)) return false;
            return obj is CommandQueueKey && Equals((CommandQueueKey) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Mask;
                hashCode = (hashCode * 397) ^ Id;
                return hashCode;
            }
        }

        #endregion IEquatable
    }
}