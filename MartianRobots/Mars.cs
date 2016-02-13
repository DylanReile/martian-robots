using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobots
{
    public class Mars
    {
        private int _xBound;
        private int _yBound;
        private List<Tuple<int, int>> scentedCoordinates = new List<Tuple<int, int>>();

        public Mars(int xBound, int yBound)
        {
            _xBound = xBound;
            _yBound = yBound;
        }
    }
}
