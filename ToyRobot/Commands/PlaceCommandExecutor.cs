using System.Runtime.InteropServices;
using ToyRobot.CommandParamConvertor;
using ToyRobot.Enum;
using ToyRobot.Model;
using ToyRobot.TableTops;

namespace ToyRobot.Commands
{
    public class PlaceCommandExecutor : ICommandExecutor
    {
        private readonly IParamConvertor parameterConvertor;
        private readonly ITableTop toyTable;
        public Command Command => Command.Place;

        public PlaceCommandExecutor(IParamConvertor parameterConvertor, ITableTop toyTable)
        {
            this.parameterConvertor = parameterConvertor;
            this.toyTable = toyTable;
        }

        public RobotLocation Operator(RobotLocation currentToyLocation, [Optional] string parameter)
        {
            var intputParameters = parameterConvertor.CommandParamConvertor(parameter);

            var location = parameterConvertor.LocationConvertor(intputParameters.Last());

            if (!toyTable.MovetoNextPosition(location.Position))
            {
                return currentToyLocation;
            }
            var toyLocation = new RobotLocation(location.Direction, location.Position);

            return new RobotLocation(toyLocation.Direction, toyLocation.Position);
        }
    }
}
