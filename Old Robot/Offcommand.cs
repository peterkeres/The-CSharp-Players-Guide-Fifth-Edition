namespace Old_Robot;

public class OffCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.isPowered = false;
    }
}