using System;
using RobotWars.Core.Arena;

namespace RobotWars.Core.Robot
{
    public abstract class BaseRobot : IRobot
    {
        private readonly IRobotArena _arena;
        protected PositionPoint Position;
        protected Direction Direction;

        protected BaseRobot(IRobotArena arena)
        {
            _arena = arena;
        }

        public void Move()
        {
            int newX;
            int newY;

            switch (Direction)
            {
                case Direction.N:
                    newX = this.Position.X;
                    newY = this.Position.Y + 1;
                    break;
                case Direction.E:
                    newX = this.Position.X + 1;
                    newY = this.Position.Y;
                    break;
                case Direction.S:
                    newX = this.Position.X;
                    newY = this.Position.Y - 1;
                    break;
                case Direction.W:
                    newX = this.Position.X - 1;
                    newY = this.Position.Y;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            //TODO start attack if other robot is present 

            //move is skipped if its not possible
            if (this._arena.CanRobotMoveHere(newX, newY))
            {
                Position = new PositionPoint(newX, newY);
            }
        }

        public void RotateLeft()
        {
            switch (Direction)
            {
                case Direction.N:
                    this.Direction = Direction.W;
                    break;
                case Direction.E:
                    this.Direction = Direction.N;
                    break;
                case Direction.S:
                    this.Direction = Direction.E;
                    break;
                case Direction.W:
                    this.Direction = Direction.S;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void RotateRight()
        {
            switch (Direction)
            {
                case Direction.N:
                    this.Direction = Direction.E;
                    break;
                case Direction.E:
                    this.Direction = Direction.S;
                    break;
                case Direction.S:
                    this.Direction = Direction.W;
                    break;
                case Direction.W:
                    this.Direction = Direction.N;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public Direction GetDirection()
        {
            return this.Direction;
        }

        public PositionPoint GetPosition()
        {
            return this.Position;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", this.Position.X, this.Position.Y, this.Direction);
        }
    }
}