namespace MinerDomain.Interfaces.cmd
{
    public class PlaceFlagCommand : ICommand<bool>
    {
        private readonly IController _controller;

        public PlaceFlagCommand(IController controller)
        {
            _controller = controller;
        }

        public bool Execute()
        {
            return _controller.PlaceFlag();
        }
    }
}
