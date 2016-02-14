using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MartianRobots;

namespace MartianRobotsTests
{
    class CommandStationTests
    {
        [Test]
        public void TransmitCommandSequenceTest()
        {
            //arrange
            var mocks = new Mocks();
            var robots = new List<Robot> { mocks.GetRobot() };
            var commandStation = new CommandStation(robots);

            //act
            commandStation.TransmitCommandSequence(0, mocks.GetCommandSequence());

            //assert
            var robot = commandStation.Robots[0];
            Assert.AreEqual(3, robot.X);
            Assert.AreEqual(3, robot.Y);
            Assert.AreEqual(Orientation.north, robot.Orientation);
            Assert.AreEqual(true, robot.IsLost);
        }
    }
}
