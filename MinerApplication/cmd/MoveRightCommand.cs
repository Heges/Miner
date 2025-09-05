namespace MinerDomain.Interfaces.cmd
{
    public class MoveRightCommand : ICommand<bool>
    {
        private readonly IController _controller;

        public MoveRightCommand(IController controller)
        {
            _controller = controller;
        }

        public bool Execute()
        {
            return _controller.MoveRight();
        }
    }
}
