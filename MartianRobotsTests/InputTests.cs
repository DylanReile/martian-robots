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
    class InputTests
    {
        [Test]
        public void GetMarsRobotsAndCommandSequences()
        {
            //arrange
            var input =
@"5 3
3 2 N
FRRFLLFFRRFLL";
            var mocks = new Mocks();
            var expectedMars = mocks.GetMars();
            var expectedRobots = new List<Robot>() { mocks.GetRobot() };
            var expectedCommandSequences = new List<List<Command>> { mocks.GetCommandSequence() };

            //act
            Mars actualMars;
            List<Robot> actualRobots;
            List<List<Command>> actualCommandSequences;
            new Input().GetMarsRobotsAndCommandSequences(input, out actualMars, out actualRobots, out actualCommandSequences);

            //assert
            Assert.That(actualMars, IsDeeplyEqual.To(expectedMars));
            Assert.That(actualRobots, IsDeeplyEqual.To(expectedRobots));
            Assert.That(actualCommandSequences, IsDeeplyEqual.To(expectedCommandSequences));
        }
    }
}
