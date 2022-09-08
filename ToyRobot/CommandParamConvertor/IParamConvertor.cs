using ToyRobot.Enum;
using ToyRobot.Model;

namespace ToyRobot.CommandParamConvertor
{
    public interface IParamConvertor
    {
        string[] CommandParamConvertor(string commandParam);
        Command CommandConvertor(string commandScript);
        RobotLocation LocationConvertor(string inputLocation);

    }
}
