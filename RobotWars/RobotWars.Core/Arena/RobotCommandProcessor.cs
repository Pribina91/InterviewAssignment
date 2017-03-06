using System;
using System.Configuration;
using System.Linq;
using RobotWars.Core.Robot;

namespace RobotWars.Core.Arena
{
    /// <summary>
    ///     TODO use command processors to control robots further
    /// </summary>
    public class RobotCommandProcessor
    {
        private static readonly char[] AVAILABLE_MOVE_COMMANDS = new[] {'M', 'L', 'R'};
        private IRobotArena arena { get; }
        private IRobot robot;

        public RobotCommandProcessor(IRobotArena arena)
        {
            this.arena = arena;
        }

        public void PlaceRobotInArena(string command)
        {
            if (string.IsNullOrEmpty(command))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(command));
            }

            var commandFields = command.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            if (commandFields.Length != 3)
            {
                throw new ArgumentException("Invalid format", nameof(command));
            }

            int x;
            if (!int.TryParse(commandFields[0], out x))
            {
                throw new ArgumentException("Not number ", nameof(command));
            }

            int y;
            if (!int.TryParse(commandFields[1], out y))
            {
                throw new ArgumentException("Not number ", nameof(command));
            }

            Direction direction;
            if (!Enum.TryParse(commandFields[2], false, out direction)
                || !Enum.IsDefined(typeof(Direction), direction))
            {
                throw new ArgumentException("Not enum ", nameof(command));
            }

            this.robot = new SimpleRobot(this.arena, x, y, direction);

            if (!this.arena.CheckInitPlaceInArena(this.robot))
            {
                throw new ArgumentException("Invalid placement ", nameof(command));
            }
        }

        public string MoveRobotAroundArena(string command)
        {
            if (this.robot == null)
            {
                throw new ArgumentException("Robot not placed in arena ", nameof(this.robot));
            }

            if (string.IsNullOrEmpty(command))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(command));
            }

            if (!command.All(ch => ch == 'L' || ch == 'M' || ch == 'R'))
            {
                throw new ArgumentException("Invalid command inserted.", nameof(command));
            }

            foreach (var character in command)
            {
                switch (character)
                {
                    case 'L':
                        this.robot.RotateLeft();
                        break;
                    case 'R':
                        this.robot.RotateRight();
                        break;
                    case 'M':
                        this.robot.Move();
                        break;
                }
            }

            return this.robot.ToString();
        }
    }
}