namespace LibAtem.Commands
{
    [CommandName("_top")]
    public class TopologyCommand : ICommand
    {
        public uint MixEffectBlocks { get; set; }
        public uint VideoSources { get; set; }
        public uint ColorGenerators { get; set; }
        public uint Auxiliaries { get; set; }
        public uint MediaPlayers { get; set; }
        public uint SerialPort { get; set; }
        public uint HyperDecks { get; set; }
        public uint DVE { get; set; }
        public uint Stingers { get; set; }
        public uint SuperSource { get; set; }

        public void Serialize(CommandBuilder cmd)
        {
            cmd.AddUInt8(MixEffectBlocks);
            cmd.AddUInt8(VideoSources);
            cmd.AddUInt8(ColorGenerators);
            cmd.AddUInt8(Auxiliaries);
            cmd.AddByte(0x00); // Constants
            cmd.AddUInt8(MediaPlayers);
            cmd.AddUInt8(SerialPort);
            cmd.AddUInt8(HyperDecks);
            cmd.AddUInt8(DVE);
            cmd.AddUInt8(Stingers);
            cmd.AddUInt8(SuperSource);
            cmd.AddByte(0x01, 0x00, 0x01, 0x01); // Constants
            cmd.AddUInt8(0); // ???
            cmd.AddUInt8(0); // ???
            cmd.AddByte(0x01); // Constants
            cmd.Pad(2);
        }

        public void Deserialize(ParsedCommand cmd)
        {
            MixEffectBlocks = cmd.GetUInt8();
            VideoSources = cmd.GetUInt8();
            ColorGenerators = cmd.GetUInt8();
            Auxiliaries = cmd.GetUInt8();

            cmd.Skip();

            MediaPlayers = cmd.GetUInt8();
            SerialPort = cmd.GetUInt8();
            HyperDecks = cmd.GetUInt8();
            DVE = cmd.GetUInt8();
            Stingers = cmd.GetUInt8();
            SuperSource = cmd.GetUInt8();

            cmd.Skip(4);
            cmd.GetUInt8(); // ???
            cmd.GetUInt8(); // ???
            cmd.Skip(2);
        }
    }
}