using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobots
{
    public static class Input
    {
        public static void GetRobotsAndCommandSequences(String input, out List<Robot> robots, out List<List<Command>> commandSequences)
        {
            string[] lines = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            var mars = ParseMars(lines.First());
            lines = lines.Skip(1).ToArray();

            robots = new List<Robot>();
            commandSequences = new List<List<Command>>();
            for (int i = 0; i < lines.Count(); i++)
            {
                if (i % 2 == 0)
                    robots.Add(ParseRobot(lines[i], mars));
                else
                    commandSequences.Add(ParseCommandSequence(lines[i]));
            }
        }

        private static Mars ParseMars(String mars)
        {
            //5 3
            int xBound = (int)Char.GetNumericValue(mars[0]);
            int yBound = (int)Char.GetNumericValue(mars[2]);
            return new Mars(xBound, yBound);
        }

        private static Robot ParseRobot(String robot, Mars mars)
        {
            //1 1 E
            var x = (int)Char.GetNumericValue(robot[0]);
            var y = (int)Char.GetNumericValue(robot[2]);
            var orientation = GetOrientation(robot[4]);
            return new Robot(x, y, orientation, mars);
        }

        private static List<Command> ParseCommandSequence(String instruction)
        {
            //FRRFLLFFRRFLL
            var commandSequence = new List<Command>();

            foreach (var character in instruction)
                commandSequence.Add(GetCommand(character));

            return commandSequence;
        }

        private static Command GetCommand(Char command)
        {
            switch(command)
            {
                case 'F':
                    return Command.forward;
                case 'R':
                    return Command.right;
                case 'L':
                    return Command.left;
                default:
                    throw new ArgumentException($"char {command} not recognized");
            }
        }

        private static Orientation GetOrientation(Char orientation)
        {
            switch (orientation)
            {
                case 'N':
                    return Orientation.north;
                case 'E':
                    return Orientation.east;
                case 'S':
                    return Orientation.south;
                case 'W':
                    return Orientation.west;
                default:
                    throw new ArgumentException($"Char {orientation} corresonds to no known orientation");
            }
        }
    }
}
