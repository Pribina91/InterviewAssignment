using RobotWars.Core.Robot;

namespace RobotWars.Core.Arena
{
    public interface IRobotArena
    {
        bool CheckInitPlaceInArena(IRobot robot);
        bool CanRobotMoveHere(int x, int y);
    }
}