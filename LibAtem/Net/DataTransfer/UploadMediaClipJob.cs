using System;
using System.Collections.Generic;
using LibAtem.Commands;
using LibAtem.Commands.Media;
using LibAtem.Util.Media;

namespace LibAtem.Net.DataTransfer
{
    public class UploadMediaClipJob : DataTransferJob
    {
        private readonly string _name;
        private readonly IReadOnlyList<AtemFrame> _frames;
        private readonly Action<bool> _onComplete;
        private int _completedFrames;
        private UploadMediaFrameJob _currentFrame;
        private uint _id;

        public uint ClipIndex => StoreId - 1;

        // TODO - handle timeout during command execution
        public UploadMediaClipJob(uint index, string name, IReadOnlyList<AtemFrame> frames, Action<bool> onComplete, TimeSpan? timeout = null)
            : base(index + 1, timeout)
        {
            _name = name;
            _frames = frames;
            _onComplete = onComplete;
            _completedFrames = 0;
        }

        public override ICommand Start(uint transferID)
        {
            StartedAt = DateTime.Now;
            if (StartedAt >= ExpiresAt)
                return null;

            _id = transferID;

            return new MediaPoolClearClipCommand {Index = ClipIndex};
        }

        public override DataTransferStatus OnMessage(ICommand command, AtemConnection connection)
        {
            if (_currentFrame != null)
            {
                DataTransferStatus r = _currentFrame.OnMessage(command, connection);
                switch (r)
                {
                    case DataTransferStatus.OK:
                        return DataTransferStatus.OK;
                    case DataTransferStatus.Unknown:
                        //_onComplete(false);
                        return DataTransferStatus.Unknown;
                }
            } else if (command.GetType() != typeof(MediaPoolClipDescriptionCommand)) // TODO - check the command values match
                return DataTransferStatus.OK;

            // status was success, or is first frame
            if (_completedFrames >= _frames.Count)
            {
                connection.QueueCommand(new MediaPoolSetClipCommand()
                {
                    Index = ClipIndex,
                    Name = _name,
                    Frames = (uint) _frames.Count,
                });

                _onComplete(true);
                return DataTransferStatus.Success;
            }

            int index = _completedFrames++;
            AtemFrame nextFrame = _frames[index];
            _currentFrame = new UploadMediaFrameJob(StoreId, (uint) index, nextFrame, b => { });
            ICommand cmd = _currentFrame.Start((uint) (_id + index+5)); // TODO - proper id
            connection.QueueCommand(cmd);
            return DataTransferStatus.OK;
        }
        
        public override void Fail()
        {
            _onComplete(false);
        }
    }
}