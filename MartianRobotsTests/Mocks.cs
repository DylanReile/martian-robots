using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MartianRobots;

namespace MartianRobotsTests
{
    public class Mocks
    {
        public List<Command> GetCommandSequence()
        {
            return new List<Command>
            {
                //FRRFLLFFRRFLL
                Command.forward,
                Command.right,
                Command.right,
                Command.forward,
                Command.left,
                Command.left,
                Command.forward,
                Command.forward,
                Command.right,
                Command.right,
                Command.forward,
                Command.left,
                Command.left,
            };
        }

        public Robot GetRobot()
        {
            return new Robot(3, 2, Orientation.north, GetMars());
        }

        public Mars GetMars()
        {
            return new Mars(5, 3);
        }
    }
}
