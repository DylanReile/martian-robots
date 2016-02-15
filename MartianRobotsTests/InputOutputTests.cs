using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.CompareNetObjects;
using MartianRobots;

namespace MartianRobotsTests
{
    class InputOutputTests
    {
        [Test]
        public void GetMarsRobotsAndCommandSequences()
        {
            //arrange
            var input =
@"5 3
3 2 N
FRRFLLFFRRFLL
";
            var mocks = new Mocks();
            var expectedRobots = new List<Robot>() { mocks.GetRobot() };
            var expectedCommandSequences = new List<List<Command>> { mocks.GetCommandSequence() };

            //act
            List<Robot> actualRobots;
            List<List<Command>> actualCommandSequences;
            Input.GetRobotsAndCommandSequences(input, out actualRobots, out actualCommandSequences);

            //assert
            Assert.That(actualRobots, IsDeeplyEqual.To(expectedRobots));
            Assert.That(actualCommandSequences, IsDeeplyEqual.To(expectedCommandSequences));
        }

        [Test]
        public void GetRobotReport()
        {
            //arrange
            var robots = new List<Robot> { new Mocks().GetRobot() };

            //act
            var robotReport = Output.GetRobotReport(robots);

            //assert
            Assert.AreEqual("3 2 N" + Environment.NewLine, robotReport);
        }
    }
}
