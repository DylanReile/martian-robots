using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobots
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input =
@"5 3
1 1 E
RFRFRFRF
3 2 N
FRRFLLFFRRFLL
0 3 W
LLFFFLFLFL";
            List<Robot> robots;
            List<List<Command>> commandSequences;
            Input.GetRobotsAndCommandSequences(input, out robots, out commandSequences);

            var commandStation = new CommandStation(robots);
            for(int i=0; i<commandStation.Robots.Count(); i++)
                commandStation.TransmitCommandSequence(i, commandSequences[i]);

            var robotReport = Output.GetRobotReport(robots);
            Console.Write(robotReport);

            Console.ReadKey();
        }
    }
}
