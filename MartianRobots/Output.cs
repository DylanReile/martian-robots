using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobots
{
    public static class Output
    {
        public static String GetRobotReport(List<Robot> robots)
        {
            var s = new StringBuilder();

            foreach(var robot in robots)
            {
                var line = $"{robot.X} {robot.Y} {GetOrientation(robot.Orientation)}";
                if (robot.IsLost)
                    line += " LOST";
                s.AppendLine(line);
            }

            return s.ToString();
        }

        private static char GetOrientation(Orientation orientation)
        {
            switch(orientation)
            {
                case Orientation.north:
                    return 'N';
                case Orientation.south:
                    return 'S';
                case Orientation.east:
                    return 'E';
                case Orientation.west:
                    return 'W';
                default:
                    throw new ArgumentException($"orientation {orientation} has no defined char equivalent");
            }
        }
    }
}
