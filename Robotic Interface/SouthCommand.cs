namespace Robotic_Interface;

public class SouthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.isPowered) robot.y += -1;
    }
}