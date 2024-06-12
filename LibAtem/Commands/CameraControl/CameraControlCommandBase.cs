using System;
using LibAtem.Common;
using LibAtem.Serialization;

namespace LibAtem.Commands.CameraControl
{
    public enum CameraControlDataType
    {
        Bool = 0x00,
        SInt8 = 0x01,
        SInt16 = 0x02,
        SInt32 = 0x03,
        SInt64 = 0x04,
        String = 0x05,
        Float = 0x80,
    }

    public abstract class CameraControlCommandBase : ICommand
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
        public long[] LongData { get; set; }
        public double[] FloatData { get; set; }
        public string StringData { get; set; }
        public bool[] BoolData { get; set; }

        protected abstract void SerializeType(ByteArrayBuilder cmd);
        protected abstract void DeserializeType(ParsedByteArray cmd);

        protected abstract void SerializePostLength(ByteArrayBuilder cmd);
        protected abstract void DeserializePostLength(ParsedByteArray cmd);

        public void Serialize(ByteArrayBuilder cmd)
        {
            cmd.AddUInt8((uint) Input);
            cmd.AddUInt8(Category);
            cmd.AddUInt8(Parameter);
            SerializeType(cmd);
            
            switch (Type)
            {
                case CameraControlDataType.Bool:
                {
                    bool[] data = BoolData ?? Array.Empty<bool>();
                    cmd.AddUInt16(data.Length);
                    cmd.Pad(6);

                    SerializePostLength(cmd);
                    cmd.PadToNearestMultipleOf8();

                    foreach (bool val in data)
                        cmd.AddBoolArray(val);
                    cmd.PadToNearestMultipleOf8();

                    break;
                }
                case CameraControlDataType.SInt8:
                {
                    int[] data = IntData ?? Array.Empty<int>();
                    cmd.AddUInt16(data.Length);
                    cmd.Pad(6);

                    SerializePostLength(cmd);
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

                    SerializePostLength(cmd);
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

                    SerializePostLength(cmd);
                    cmd.PadToNearestMultipleOf8();

                        foreach (int val in data)
                        cmd.AddInt32(val);
                    cmd.PadToNearestMultipleOf8();

                    break;
                }
                case CameraControlDataType.SInt64:
                {
                    long[] data = LongData ?? Array.Empty<long>();
                    cmd.Pad(6);
                    cmd.AddUInt16(data.Length);

                    SerializePostLength(cmd);
                    cmd.PadToNearestMultipleOf8();

                        foreach (long val in data)
                        cmd.AddInt64(val);
                    cmd.PadToNearestMultipleOf8();

                    break;
                }
                case CameraControlDataType.String:
                {
                    string str = StringData ?? string.Empty;
                    cmd.AddUInt16(str.Length);
                    cmd.Pad(6);

                    SerializePostLength(cmd);
                    cmd.PadToNearestMultipleOf8();

                        cmd.AddString(str);
                    cmd.PadToNearestMultipleOf8();
                    break;
                }
                case CameraControlDataType.Float:
                {
                    double[] data = FloatData ?? Array.Empty<double>();
                    cmd.Pad(2);
                    cmd.AddUInt16(data.Length);
                    cmd.Pad(4);

                    SerializePostLength(cmd);
                    cmd.PadToNearestMultipleOf8();

                    foreach (double val in data)
                        // Values are encoded as 5.11 fixed point floats
                        cmd.AddInt16(0x800, val); 
                    cmd.PadToNearestMultipleOf8();

                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Deserialize(ParsedByteArray cmd)
        {
            Input = (VideoSource)cmd.GetUInt8(); // 0
            Category = cmd.GetUInt8(); // 1
            Parameter = cmd.GetUInt8(); // 2
            DeserializeType(cmd); // 3/3-5

            uint count8 = cmd.GetUInt16(); // 4/6
            uint count16 = cmd.GetUInt16(); // 6/8
            uint count32 = cmd.GetUInt16(); // 8/10
            uint count64 = cmd.GetUInt16(); // 10/12

            DeserializePostLength(cmd);

            cmd.SkipToNearestMultipleOf8();

            switch (Type)
            {
                case CameraControlDataType.Bool:
                {
                    BoolData = new bool[count8];
                    for (int i = 0; i < count8; i++)
                        BoolData[i] = cmd.GetBoolArray()[0];

                    break;
                }
                case CameraControlDataType.SInt8:
                {
                    IntData = new int[count8];
                    for (int i = 0; i < count8; i++)
                        IntData[i] = (sbyte)cmd.GetUInt8();

                    break;
                }
                case CameraControlDataType.SInt16:
                {
                    IntData = new int[count16];
                    for (int i = 0; i < count16; i++)
                        IntData[i] = cmd.GetInt16();
                    break;
                }
                case CameraControlDataType.SInt32:
                {
                    IntData = new int[count32];
                    for (int i = 0; i < count32; i++)
                        IntData[i] = cmd.GetInt32();
                    break;
                }
                case CameraControlDataType.SInt64:
                {
                    LongData = new long[count64];
                    for (int i = 0; i < count64; i++)
                        LongData[i] = cmd.GetInt64();
                    break;
                }
                case CameraControlDataType.String:
                {
                    StringData = cmd.GetString(count8);
                    break;
                }
                case CameraControlDataType.Float:
                {
                    FloatData = new double[count16];
                    for (int i = 0; i < count16; i++)
                    {
                        double raw = cmd.GetUInt16();
                        // Values are encoded as 5.11 fixed point floats
                        FloatData[i] = raw / 0x800;
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