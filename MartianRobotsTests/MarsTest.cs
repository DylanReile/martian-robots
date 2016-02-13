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
        [TestCase(Command.right, 1, Orientation.east)]
        [TestCase(Command.right, 2, Orientation.south)]
        [TestCase(Command.right, 3, Orientation.west)]
        [TestCase(Command.right, 4, Orientation.north)]
        [TestCase(Command.left, 1, Orientation.west)]
        [TestCase(Command.left, 2, Orientation.south)]
        [TestCase(Command.left, 3, Orientation.east)]
        [TestCase(Command.left, 4, Orientation.north)]
        public void Reorientation(Command command, int timesRotate, Orientation orientation)
        {
            //arrange
            var mars = new Mars(5, 3);
            var robot = new Robot(0, 0, Orientation.north, mars);

            //act
            for(int i=0; i<timesRotate; i++)
                robot.ExecuteCommand(command);

            //assert
            Assert.AreEqual(orientation, robot.Orientation);
            Assert.AreEqual(0, robot.X);
            Assert.AreEqual(0, robot.Y);
        }

        [TestCase(Orientation.north, 1, 2)]
        [TestCase(Orientation.south, 1, 0)]
        [TestCase(Orientation.east, 2, 1)]
        [TestCase(Orientation.west, 0, 1)]
        public void DirectionalMovement(Orientation orientation, int x, int y)
        {
            //arrange
            var mars = new Mars(5, 3);
            var robot = new Robot(1, 1, orientation, mars);

            //act
            robot.ExecuteCommand(Command.forward);

            //assert
            Assert.AreEqual(x, robot.X);
            Assert.AreEqual(y, robot.Y);
        }

        [TestCase(Orientation.north, 3, true, TestName = "LostInTheNorth")]
        [TestCase(Orientation.north, 2, false, TestName = "EdgeOfTheNorth")]
        [TestCase(Orientation.east, 5, true, TestName ="LostInTheEast")]
        [TestCase(Orientation.east, 4, false, TestName = "EdgeOfTheEast")]
        [TestCase(Orientation.south, 2, true, TestName = "LostInTheSouth")]
        [TestCase(Orientation.south, 1, false, TestName = "EdgeOfTheSouth")]
        [TestCase(Orientation.west, 2, true, TestName = "LostInTheWest")]
        [TestCase(Orientation.west, 1, false, TestName = "EdgeOfTheWest")]
        public void Boundaries(Orientation orientation, int timesForward, bool shouldBeLost)
        {
            //arrange
            var mars = new Mars(5, 3);
            var robot = new Robot(1, 1, orientation, mars);

            //act
            for(int i=0; i<timesForward; i++)
                robot.ExecuteCommand(Command.forward);

            //assert
            Assert.AreEqual(shouldBeLost, robot.IsLost);
        }

        [Test]
        public void ReportLastPositionIfFallenOff()
        {
            //arrange
            var mars = new Mars(5, 3);
            var lostRobot = new Robot(5, 3, Orientation.north, mars);

            //act
            lostRobot.ExecuteCommand(Command.forward);
            lostRobot.ExecuteCommand(Command.forward);

            //assert
            //lost robot's position should be the last one if had before falling off
            Assert.AreEqual(5, lostRobot.X);
            Assert.AreEqual(3, lostRobot.Y);
        }

        [Test]
        public void SniffForScentsBeforeFallingOff()
        {
            //arrange
            var mars = new Mars(5, 3);
            var lostRobot = new Robot(5, 3, Orientation.north, mars);
            var savedRobot = new Robot(5, 3, Orientation.north, mars);

            //act
            lostRobot.ExecuteCommand(Command.forward);
            savedRobot.ExecuteCommand(Command.forward);

            //assert
            Assert.AreEqual(true, lostRobot.IsLost);
            Assert.AreEqual(false, savedRobot.IsLost);
        }
    }
}
