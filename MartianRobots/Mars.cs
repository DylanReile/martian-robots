using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobots
{
    public class Mars
    {
        public int XBound { get; }
        public int YBound { get;  }
        private List<Coordinate> _scentedCoordinates  = new List<Coordinate>();

        public Mars(int xBound, int yBound)
        {
            XBound = xBound;
            YBound = yBound;
        }

        public void AddScentedCoordinate(int x, int y)
        {
            _scentedCoordinates.Add(new Coordinate(x, y));
        }

        public bool IsScented(int x, int y)
        {
            return _scentedCoordinates.Contains(new Coordinate(x, y));
        }
    }
}
