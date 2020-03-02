using System;
using System.Collections.Generic;
using LibAtem.Common;

namespace LibAtem.Commands.Audio
{
    [CommandName("AMLv", CommandDirection.ToClient), NoCommandId]
    public class AudioMixerLevelsCommand : ICommand
    {
        public AudioMixerLevelsCommand()
        {
            Inputs = new List<AudioMixerLevelInput>();
        }

        public double MasterLeftLevel { get; set; }
        public double MasterRightLevel { get; set; }
        public double MasterLeftPeak { get; set; }
        public double MasterRightPeak { get; set; }

        public double MonitorLeftLevel { get; set; }
        public double MonitorRightLevel { get; set; }
        public double MonitorLeftPeak { get; set; }
        public double MonitorRightPeak { get; set; }

        public List<AudioMixerLevelInput> Inputs { get; set; }

        private static double GetValue(ParsedByteArray cmd)
        {
            return Math.Log10(cmd.GetUInt32() / (128 * 65536d)) * 20;
        }

        private static void PutValue(ByteArrayBuilder cmd, double val)
        {
            cmd.AddUInt32((uint) (Math.Pow(10, val / 20d) * 128 * 65536d));
        }
        
        public void Serialize(ByteArrayBuilder cmd)
        {
            cmd.AddUInt16(Inputs.Count);
            cmd.AddUInt16(Inputs.Count); // TODO - this could be a padding which just happens to be the same most of the time

            PutValue(cmd, MasterLeftLevel);
            PutValue(cmd, MasterRightLevel);
            PutValue(cmd, MasterLeftPeak);
            PutValue(cmd, MasterRightPeak);

            PutValue(cmd, MonitorLeftLevel);
            PutValue(cmd, MonitorRightLevel);
            PutValue(cmd, MonitorLeftPeak);
            PutValue(cmd, MonitorRightPeak);

            foreach (AudioMixerLevelInput input in Inputs)
                cmd.AddUInt16((uint) input.Source);
            cmd.PadToNearestMultipleOf4();

            foreach (AudioMixerLevelInput input in Inputs)
            {
                PutValue(cmd, input.LeftLevel);
                PutValue(cmd, input.RightLevel);
                PutValue(cmd, input.LeftPeak);
                PutValue(cmd, input.RightPeak);
            }
        }

        public void Deserialize(ParsedByteArray cmd)
        {
            uint inputCount = cmd.GetUInt16();
            cmd.Skip(2);

            MasterLeftLevel = GetValue(cmd);
            MasterRightLevel = GetValue(cmd);
            MasterLeftPeak = GetValue(cmd);
            MasterRightPeak = GetValue(cmd);

            MonitorLeftLevel = GetValue(cmd);
            MonitorRightLevel = GetValue(cmd);
            MonitorLeftPeak = GetValue(cmd);
            MonitorRightPeak = GetValue(cmd);

            Inputs = new List<AudioMixerLevelInput>((int) inputCount);
            for (int i = 0; i < inputCount; i++)
                Inputs.Add(new AudioMixerLevelInput((AudioSource) cmd.GetUInt16()));
            cmd.SkipToNearestMultipleOf4();

            foreach (AudioMixerLevelInput input in Inputs)
            {
                input.LeftLevel = GetValue(cmd);
                input.RightLevel = GetValue(cmd);
                input.LeftPeak = GetValue(cmd);
                input.RightPeak = GetValue(cmd);
            }
        }
    }

    public class AudioMixerLevelInput
    {
        public AudioMixerLevelInput(AudioSource src)
        {
            Source = src;
        }

        public AudioSource Source { get; }

        public double LeftLevel { get; set; }
        public double RightLevel { get; set; }

        public double LeftPeak { get; set; }
        public double RightPeak { get; set; }
    }
}