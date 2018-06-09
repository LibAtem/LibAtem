using System;
using System.Security.Cryptography;
using LibAtem.Common;

namespace LibAtem.Util.Media
{
    public enum ColourSpace
    {
        BT601,
        BT709,
    }

    public class AtemFrame
    {
        private readonly byte[] _data;

        public string Name { get; }

        public static AtemFrame FromAtem(VideoModeResolution res, string name, byte[] data)
        {
            return new AtemFrame(name, FrameEncodingUtil.DecodeRLE(res, data));
        }

        public static AtemFrame FromYCbCr(string name, byte[] data)
        {
            return new AtemFrame(name, data);
        }

        public static AtemFrame FromRGBA(string name, byte[] data, ColourSpace colour)
        {
            return new AtemFrame(name, GetRGBAToYcbCrConverter(colour)(data));
        }
        
        private static Func<byte[], byte[]> GetRGBAToYcbCrConverter(ColourSpace colour)
        {
            switch (colour)
            {
                case ColourSpace.BT709:
                    return BT709ColourSpaceConverter.RGBAToYCbCrA10Bit422Safe3;
                default:
                    throw new ArgumentOutOfRangeException(nameof(colour));
            }
        }

        private AtemFrame(string name, byte[] data)
        {
            Name = name;
            _data = data;
        }

        public byte[] GetYCbCrData()
        {
            return _data;
        }

        public byte[] GetRLEEncodedYCbCr()
        {
            return FrameEncodingUtil.EncodeRLEUnsafe(_data);
        }

        public byte[] GetRGBA(ColourSpace colour)
        {
            switch (colour)
            {
                case ColourSpace.BT709:
                    return BT709ColourSpaceConverter.ToRGBA8(_data);
                default:
                    throw new ArgumentOutOfRangeException(nameof(colour));
            }
        }

        public byte[] GetHash()
        {
            using (MD5 md5Hash = MD5.Create())
                return md5Hash.ComputeHash(_data);
        }
    }
}