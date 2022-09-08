using System.Runtime.InteropServices;
using ToyRobot.Enum;
using ToyRobot.Helper;
using ToyRobot.Model;

namespace ToyRobot.Commands
{
    public class RightCommandExecutor : ICommandExecutor
    {
        public Command Command => Command.Right;

        public RobotLocation Operator(RobotLocation currentToyLocation, [Optional] string parameter)
        {
            currentToyLocation.Direction = currentToyLocation.Direction.Next();
            
            return currentToyLocation;
        }
    }
}
