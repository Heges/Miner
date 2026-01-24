using MinerDomain;
using MinerDomain.Interfaces;
using MinerDomain.Interfaces.cmd;

namespace Miner.Services.Handlers
{
    public class OpenCellCommandHandler : ICommandHandler<OpenCellCommand, Cell>
    {
        public Cell Handle(OpenCellCommand command)
        {
            return command.Execute();
        }
    }
}
