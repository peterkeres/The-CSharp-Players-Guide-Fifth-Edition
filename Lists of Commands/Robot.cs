namespace Lists_of_Commands;

public class Robot
{
    public int x { get; set; }
    public int y { get; set; }
    public bool isPowered { get; set; }
    public List<IRobotCommand>? Commands { get; } = new List<IRobotCommand>();

    public void Run()
    {
        foreach (IRobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{x} {y} {isPowered}]");
        }
    }


}