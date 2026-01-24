namespace MinerDomain.Interfaces.cmd
{
    public class OpenCellCommand : ICommand<Cell>
    {
        private readonly IController _controller;

        public OpenCellCommand(IController controller)
        {
            _controller = controller;
        }

        public Cell Execute()
        {
            var cell = _controller.OpenCell();
            return cell;
        }
    }
}
