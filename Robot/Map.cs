using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot
{
    class Map
    {
        private MapLocation[,] grid;
        int _y, _x;
        public int X { get { return _x; } }
        public int Y { get { return _y; } }

        public MapLocation[,] Grid{  get { return grid; } }
        
        public Map(int x, int y)
        {
            _x = x;
            _y = y;
            grid = new MapLocation[x,y];
            generateMap();
        }
        public MapLocation this[int key1, int key2]{
            get {return grid[key1, key2];}  
            set {grid[key1, key2] = value;}
        }
        private void generateMap()
        {
            for (int i = 0; i < _x; i++) {
                for (int j = 0; j < _y; j++) {
                    if (grid[i, j] == null) {
                        grid[i, j] = new MapLocation(i, j);
                        if (grid[i, j].Content == Obstruction.Hole){
                            if (i == _x - 1 && j == _y - 1)  grid[i, j] = new MapLocation(i, j); 
                            else {
                                Random random = new Random();
                                grid[i, j].LinkedX = random.Next(0, X);
                                grid[i, j].LinkedY = random.Next(0, Y);
                                grid[grid[i, j].LinkedX, grid[i, j].LinkedY] = new MapLocation(grid[i, j]);
                            }
                        }
                    }
                }
            }
        }
        private MapLocation makeLinkHole(ref MapLocation location){
            Random random = new Random();
            location.LinkedX = random.Next(0, X);
            location.LinkedY = random.Next(0, Y);
            if (grid[location.LinkedX, location.LinkedY] == null)
                return new MapLocation(location);
            else return makeLinkHole( ref  location);
            
        }
        
    }
}
