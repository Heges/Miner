namespace MinerDomain.Interfaces.cmd
{
    public class OpenCellCommandHandler : ICommandHandler<OpenCellCommand, Cell>
    {
        public Cell Handle(OpenCellCommand command)
        {
            return command.Execute();
        }
    }
}
