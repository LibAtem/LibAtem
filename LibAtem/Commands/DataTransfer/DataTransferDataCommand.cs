using System;

namespace LibAtem.Commands.DataTransfer
{
    [CommandName("FTDa")]
    public class DataTransferDataCommand : ICommand
    {
        [CommandId]
        public uint TransferId { get; set; }

        public byte[] Body { get; set; }

        public void Deserialize(ParsedByteArray cmd)
        {
            TransferId = cmd.GetUInt16();
            var size = cmd.GetUInt16();
            Body = new byte[size];
            Array.Copy(cmd.Body, 4, Body, 0, size);
            cmd.Skip(size);
        }

        public void Serialize(ByteArrayBuilder cmd)
        {
            cmd.AddUInt16(TransferId);

            cmd.AddUInt16(Body.Length);
            cmd.AddByte(Body);
        }
    }
}