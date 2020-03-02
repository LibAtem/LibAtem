using System;
using System.Collections.Generic;

namespace LibAtem.State
{
    [Serializable]
    public class MacroState
    {
        public IReadOnlyList<ItemState> Pool { get; set; } = new List<ItemState>();

        public RecordStatusState RecordStatus { get; } = new RecordStatusState();
        public RunStatusState RunStatus { get; } = new RunStatusState();

        public enum MacroRunStatus
        {
            Idle,
            Running,
            UserWait,
        }
        
        [Serializable]
        public class RecordStatusState
        {
            public bool IsRecording { get; set; }
            public uint RecordIndex { get; set; }
        }

        [Serializable]
        public class RunStatusState
        {
            public MacroRunStatus RunStatus { get; set; }
            public uint RunIndex { get; set; }
            public bool Loop { get; set; }
        }
        
        [Serializable]
        public class ItemState
        {
            public bool IsUsed { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }
    }
}