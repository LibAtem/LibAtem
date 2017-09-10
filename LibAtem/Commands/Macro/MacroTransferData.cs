using LibAtem.MacroOperations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibAtem.Commands.Macro
{
    [CommandName("FTDa")]
    public class MacroTransferDataCommand : ICommand
    {
        [CommandId]
        public uint TransferId { get; set; }

        public List<MacroOpBase> Operations { get; set; }

        public void Deserialize(ParsedByteArray cmd)
        {
            TransferId = cmd.GetUInt16();
            Operations = new List<MacroOpBase>();

            uint length = cmd.GetUInt16();
            uint pos = 0;
            while (!cmd.HasFinished)
            {
                uint opLength = cmd.GetUInt16();
                cmd.Skip(opLength - 2);

                byte[] opData = new byte[opLength];
                Array.Copy(cmd.Body, pos, opData, 0, opLength);
                pos += opLength;

                Operations.Add(MacroOpManager.CreateFromData(opData));
            }
        }

        public void Serialize(ByteArrayBuilder cmd)
        {
            cmd.AddUInt16(TransferId);

            byte[] data = Operations.SelectMany(o => o.ToByteArray()).ToArray();

            cmd.AddUInt16(data.Length);
            cmd.AddByte(data);
        }
    }
}