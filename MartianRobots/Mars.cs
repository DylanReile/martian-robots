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
        private List<Tuple<int, int>> scentedCoordinates = new List<Tuple<int, int>>();

        public Mars(int xBound, int yBound)
        {
            XBound = xBound;
            YBound = yBound;
        }
    }
}
