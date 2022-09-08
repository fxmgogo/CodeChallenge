using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Enum;

namespace ToyRobot.Model
{
    public class RobotLocation
    {
        public Direction Direction;

        public Position Position;

        public RobotLocation(Direction direction, Position position)
        {
            Direction = direction;
            Position = position;
        }
    }
}
