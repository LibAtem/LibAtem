using System.Collections.Generic;
using LibAtem.Common;

namespace LibAtem.Commands.DeviceProfile
{
    [CommandName("_DVE", CommandDirection.ToClient), NoCommandId]
    public class DVEConfigCommand : ICommand
    {
        public bool CanRotate { get; set; }
        public bool CanScaleUp { get; set; }

        public IReadOnlyList<DVEEffect> SupportedTransitions { get; set; }

        public void Serialize(ByteArrayBuilder cmd)
        {
            cmd.AddBoolArray(CanRotate);
            cmd.AddBoolArray(CanScaleUp);

            cmd.AddUInt16(SupportedTransitions?.Count ?? 0);
            if (SupportedTransitions != null)
            {
                foreach (DVEEffect effect in SupportedTransitions)
                    cmd.AddUInt8((uint) effect);
            }

            cmd.PadToNearestMultipleOf4();
        }

        public void Deserialize(ParsedByteArray cmd)
        {
            CanRotate = cmd.GetBoolArray()[0];
            CanScaleUp = cmd.GetBoolArray()[0];

            uint length = cmd.GetUInt16();
            var entries = new List<DVEEffect>();
            for (int i = 0; i < length; i++)
                entries.Add((DVEEffect) cmd.GetUInt8());
            SupportedTransitions = entries;

            cmd.SkipToNearestMultipleOf4();
        }
    }
}