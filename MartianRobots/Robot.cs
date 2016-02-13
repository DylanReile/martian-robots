using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobots
{
    public class Robot
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Orientation Orientation { get; private set;}
        public bool IsLost { get; private set; }
        private Mars _mars;

        public Robot(int x, int y, Orientation orientation, Mars mars)
        {
            X = x;
            Y = y;
            Orientation = orientation;
            _mars = mars;
        }

        public void ExecuteCommand(Command command)
        {
            switch(command)
            {
                case Command.forward:
                    MoveForward();
                    CheckIfLost();
                    break;
                case Command.right:
                    RotateClockwise();
                    break;
                case Command.left:
                    RotateCounterclockwise();
                    break;
                default:
                    throw new ArgumentException($"Command {command} not recognized");
            }
        }

        private void MoveForward()
        {
            if (Orientation == Orientation.north)
                Y++;
            else if (Orientation == Orientation.east)
                X++;
            else if (Orientation == Orientation.south)
                Y--;
            else if (Orientation == Orientation.west)
                X--;
        }

        private void RotateClockwise()
        {
            //since the ints backing our enums are in order
            //adding one is equivalent to rotating 90' clockwise
            if (Orientation == Orientation.west)
                Orientation = Orientation.north;
            else
                Orientation++;
        }

        private void RotateCounterclockwise()
        {
            //since the ints backing our enums are in order
            //substracting one is equivalent to rotating 90' counterclockwise
            if (Orientation == Orientation.north)
                Orientation = Orientation.west;
            else
                Orientation--;
        }

        private void CheckIfLost()
        {
            if(X > _mars.XBound || X < 0 || Y > _mars.YBound || Y < 0)
            {
                IsLost = true;
            }
        }
    }
}
