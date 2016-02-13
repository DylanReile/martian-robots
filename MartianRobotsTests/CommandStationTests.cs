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
            var mars = new Mars(5, 3);
            var robots = new List<Robot> { new Robot(3, 2, Orientation.north, mars) };
            var commandSequence = new List<Command>
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
                Command.left
            };
            var commandStation = new CommandStation(robots);

            //act
            commandStation.TransmitCommandSequence(0, commandSequence);

            //assert
            var robot = commandStation.Robots[0];
            Assert.AreEqual(3, robot.X);
            Assert.AreEqual(3, robot.Y);
            Assert.AreEqual(Orientation.north, robot.Orientation);
            Assert.AreEqual(true, robot.IsLost);
        }
    }
}
