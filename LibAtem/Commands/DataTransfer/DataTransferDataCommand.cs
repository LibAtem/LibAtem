using System;
using System.Collections.Generic;
using System.Linq;
using LibAtem.MacroOperations;

namespace LibAtem.Commands.DataTransfer
{
    [CommandName("FTDa")]
    public class DataTransferDataCommand : ICommand
    {
        [CommandId]
        public uint TransferId { get; set; }

        public byte[] Body { get; set; }
        //public List<MacroOpBase> Operations { get; set; }

        public void Deserialize(ParsedByteArray cmd)
        {
            TransferId = cmd.GetUInt16();
            var size = cmd.GetUInt16();
            Body = new byte[size];
            Array.Copy(cmd.Body, 4, Body, 0, size);
            cmd.Skip(size);
            //            Operations = new List<MacroOpBase>();
            //
            //            uint length = cmd.GetUInt16();
            //            uint pos = 0;
            //            while (!cmd.HasFinished)
            //            {
            //                uint opLength = cmd.GetUInt16();
            //                cmd.Skip(opLength - 2);
            //
            //                byte[] opData = new byte[opLength];
            //                Array.Copy(cmd.Body, pos, opData, 0, opLength);
            //                pos += opLength;
            //
            //                Operations.Add(MacroOpManager.CreateFromData(opData));
            //            }
        }

        public void Serialize(ByteArrayBuilder cmd)
        {
            cmd.AddUInt16(TransferId);

            cmd.AddUInt16(Body.Length);
            cmd.AddByte(Body);

//            byte[] data = Operations.SelectMany(o => MacroOpExtensions.ToByteArray(o)).ToArray();
//
//            cmd.AddUInt16(data.Length);
//            cmd.AddByte(data);
        }
    }
}