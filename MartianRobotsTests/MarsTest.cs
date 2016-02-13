using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MartianRobots;

namespace MartianRobotsTests
{
    public class MarsTest
    {
        [TestCase(Command.forward, 0, 1, Orientation.north)]
        [TestCase(Command.right, 0, 0, Orientation.east)]
        [TestCase(Command.left, 0, 0, Orientation.west)]
        public void Commands(Command command, int x, int y, Orientation orientation)
        {
            //arrange
            var mars = new Mars(5, 3);
            var robot = new Robot(0, 0, Orientation.north, mars);

            //act
            robot.ExecuteCommand(command);

            //assert
            Assert.AreEqual(x, robot.X);
            Assert.AreEqual(y, robot.Y);
            Assert.AreEqual(orientation, robot.Orientation);
        }
    }
}
