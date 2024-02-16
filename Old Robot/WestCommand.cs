namespace Old_Robot;

public class WestCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.isPowered) robot.x += -1;
    }
}