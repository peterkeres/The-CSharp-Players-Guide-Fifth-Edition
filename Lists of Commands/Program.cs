namespace Lists_of_Commands // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Robot robot = new Robot();
            string? input;


            do
            {
                
                input = Console.ReadLine();
                if (input.ToLower() == "stop") break;
                IRobotCommand newCommand = input switch
                {
                    "on" => new OnCommand(),
                    "off" => new OffCommand(),
                    "north" => new NorthCommand(),
                    "south" => new SouthCommand(),
                    "east" => new EastCommand(),
                    "west" => new WestCommand(),
                };
                robot.Commands.Add(newCommand);
                
            } while (true);
            
            
            // for (int index = 0; index < robot.Commands.Length; index++)
            // {
            //     string? input = Console.ReadLine();
            //     IRobotCommand newCommand = input switch
            //     {
            //         "on" => new OnCommand(),
            //         "off" => new OffCommand(),
            //         "north" => new NorthCommand(),
            //         "south" => new SouthCommand(),
            //         "east" => new EastCommand(),
            //         "west" => new WestCommand(),
            //     };
            //     robot.Commands[index] = newCommand;
            // }

            Console.WriteLine();

            robot.Run();
        }
    }
}