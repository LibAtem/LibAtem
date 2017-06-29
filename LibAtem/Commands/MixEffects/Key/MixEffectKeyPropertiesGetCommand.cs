using LibAtem.Common;

namespace LibAtem.Commands.MixEffects.Key
{
    [CommandName("KeBP")]
    public class MixEffectKeyPropertiesGetCommand : ICommand
    {
        public MixEffectBlockId MixEffectIndex { get; set; }
        public uint KeyerIndex { get; set; }
        public MixEffectKeyType Mode { get; set; }
        public bool FlyEnabled { get; set; }
        public VideoSource FillSource { get; set; }
        public VideoSource CutSource { get; set; }
        public bool MaskEnabled { get; set; }
        public double MaskTop { get; set; }
        public double MaskBottom { get; set; }
        public double MaskLeft { get; set; }
        public double MaskRight { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8((int)MixEffectIndex);
            cmd.AddUInt8(KeyerIndex);
            cmd.AddUInt8((int)Mode);
            cmd.AddBoolArray(false); // ??
            cmd.AddBoolArray(false); // ??
            cmd.AddBoolArray(FlyEnabled);
            cmd.AddUInt16((int)FillSource);
            cmd.AddUInt16((int)CutSource);

            cmd.AddBoolArray(MaskEnabled);
            cmd.Pad();
            cmd.AddInt16(1000, MaskTop);
            cmd.AddInt16(1000, MaskBottom);
            cmd.AddInt16(1000, MaskLeft);
            cmd.AddInt16(1000, MaskRight);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            MixEffectIndex = (MixEffectBlockId) cmd.GetUInt8();
            KeyerIndex = cmd.GetUInt8();
            Mode = (MixEffectKeyType) cmd.GetUInt8();
            cmd.Skip(2);
            FlyEnabled = cmd.GetBoolArray()[0];
            FillSource = (VideoSource) cmd.GetUInt16();
            CutSource = (VideoSource) cmd.GetUInt16();

            MaskEnabled = cmd.GetBoolArray()[0];
            cmd.Skip();
            MaskTop = cmd.GetInt16(-9000, 9000) / 1000d;
            MaskBottom = cmd.GetInt16(-9000, 9000) / 1000d;
            MaskLeft = cmd.GetInt16(-16000, 16000) / 1000d;
            MaskRight = cmd.GetInt16(-16000, 16000) / 1000d;
        }
    }
}