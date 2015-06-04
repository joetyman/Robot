using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot
{
    class Robot
    {
        enum direction
        {
            FORWARD,
            RIGHT,
            BACKWARD,
            LEFT
        }
        direction _currentDirection;
        int _x, _y;
        string _commands;
        MapLocation _currentLocation;
        Map _map;
        public Robot(string commands, Map map){
            _commands = commands;
            _map= map;
            _currentDirection = direction.FORWARD;
        }
        public void TransverseMap()
        {
            Console.WriteLine("The robot is starting at {0}, {1}. ", _x, _y);
            foreach(char direction in _commands){
                if (direction == 'l') {
                    progressCommand(_x, _y-1);
                } else if (direction == 'r') {
                    progressCommand( _x, _y + 1);
                } else if (direction == 'f') {
                    progressCommand( _x+1, _y);
                } else{
                    Console.WriteLine("Couldn't proccess command" + direction); 
                    break;
                }
            }
            Console.WriteLine("The robot has finished at {0}, {1}. ", _x, _y);
        }
        private void progressCommand( int newX, int newY)
        {
            if(checkSpace(newX, newY)){
                _currentLocation = _map[newX, newY];
                inspectLocation();
            } else{
                Console.WriteLine("Coordinates {0}, {1} are off known map ", newX, newY);
            }
        }
        private void moveSpace()
        {
            switch (_currentDirection) {
                case direction.FORWARD:
                    progressCommand(_x +1 , _y);
                    break;
                case direction.BACKWARD:
                    progressCommand(_x - 1, _y);
                    break;
                case direction.RIGHT:
                    progressCommand(_x, _y+1);
                    break;
                case direction.LEFT:
                    progressCommand(_x, _y - 1);
                    break;
            }
        }
        private bool checkSpace(int x, int y)
        {
            if (x < 0 || y < 0) return false;
            if (x >= _map.X || y >= _map.Y) return false;
            return true;
        }
        private void inspectLocation()
        {
            switch (_currentLocation.Content)
            {
                case Obstruction.None:
                    _x = _currentLocation.X;
                    _y = _currentLocation.Y;
                    break;
                case Obstruction.Rock:
                    Console.WriteLine("The robot ran into a rock at location {0}, {1}. ", _currentLocation.X, _currentLocation.Y);
                    break;
                case Obstruction.Hole:
                    Console.WriteLine("The robot fell into a hole at location {0}, {1}. ", _currentLocation.X, _currentLocation.Y);
                    _x = _currentLocation.LinkedX;
                    _y = _currentLocation.LinkedY;
                    Console.WriteLine("The robot is now located {0}, {1}. ", _x, _y);
                    break;
                case Obstruction.Spinner:
                    Console.WriteLine("The robot got stuck in a spinner at location {0}, {1}. ", _currentLocation.X, _currentLocation.Y);
                    turnRobot('s');
                    break;
                default:
                    Console.WriteLine("The robot ran into an unknown obstruction at location {0}, {1}. ", _currentLocation.X, _currentLocation.Y);
                    break;
            }
        }
        private void turnRobot(char inputDirection)
        {
            if (inputDirection == 'l')
            {
                findDirection(-1);
            }
            else if (inputDirection == 'r')
            {
                findDirection(1);
            }
            else
            {
                Random random = new Random();
                _currentDirection = (direction)random.Next(0, 4);
            }

        }
        private void findDirection(int modifier)
        {
            int newdirection = (int)_currentDirection + modifier;
            if (newdirection == 4)
            {
                _currentDirection = (direction)0;
            }
            else if (newdirection == -1)
            {
                _currentDirection = (direction)3;
            }
            else
            {
                _currentDirection = (direction)newdirection;
            }
        }
        
    }

}
