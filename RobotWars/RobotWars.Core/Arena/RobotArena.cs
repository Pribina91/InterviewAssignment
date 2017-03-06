using System;
using System.Collections.Generic;
using System.Linq;
using RobotWars.Core.Robot;

namespace RobotWars.Core.Arena
{
    public class RobotArena : IRobotArena
    {
        private List<IRobot> robots;
        private int arenaWidth;
        private int arenaHeight;

        public RobotArena(IRobotArenaFactory factory)
        {
            this.arenaHeight = factory.GetHeight();
            this.arenaWidth = factory.GetWidth();

            this.robots = new List<IRobot>();
        }

        public bool CheckInitPlaceInArena(IRobot robot)
        {
            if (robot == null)
            {
                throw new ArgumentNullException(nameof(robot));
            }

            //Check robot location inside arena
            var position = robot.GetPosition();
            if (!CanRobotMoveHere(position.X, position.Y))
            {
                return false;
            }

            this.robots.Add(robot);
            return true;
        }

        public bool CanRobotMoveHere(int x, int y)
        {
            //Block moves outside of arena
            if (x > arenaWidth
                || x < 0)
            {
                return false;
            }

            if (y > arenaHeight
                || y < 0)
            {
                return false;
            }

            //TODo block occupied places by other robots
            //if (this.robots.Any(r => r.GetPosition().X == x && r.GetPosition().Y == y))
            //{
            //    return false;
            //}

            return true;
        }
    }
}