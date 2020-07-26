using System;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.CameraControl
{
    [CommandName("CCdP", CommandDirection.ToClient)]
    public class CameraControlGetCommand : ICommand
    {
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
        public CameraControlDataType Type { get; set; }

        public int[] IntData { get; set; }
        public double[] FloatData { get; set; }

        protected virtual void SerializeType(ByteArrayBuilder cmd)
        {
            cmd.AddUInt8((uint)Type);
        }

        public void Serialize(ByteArrayBuilder cmd)
        {
            cmd.AddUInt8((uint) Input);
            cmd.AddUInt8(Category);
            cmd.AddUInt8(Parameter);
            SerializeType(cmd);

            switch (Type)
            {
                case CameraControlDataType.SInt8:
                {
                    int[] data = IntData ?? Array.Empty<int>();
                    cmd.AddUInt16(data.Length);
                    cmd.Pad(6);
                    cmd.PadToNearestMultipleOf8();

                    foreach (int val in data)
                        cmd.AddInt8(val);
                    cmd.PadToNearestMultipleOf8();

                    break;
                }
                case CameraControlDataType.SInt16:
                {
                    int[] data = IntData ?? Array.Empty<int>();
                    cmd.Pad(2);
                    cmd.AddUInt16(data.Length);
                    cmd.Pad(4);
                    cmd.PadToNearestMultipleOf8();

                    foreach (int val in data)
                        cmd.AddInt16(val);
                    cmd.PadToNearestMultipleOf8();

                    break;
                }
                case CameraControlDataType.SInt32:
                {
                    int[] data = IntData ?? Array.Empty<int>();
                    cmd.Pad(4);
                    cmd.AddUInt16(data.Length);
                    cmd.Pad(2);
                    cmd.PadToNearestMultipleOf8();

                    foreach (int val in data)
                        cmd.AddInt32(val);
                    cmd.PadToNearestMultipleOf8();

                    break;
                }
                case CameraControlDataType.Float:
                {
                    double[] data = FloatData ?? Array.Empty<double>();
                    cmd.Pad(2);
                    cmd.AddUInt16(data.Length);
                    cmd.Pad(4);
                    cmd.PadToNearestMultipleOf8();

                    foreach (double val in data)
                        cmd.AddInt16(0x7ff, val); // TODO
                    cmd.PadToNearestMultipleOf8();

                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        protected virtual void DeserializeType(ParsedByteArray cmd)
        {
            Type = (CameraControlDataType)cmd.GetUInt8();
        }

        public void Deserialize(ParsedByteArray cmd)
        {
            Input = (VideoSource)cmd.GetUInt8();
            Category = cmd.GetUInt8();
            Parameter = cmd.GetUInt8();
            DeserializeType(cmd);

            switch (Type)
            {
                case CameraControlDataType.SInt8:
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
                case CameraControlDataType.SInt16:
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
                case CameraControlDataType.SInt32:
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
                case CameraControlDataType.Float:
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

    public enum CameraControlDataType
    {
        SInt8 = 0x01,
        SInt16 = 0x02,
        SInt32 = 0x03,
        // SInt64 = 0x04, // TODO Verify
        Float = 0x80,
    }
}