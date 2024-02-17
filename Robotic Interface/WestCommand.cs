namespace Robotic_Interface;

public class WestCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.isPowered) robot.x += -1;
    }
}