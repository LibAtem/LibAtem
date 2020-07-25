using System;
using LibAtem.Common;
using LibAtem.Util;

namespace LibAtem.Commands.CameraControl
{
    [CommandName("CCdP", CommandDirection.ToClient)]
    public class CameraControlGetCommand : ICommand
    {
        [CommandId]
        public VideoSource Input { get; set; }

        [CommandId]
        public AdjustmentDomain AdjustmentDomain { get; set; }
        [CommandId]
        public CameraFeature CameraFeature { get; set; }
        [CommandId]
        public LensFeature LensFeature { get; set; }
        [CommandId]
        public ChipFeature ChipFeature { get; set; }
        
        
        public CameraDetail Detail { get; set; }

        public bool ColorBars { get; set; }
        

        public uint CameraPositiveGain { get; set; }
        public int CameraGain { get; set; }
        public uint Shutter {get; set;}
        public uint WhiteBalance { get; set; }


        public double ZoomSpeed { get; set; }
        public double Focus { get; set; }
        public double Iris { get; set; }

        public double Contrast { get; set; }
        public double Hue { get; set; }
        public double Saturation { get; set; }
        public double LumMix { get; set; }
        public double Aperture { get; set; }
        public double R { get; set; }
        public double G { get; set; }
        public double B { get; set; }
        public double Y { get; set; }


        public void Serialize(ByteArrayBuilder cmd)
        {

        }

        public void Deserialize(ParsedByteArray cmd)
        {
            Input = (VideoSource)cmd.GetUInt8();
            AdjustmentDomain = (AdjustmentDomain)cmd.GetUInt8();
            if (AdjustmentDomain == AdjustmentDomain.Camera)
            {
                CameraFeature = (CameraFeature)cmd.GetUInt8();
                switch (CameraFeature)
                {
                    case CameraFeature.Detail:
                    {
                        int[] data = ReadSInt8(cmd, 1);
                        Detail = (CameraDetail) data[0];
                        break;
                    }
                    case CameraFeature.PositiveGain:
                    {
                        int[] data = ReadSInt8(cmd, 1);
                        CameraPositiveGain = (uint) data[0];
                        break;
                    }
                    case CameraFeature.Gain:
                    {
                        int[] data = ReadSInt8(cmd, 1);
                        CameraGain = data[0];
                        break;
                    }
                    case CameraFeature.Shutter:
                    {
                        int[] data = ReadSInt32(cmd, 1);
                        Shutter = (uint) data[0];
                        break;
                    }
                    case CameraFeature.WhiteBalance:
                    {
                        int[] data = ReadSInt16(cmd, 1);
                        WhiteBalance = (uint) data[0];
                        break;
                    }
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else if (AdjustmentDomain == AdjustmentDomain.Lens)
            {
                LensFeature = (LensFeature)cmd.GetUInt8();
                switch (LensFeature)
                {
                    case LensFeature.Zoom:
                    {
                        double[] data = ReadFloats(cmd, 1);
                        ZoomSpeed = data[0];
                        break;
                    }
                    case LensFeature.Focus:
                    {
                        double[] data = ReadFloats(cmd, 1);
                        Focus = data[0];
                        break;
                    }
                    case LensFeature.Iris:
                    {
                        double[] data = ReadFloats(cmd, 1);
                        Iris = data[0];
                        break;
                    }
                    case LensFeature.AutoFocus:
                        // TODO
                        cmd.Skip(20);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else if (AdjustmentDomain == AdjustmentDomain.Chip)
            {
                ChipFeature = (ChipFeature)cmd.GetUInt8();
                switch (ChipFeature)
                {
                    case ChipFeature.Lift:
                    case ChipFeature.Gamma:
                    case ChipFeature.Gain:
                    {
                        double[] data = ReadFloats(cmd, 4);
                        R = data[0];
                        G = data[1];
                        B = data[2];
                        Y = data[3];
                        break;
                    }
                    case ChipFeature.Contrast:
                    {
                        double[] data = ReadFloats(cmd, 2);
                        // TODO - value 0
                        Contrast = data[1];
                        break;
                    }
                    case ChipFeature.HueSaturation:
                    {
                        double[] data = ReadFloats(cmd, 2);
                        Hue = data[0];
                        Saturation = data[1];
                        break;
                    }
                    case ChipFeature.Lum:
                    {
                        double[] data = ReadFloats(cmd, 1);
                        LumMix = data[0];
                        break;
                    }
                    //Not tested, only called on init
                    case ChipFeature.Aperture:
                    {
                        double[] data = ReadFloats(cmd, 4);
                        // TODO - value 1, 2, 3
                        Aperture = data[0];
                        break;
                    }
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else if (AdjustmentDomain == AdjustmentDomain.ColourBars)
            {
                uint feature = cmd.GetUInt8();
                switch (feature)
                {
                    case 4:
                    {
                        int[] data = ReadSInt8(cmd, 1);
                        ColorBars = (data[0] == 10);
                        break;
                    }
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        private enum DataType
        {
            SInt8 = 0x01,
            SInt16 = 0x02,
            SInt32 = 0x03,
            // SInt64 = 0x04, // TODO Verify
            Float = 0x80,
        }

        private static void EnsureDataType(ParsedByteArray cmd, DataType expected)
        {
            DataType type = (DataType)cmd.GetUInt8();
            if (!type.IsValid()) throw new Exception($"Unknown DataType {type}");
            if (type != expected) throw new Exception($"Incorrect DataType {type}, expected {expected}");
        }

        private static double[] ReadFloats(ParsedByteArray cmd, int expectedCount)
        {
            EnsureDataType(cmd, DataType.Float);

            // Length
            cmd.Skip(2);
            uint count = cmd.GetUInt16();
            if (count != expectedCount) throw new Exception($"Incorrect count {count}, expected {expectedCount}");
            cmd.Skip(4);

            cmd.SkipToNearestMultipleOf8();

            // Data
            double[] res = new double[count];
            for (int i = 0; i < count; i++)
            {
                double raw = cmd.GetUInt16();
                res[i] = raw / 0x7ff;
            }

            cmd.SkipToNearestMultipleOf8();

            return res;
        }

        private static int[] ReadSInt8(ParsedByteArray cmd, int expectedCount)
        {
            EnsureDataType(cmd, DataType.SInt8);

            // Length
            uint count = cmd.GetUInt16();
            if (count != expectedCount) throw new Exception($"Incorrect count {count}, expected {expectedCount}");
            cmd.Skip(6);

            cmd.SkipToNearestMultipleOf8();

            // Data
            int[] res = new int[count];
            for (int i = 0; i < count; i++)
                res[i] = (sbyte) cmd.GetUInt8(); // TODO - test this

            cmd.SkipToNearestMultipleOf8();

            return res;
        }

        private static int[] ReadSInt16(ParsedByteArray cmd, int expectedCount)
        {
            EnsureDataType(cmd, DataType.SInt16);

            // Length
            cmd.Skip(2);
            uint count = cmd.GetUInt16();
            if (count != expectedCount) throw new Exception($"Incorrect count {count}, expected {expectedCount}");
            cmd.Skip(4);

            cmd.SkipToNearestMultipleOf8();

            // Data
            int[] res = new int[count];
            for (int i = 0; i < count; i++)
                res[i] = cmd.GetInt16();

            cmd.SkipToNearestMultipleOf8();

            return res;
        }

        private static int[] ReadSInt32(ParsedByteArray cmd, int expectedCount)
        {
            EnsureDataType(cmd, DataType.SInt32);

            // Length
            cmd.Skip(4);
            uint count = cmd.GetUInt16();
            if (count != expectedCount) throw new Exception($"Incorrect count {count}, expected {expectedCount}");
            cmd.Skip(2);

            cmd.SkipToNearestMultipleOf8();

            // Data
            int[] res = new int[count];
            for (int i = 0; i < count; i++)
                res[i] = cmd.GetInt32();

            cmd.SkipToNearestMultipleOf8();

            return res;
        }
    }
}