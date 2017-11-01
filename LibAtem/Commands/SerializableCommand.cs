using LibAtem.MacroOperations;
using LibAtem.Serialization;
using System.Collections.Generic;

namespace LibAtem.Commands
{
    public abstract class SerializableCommandBase : AutoSerializeBase, ICommand
    {
        public virtual IEnumerable<MacroOpBase> ToMacroOps() => null;
    }
}