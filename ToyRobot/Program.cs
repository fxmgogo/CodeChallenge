
using ToyRobot.Commands;
using ToyRobot.CommandParamConvertor;
using ToyRobot.Robot;
using ToyRobot.TableTops;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
            //.AddLogging()
            .AddSingleton<ICommandExecutor, LeftCommandExecutor>()
            .AddSingleton<ICommandExecutor, MoveCommandExecutor>()
            .AddSingleton<ICommandExecutor, PlaceCommandExecutor>()
            .AddSingleton<ICommandExecutor, RightCommandExecutor>()
            .AddSingleton<ICommandStrategy, CommandStrategy>()
            .AddSingleton<IParamConvertor, ParamConvertor>()
            .AddSingleton<IRobotControl, RobotControl>()
            .AddSingleton<ITableTop>(x => new TableTop(5, 5))
            .BuildServiceProvider();

var processor = serviceProvider.GetService<IRobotControl>();

const string caption = @"Please enter the command to the following format: 
                                    1. PLACE X,Y,FACING : To initiate the robot 
                                    2. MOVE             : To move the robot 
                                    3. RIGHT            : To move the robot right side 
                                    4. LEFT             : To move the robot left side 
                                    5. REPORT           : To get robot current location ";

Console.WriteLine(caption);
while (true)
{
    var input = Console.ReadLine();
    if (input != null && input.Equals("exit", StringComparison.OrdinalIgnoreCase))
    {
        break;
    }
    try
    {
        var response = processor.ExecuteCommand(input);

        if (!string.IsNullOrEmpty(response))
            Console.WriteLine(response);
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }
}
