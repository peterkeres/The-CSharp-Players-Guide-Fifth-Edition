namespace Robotic_Interface;

public class Robot
{
    public int x { get; set; }
    public int y { get; set; }
    public bool isPowered { get; set; }
    public IRobotCommand?[] Commands { get; } = new IRobotCommand?[3];

    public void Run()
    {
        foreach (IRobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{x} {y} {isPowered}]");
        }
    }


}