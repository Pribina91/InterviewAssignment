using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars.Core.Arena
{
    public class SimpleRobotArenaFactory : IRobotArenaFactory
    {
        private readonly int _width;
        private readonly int _height;

        public SimpleRobotArenaFactory(int width, int height)
        {
            _width = width;
            _height = height;
        }

        public int GetWidth()
        {
            return this._width;
        }

        public int GetHeight()
        {
            return this._height;
        }
    }
}