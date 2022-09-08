using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Model;

namespace ToyRobot.TableTops
{
    public class TableTop : ITableTop
    {
        public readonly int Width;
        public readonly int Depth;

        public TableTop(int width, int depth)
        {
            Width = width;
            Depth = depth;
        }

        //detect the next position is available or not
        public bool MovetoNextPosition(Position nextPosition) => nextPosition.Y > -1 && nextPosition.Y < Depth && nextPosition.X > -1 && nextPosition.X < Width;

    }
}
