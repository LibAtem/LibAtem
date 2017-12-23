using System.Collections.Generic;
using System.Linq;
using System.Net;
using LibAtem.Commands;

namespace LibAtem.Net
{
    public class AtemClientConnection : AtemConnection
    {
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
                if (_queuedCommands.Any())
                    return CompileQueuedUpdateMessage(_queuedCommands);
            }

            return base.CompileNextMessage();
        }

        private static OutboundMessage CompileQueuedUpdateMessage(List<ICommand> commands)
        {
            var builder = new OutboundMessageBuilder();

            int removeCount = 0;
            foreach (ICommand cmd in commands)
            {
                if (!builder.TryAddCommand(cmd))
                    break;
                    
                removeCount++;
            }

            commands.RemoveRange(0, removeCount);
            return builder.Create();
        }
    }

}