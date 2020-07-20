using LibAtem.Common;
using LibAtem.MacroOperations;
using LibAtem.Serialization;
using System.Collections.Generic;

namespace LibAtem.Commands.CameraControl
{
    [CommandName("CCmd", CommandDirection.ToServer)]
    public class CameraControlSetCommand : ICommand
    {

        public CameraInput Input { get; set; }
        public AdjustmentDomain AdjustmentDomain { get; set; }
        public CameraFeature CameraFeature { get; set; }
        public bool Relative { get; set; }
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
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }
        public int Y{ get; set; }


        public void Serialize(ByteArrayBuilder cmd)
        {
            cmd.AddUInt8((int)Input);
            cmd.AddUInt8((int)AdjustmentDomain);
            if (AdjustmentDomain == AdjustmentDomain.Chip)
            {
                cmd.AddUInt8((int)ChipFeature);
            }
            else if (AdjustmentDomain == AdjustmentDomain.Lens)
            {
                cmd.AddUInt8((int)LensFeature);
            }
            else if (AdjustmentDomain == AdjustmentDomain.Camera)
            {
                cmd.AddUInt8((int)CameraFeature);
            }else if(AdjustmentDomain == AdjustmentDomain.ColourBars)
            {
                cmd.AddUInt8(4);
            }
           

            cmd.AddBoolArray((bool)Relative);
    
          
            if (AdjustmentDomain == AdjustmentDomain.Chip)
            {

                if (ChipFeature == ChipFeature.Lift || ChipFeature == ChipFeature.Gamma || ChipFeature == ChipFeature.Gain)
                {
                    cmd.AddUInt8(128); // Unknown
                    cmd.Pad(4);
                    cmd.AddUInt8(4);
                    cmd.Pad(6);
                    cmd.AddUInt16((int)R);
                    cmd.AddUInt16((int)G);
                    cmd.AddUInt16((int)B);
                    cmd.AddUInt16((int)Y);
                }
                else if (ChipFeature == ChipFeature.Contrast)
                {
                    cmd.AddUInt8(128);
                    cmd.Pad(4);
                    cmd.AddUInt8(2);
                    cmd.Pad(6);
                    cmd.AddUInt8(4);
                    cmd.Pad(1);
                    cmd.AddUInt16(Contrast);
                    cmd.Pad(4);
                }
                else if (ChipFeature == ChipFeature.HueSaturation)
                {
                    cmd.AddUInt8(128);
                    cmd.Pad(4);
                    cmd.AddUInt8(2);
                    cmd.Pad(6);
                    cmd.AddUInt16(Hue);
                    cmd.AddUInt16(Saturation);
                    cmd.Pad(4);
                }
                else if(ChipFeature == ChipFeature.Lum)
                {
                    cmd.AddUInt8(128);
                    cmd.Pad(4);
                    cmd.AddUInt8(1);
                    cmd.Pad(6);
                    cmd.AddUInt16(LumMix);
                    cmd.Pad(6);
                }
              
            }
            else if (AdjustmentDomain == AdjustmentDomain.Lens)
            {
           
                if (LensFeature == LensFeature.Focus)
                {
                    cmd.AddUInt8(128); // Unknown
                    
                    cmd.AddUInt8(1); //when 4 it resets to zero when switching from main software
                    cmd.Pad(6);
                    cmd.AddInt16(1,Focus);
                    cmd.Pad(6);
                }
                else if (LensFeature == LensFeature.Zoom)
                {
                    cmd.AddUInt8(128);
                    cmd.Pad(4);
                    cmd.AddUInt8(1); 
                    cmd.Pad(6);
                    cmd.AddInt16(1, ZoomSpeed);
                    cmd.Pad(6);
                }
                else if (LensFeature == LensFeature.Iris)
                {
                    cmd.AddUInt8(128);
                    cmd.Pad(4);
                    cmd.AddUInt8(1);
                    cmd.Pad(6);
                    cmd.AddInt16(1,Iris);
                    cmd.Pad(6);
                }
                else if (LensFeature == LensFeature.AutoFocus) //only this one is a different length
                {
                    cmd.Pad(1);
                    cmd.AddUInt8(1);
                    cmd.Pad(10);
                    
                }
            }
        
            else if (AdjustmentDomain == AdjustmentDomain.Camera)
            {
             
                if (CameraFeature == CameraFeature.Gain)
                {
                    cmd.AddUInt8(1); // Unknown
                    cmd.Pad(2);
                    cmd.AddUInt8(1);
                    cmd.Pad(8);
                    cmd.AddUInt8(CameraGain);
                    cmd.Pad(7);
                }
                else if (CameraFeature == CameraFeature.WhiteBalance)
                {
                    cmd.AddUInt8(2); // Unknown
                    cmd.Pad(4);
                    cmd.AddUInt8(1);
                    cmd.Pad(6);
                    cmd.AddUInt16(WhiteBalance);
                    cmd.Pad(6);
                }
                else if (CameraFeature == CameraFeature.Shutter)
                {
                    cmd.AddUInt8(3); // Unknown
                    cmd.Pad(6);
                    cmd.AddUInt8(1);
                    cmd.Pad(6);
                    cmd.AddUInt16(Shutter);
                    cmd.Pad(4);
                }
                else if (CameraFeature == CameraFeature.Detail)
                {
                    cmd.AddUInt8(1);
                    cmd.Pad(2);
                    cmd.AddUInt8(1);
                    cmd.Pad(8);
                    cmd.AddUInt8((int)Detail);
                    cmd.Pad(7);
                }
            }
            else if (AdjustmentDomain==AdjustmentDomain.ColourBars)
            {
                cmd.AddUInt8(1);
                cmd.Pad(2);
                cmd.AddUInt8(1);
                cmd.Pad(8);
                cmd.AddUInt8(ColorBars ? 10 : 0);
                cmd.Pad(7);
            }
            else
            {
                cmd.Pad(16);
            }
        }

        public void Deserialize(ParsedByteArray cmd)
        {
        

            
                
        }
    }
}