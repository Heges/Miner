namespace MinerDomain.Interfaces.cmd
{
    public class MoveLefttCommand : ICommand<bool>
    {
        private readonly IController _controller;

        public MoveLefttCommand(IController controller)
        {
            _controller = controller;
        }

        public bool Execute()
        {
            return _controller.MoveLeft();
        }
    }
}
