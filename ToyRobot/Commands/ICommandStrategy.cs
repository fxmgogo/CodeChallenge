using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Enum;

namespace ToyRobot.Commands
{
    public interface ICommandStrategy
    {
        string ExecuteCommand(Command commands, string locationParameter);
    }
}
