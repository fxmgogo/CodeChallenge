using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Enum;
using ToyRobot.Model;

namespace ToyRobot.CommandParamConvertor
{
    public class ParamConvertor : IParamConvertor
    {
        public string[] CommandParamConvertor(string commandParam)
        {
            if (string.IsNullOrEmpty(commandParam))
            {
                throw new ArgumentException("command parameter can not be null or empty");
            }

            var parameers = commandParam.Split(' ');
            if (parameers.Length != 2)
            {
                throw new ArgumentException("Invalid command format, pass the valid input format, Example: PLACE X,Y,F");
            }
            return parameers;
        }

        public RobotLocation LocationConvertor(string inputLocation)
        {
            var locationParameers = inputLocation.Split(',');
            if (locationParameers.Length != 3)
            {
                throw new ArgumentException("Invalid input format, pass the valid input format, Example: PLACE X,Y,F");
            }

            var location = inputLocation.Split(',');

            if (!int.TryParse(location[0], out int x))
            {
                throw new ArgumentException($"Invalid X parameter {location[0]}, please pass the valid integer value between [0-5].");
            }

            if (!int.TryParse(location[1], out int y))
            {
                throw new ArgumentException($"Invalid Y parameter {location[1]}, please pass the valid integer value between [0-5].");
            }
            var position = new Position(x, y);

            var directionString = location.Last();
            if (!System.Enum.TryParse(directionString, true, out Direction direction))
                throw new ArgumentException($"Invalid direction {directionString}. Pass the valid directions: NORTH or SOUTH or EAST or WEST");

            return new RobotLocation(direction, position);
        }

        public Command CommandConvertor(string commandScript)
        {
            if (string.IsNullOrWhiteSpace(commandScript))
            {
                throw new ArgumentException("Input command can not be null or empty");
            }

            if (!System.Enum.TryParse(commandScript, true, out Command command))
            {
                throw new ArgumentException("Invalid command. Pass the valid input command, Example: PLACE or MOVE or LEFT or RIGHT or REPORT");
            }

            return command;
        }
    }
}
