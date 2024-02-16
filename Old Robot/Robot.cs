namespace Old_Robot;

public class Robot
{
    public int x { get; set; }
    public int y { get; set; }
    public bool isPowered { get; set; }
    public RobotCommand?[] Commands { get; } = new RobotCommand?[3];

    public void Run()
    {
        foreach (RobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{x} {y} {isPowered}]");
        }
    }


}