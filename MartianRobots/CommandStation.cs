using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobots
{
    public class CommandStation
    {
        public List<Robot> Robots { get; private set; }

        public CommandStation(List<Robot> robots)
        {
            Robots = robots;
        }

        public void TransmitCommandSequence(int robotIndex, List<Command> commandSequence)
        {
            foreach (var command in commandSequence)
                Robots[robotIndex].ExecuteCommand(command);
        }
    }
}
