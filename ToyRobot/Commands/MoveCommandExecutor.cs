using System.Runtime.InteropServices;
using ToyRobot.Enum;
using ToyRobot.Helper;
using ToyRobot.Model;
using ToyRobot.TableTops;

namespace ToyRobot.Commands
{
    public class MoveCommandExecutor : ICommandExecutor
    {
        private readonly ITableTop toyTable;
        public Command Command => Command.Move;

        public MoveCommandExecutor(ITableTop toyTable)
        {
            this.toyTable = toyTable;
        }

        public RobotLocation Operator(RobotLocation currentToyLocation, [Optional] string parameter)
        {
            var nextPosition = new Position(currentToyLocation.Position.X, currentToyLocation.Position.Y);
            switch (currentToyLocation.Direction)
            {
                case Direction.East:
                    nextPosition.X += 1;
                    break;
                case Direction.West:
                    nextPosition.X -= 1;
                    break;
                case Direction.North:
                    nextPosition.Y += 1;
                    break;
                case Direction.South:
                    nextPosition.Y -= 1;
                    break;
            }

            if (toyTable.MovetoNextPosition(nextPosition))
            {
                currentToyLocation.Position = nextPosition;
            }

            return currentToyLocation;
        }
    }
}
