using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.CommandParamConvertor;
using ToyRobot.Commands;

namespace ToyRobot.Robot
{
    public class RobotControl : IRobotControl
    {
        private readonly IParamConvertor _parameterConvertor;
        private readonly ICommandStrategy _commandStrategy;


        public RobotControl(IParamConvertor parameterConvertor, ICommandStrategy commandStrategy)
        {
            _parameterConvertor = parameterConvertor;
            _commandStrategy = commandStrategy;
        }

        public string ExecuteCommand(string inputParameter)
        {
            var input = inputParameter.Split(' ').FirstOrDefault();
            var command = _parameterConvertor.CommandConvertor(input);

            var result = _commandStrategy.ExecuteCommand(command, inputParameter);

            return result;
        }
    }
}
