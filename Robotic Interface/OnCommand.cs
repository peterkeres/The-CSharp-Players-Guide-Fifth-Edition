namespace Robotic_Interface;

public class OnCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.isPowered = true;
    }
}