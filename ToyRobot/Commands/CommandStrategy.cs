
using System.Collections.Generic;
using System.Linq;
using ToyRobot.Enum;
using ToyRobot.Model;

namespace ToyRobot.Commands
{
    public class CommandStrategy : ICommandStrategy
    {
        private readonly IEnumerable<ICommandExecutor> _commandExecutor;
        public RobotLocation ToyLocation { get; set; }
        public CommandStrategy(IEnumerable<ICommandExecutor> commandExecutor) => _commandExecutor = commandExecutor;

        public string ExecuteCommand(Command command, string locationParameter)
        {
            if ((Command.Report == command) && (ToyLocation != null))
            {
                return $"Output: {ToyLocation.Position.X},{ToyLocation.Position.Y},{ToyLocation.Direction}";
            }

            RobotLocation location = _commandExecutor.FirstOrDefault(x => x.Command == command)?.Operator(ToyLocation, locationParameter);


            ToyLocation = location;

            return string.Empty;
        }
    }
}
