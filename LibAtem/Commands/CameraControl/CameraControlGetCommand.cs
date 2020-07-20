using LibAtem.Common;
using LibAtem.MacroOperations;
using LibAtem.Serialization;
using System.Collections.Generic;

namespace LibAtem.Commands.CameraControl
{
    [CommandName("CCdP", CommandDirection.ToClient)]
    public class CameraControlGetCommand : ICommand
    {
        public VideoSource Input { get; set; }

        public AdjustmentDomain AdjustmentDomain { get; set; }
        public CameraFeature CameraFeature { get; set; }
        public LensFeature LensFeature { get; set; }
        public ChipFeature ChipFeature { get; set; }
        public CameraDetail Detail { get; set; }

        public bool ColorBars { get; set; }
        

        public uint CameraPositiveGain { get; set; }
        public int CameraGain { get; set; }
        public uint Shutter {get; set;}
        public uint WhiteBalance { get; set; }


        public int ZoomSpeed { get; set; }
        public int Focus { get; set; }
        public uint Iris { get; set; }

        public uint Contrast { get; set; }
        public int Hue { get; set; }
        public uint Saturation { get; set; }
        public uint LumMix { get; set; }
        public uint Aperture { get; set; }
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }
        public int Y{ get; set; }


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
                if (CameraFeature == CameraFeature.Detail)
                {
                    cmd.Skip(13);
                    Detail = (CameraDetail)cmd.GetUInt8();
                    cmd.Skip(7);
                }
                else if (CameraFeature == CameraFeature.PositiveGain)
                {
                    cmd.Skip(13);
                    CameraPositiveGain = cmd.GetUInt16();
                    cmd.Skip(6);
                }
                else if (CameraFeature == CameraFeature.Gain)
                {
                    cmd.Skip(13);
                    CameraGain = (sbyte)cmd.GetByte();
                    cmd.Skip(7);
                }
                else if (CameraFeature == CameraFeature.Shutter)
                {
                    cmd.Skip(15);
                    Shutter = cmd.GetUInt16();
                    cmd.Skip(4);
                }
                else if (CameraFeature == CameraFeature.WhiteBalance)
                {
                    cmd.Skip(13);
                    WhiteBalance = cmd.GetUInt16();
                    cmd.Skip(6);
                }


            }
            else if (AdjustmentDomain == AdjustmentDomain.Lens)
            {
                LensFeature = (LensFeature)cmd.GetUInt8();
                if (LensFeature == LensFeature.Zoom)
                {
                    cmd.Skip(13);
                    ZoomSpeed = cmd.GetInt16();
                    cmd.Skip(6);
                }
                else if (LensFeature == LensFeature.Focus)
                {
                    cmd.Skip(13);
                    Focus = cmd.GetInt16();
                    cmd.Skip(6);
                }
                else if (LensFeature == LensFeature.Iris)
                {
                    cmd.Skip(13);
                    Iris = cmd.GetUInt16();
                    cmd.Skip(6);
                }
                else if (LensFeature == LensFeature.AutoFocus)
                {
                    cmd.Skip(20);
                }
            }
            else if (AdjustmentDomain == AdjustmentDomain.Chip)
            {
                ChipFeature = (ChipFeature)cmd.GetUInt8();
                if (ChipFeature == ChipFeature.Lift || ChipFeature == ChipFeature.Gamma || ChipFeature == ChipFeature.Gain)
                {
                    cmd.Skip(13);
                    R = cmd.GetInt16();
                    G = cmd.GetInt16();
                    B = cmd.GetInt16();
                    Y = cmd.GetInt16();
                }
                else if (ChipFeature == ChipFeature.Contrast)
                {
                    cmd.Skip(15);
                    Contrast = cmd.GetUInt16();
                    cmd.Skip(4);
                }
                else if (ChipFeature == ChipFeature.HueSaturation)
                {
                    cmd.Skip(13);
                    Hue = cmd.GetInt16();
                    Saturation = cmd.GetUInt16();
                    cmd.Skip(4);
                }
                else if (ChipFeature == ChipFeature.Lum)
                {
                    cmd.Skip(13);
                    LumMix = cmd.GetUInt16();
                    cmd.Skip(6);
                }
                else if (ChipFeature == ChipFeature.Aperture) //Not tested, only called on init
                {
                    cmd.Skip(13);
                    Aperture = cmd.GetUInt16();
                    cmd.Skip(6);
                }


            }
            else if (AdjustmentDomain == AdjustmentDomain.ColourBars)
            {
                //Input = Input - 1; //reduce input by 1 
                cmd.Skip(14);
                var colorBarsByte = cmd.GetUInt8();
                ColorBars = (colorBarsByte == 10);
                cmd.Skip(7);
                
            }
     
            // TODO - we dont want this
            cmd.SkipTo(cmd.BodyLength);
        }
    }
}