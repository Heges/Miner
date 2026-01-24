namespace MinerDomain.Interfaces.cmd
{
    public class MoveDownCommand : ICommand<bool>
    {
        private readonly IController _controller;

        public MoveDownCommand(IController controller)
        {
            _controller = controller;
        }

        public bool Execute()
        {
            var resultingCommand = _controller.MoveDown();
            return resultingCommand;
        }
    }
}
