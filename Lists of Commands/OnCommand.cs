namespace Lists_of_Commands;

public class OnCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.isPowered = true;
    }
}