using System.Runtime.InteropServices;
using ToyRobot.Enum;
using ToyRobot.Helper;
using ToyRobot.Model;

namespace ToyRobot.Commands
{
    public class LeftCommandExecutor : ICommandExecutor
    {
        public Command Command => Command.Left;

        public RobotLocation Operator(RobotLocation currentToyLocation, [Optional] string parameter)
        {
            currentToyLocation.Direction = currentToyLocation.Direction.Previous();

            return currentToyLocation;
        }
    }
}
