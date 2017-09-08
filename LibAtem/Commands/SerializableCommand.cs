using System.Reflection;
using LibAtem.MacroOperations;
using LibAtem.Serialization;
using System.Collections.Generic;

namespace LibAtem.Commands
{
    public abstract class SerializableCommandBase : AutoSerializeBase, ICommand
    {
        protected override int GetLengthFromAttribute()
        {
            return GetType().GetTypeInfo().GetCustomAttribute<CommandNameAttribute>()?.Length ?? -1;
        }

        public virtual IEnumerable<MacroOpBase> ToMacroOps() => null;
    }
}