using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot
{
    public enum Obstruction{
        None,
        Rock,
        Hole,
        Spinner 
}
     class MapLocation{
         int _y, _x, _linkedY, _linkedX;

         public int LinkedX
         {
             get { return _linkedX; }
             set { _linkedX = value; }
         }

         public int LinkedY
         {
             get { return _linkedY; }
             set { _linkedY = value; }
         }
        protected Obstruction _content;

        public Obstruction Content { get { return _content; }  }

        public int X { get { return _x; } }
        public int Y { get { return _y; } }
        

        public MapLocation(int x, int y)
        {
            _x = x;
            _y = y;
            Random random = new Random();
            _content = (Obstruction)random.Next(0, 4);
        }
        public MapLocation(MapLocation location)
        {
            _x = location._linkedX;
            _y = location._linkedY;
            _linkedX = location._x;
            _linkedY = location._y;
            _content = Obstruction.Hole;
        }
    }
}
