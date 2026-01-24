namespace MinerDomain.Interfaces.cmd
{
    public class MoveUpCommand : ICommand<bool>
    {
        private readonly IController _controller;

        public MoveUpCommand(IController controller)
        {
            _controller = controller;
        }

        public bool Execute()
        {
            return _controller.MoveUp();
        }
    }
}
