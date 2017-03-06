namespace RobotWars.Core.Robot
{
    public interface IRobot
    {
        Direction GetDirection();
        PositionPoint GetPosition();
        void Move();
        void RotateLeft();
        void RotateRight();
    }
}