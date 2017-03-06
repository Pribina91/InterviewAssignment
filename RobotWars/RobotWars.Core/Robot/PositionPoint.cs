namespace RobotWars.Core.Robot
{
    public class PositionPoint
    {
        public PositionPoint(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; }
        public int Y { get; }
    }
}