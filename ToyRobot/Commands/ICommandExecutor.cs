using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Enum;
using ToyRobot.Model;

namespace ToyRobot.Commands
{
    public interface ICommandExecutor
    {
        Command Command { get; }
        RobotLocation Operator(RobotLocation currentToyLocation, [Optional] string parameter);
    }
}
