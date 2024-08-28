using LibAtem.Serialization;
using System;

namespace LibAtem.Commands.Settings.Multiview
{
    [CommandName("CMvO", CommandDirection.ToServer, 8)]
    public class MultiviewWindowOverlaySetCommand : SerializableCommandBase
    {
        // TODO - does this use a mask in byte 5?

        [CommandId]
        [Serialize(0), UInt8]
        public uint MultiviewIndex { get; set; }
        [CommandId]
        [Serialize(1), UInt8Range(0, 15)]
        public uint WindowIndex { get; set; }

        [Serialize(3), Bool(0)]
        public bool LabelVisible { get; set; }

        [Serialize(3), Bool(1)]
        public bool BorderVisible { get; set; }
    }
}