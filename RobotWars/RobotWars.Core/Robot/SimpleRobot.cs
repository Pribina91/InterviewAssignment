using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using RobotWars.Core.Arena;

namespace RobotWars.Core.Robot
{
    public class SimpleRobot : BaseRobot
    {
        public SimpleRobot(IRobotArena arena, int x, int y, Direction direction) : base(arena)
        {
            if (x < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(x));
            }
            if (y < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(y));
            }
            if (!Enum.IsDefined(typeof(Direction), direction))
            {
                throw new InvalidEnumArgumentException(nameof(direction), (int)direction, typeof(Direction));
            }

            this.Position = new PositionPoint(x, y);
            this.Direction = direction;
        }
    }
}