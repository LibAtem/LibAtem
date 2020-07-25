using System;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.CameraControl
{
    [CommandName("CCdP", CommandDirection.ToClient)]
    public class CameraControlGetCommand : ICommand
    {
        public enum DataType
        {
            SInt8 = 0x01,
            SInt16 = 0x02,
            SInt32 = 0x03,
            // SInt64 = 0x04, // TODO Verify
            Float = 0x80,
        }

        [CommandId]
        [Serialize(0), Enum8]
        public VideoSource Input { get; set; }

        [CommandId]
        [Serialize(1), UInt8]
        public uint Category { get; set; }
        [CommandId]
        [Serialize(2), UInt8]
        public uint Parameter { get; set; }

        [Serialize(3), Enum8]
        public DataType Type { get; set; }

        public int[] IntData { get; set; }
        public double[] FloatData { get; set; }

        public void Serialize(ByteArrayBuilder cmd)
        {
            // TODO
            throw new NotImplementedException();
        }

        public void Deserialize(ParsedByteArray cmd)
        {
            Input = (VideoSource)cmd.GetUInt8();
            Category = cmd.GetUInt8();
            Parameter = cmd.GetUInt8();
            Type = (DataType) cmd.GetUInt8();

            switch (Type)
            {
                case DataType.SInt8:
                {
                    // Length
                    uint count = cmd.GetUInt16();
                    cmd.Skip(6);

                    cmd.SkipToNearestMultipleOf8();

                    // Data
                    IntData = new int[count];
                    for (int i = 0; i < count; i++)
                        IntData[i] = (sbyte)cmd.GetUInt8();

                    break;
                }
                case DataType.SInt16:
                {
                    // Length
                    cmd.Skip(2);
                    uint count = cmd.GetUInt16();
                    cmd.Skip(4);

                    cmd.SkipToNearestMultipleOf8();

                    // Data
                    IntData = new int[count];
                    for (int i = 0; i < count; i++)
                        IntData[i] = cmd.GetInt16();
                    break;
                }
                case DataType.SInt32:
                {
                    // Length
                    cmd.Skip(4);
                    uint count = cmd.GetUInt16();
                    cmd.Skip(2);

                    cmd.SkipToNearestMultipleOf8();

                    // Data
                    IntData = new int[count];
                    for (int i = 0; i < count; i++)
                        IntData[i] = cmd.GetInt32();
                    break;
                }
                case DataType.Float:
                {
                    // Length
                    cmd.Skip(2);
                    uint count = cmd.GetUInt16();
                    cmd.Skip(4);

                    cmd.SkipToNearestMultipleOf8();

                    // Data
                    FloatData = new double[count];
                    for (int i = 0; i < count; i++)
                    {
                        double raw = cmd.GetUInt16();
                        FloatData[i] = raw / 0x7ff;
                    }

                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }

            cmd.SkipToNearestMultipleOf8();
        }

    }
}