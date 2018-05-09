using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using log4net;
using LibAtem.Commands;

namespace LibAtem.Net
{
    public class AtemClientConnection : AtemConnection
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(AtemConnection));

        private readonly List<ICommand> _queuedCommands;

        public AtemClientConnection(EndPoint endpoint, int sessionId) : base(endpoint, sessionId)
        {
            _queuedCommands = new List<ICommand>();
        }

        public override void QueueCommand(ICommand command)
        {
            lock (_queuedCommands)
            {
                _queuedCommands.Add(command);
            }
        }

        protected override OutboundMessage CompileNextMessage()
        {
            lock (_queuedCommands)
            {
                if (!_queuedCommands.Any())
                    return null;

                var builder = new OutboundMessageBuilder();

                int removeCount = 0;
                foreach (ICommand cmd in _queuedCommands)
                {
                    byte[] data = cmd.ToByteArray();
                    if (!builder.TryAddData(data))
                        break;

                    //Log.DebugFormat("{0} - Sending command {1} with content {2}", Endpoint, CommandNameAttribute.GetName(cmd.GetType()), BitConverter.ToString(data));
                    
                    removeCount++;
                }

                _queuedCommands.RemoveRange(0, removeCount);
                return builder.Create();
            }
        }

        public bool HasQueuedOutbound()
        {
            lock (_queuedCommands)
                return _queuedCommands.Any();
        }
    }

}