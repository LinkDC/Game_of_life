using System;
namespace Game_of_life
{
    public class Villager
    {

        public int neighbours { get; set; }
        public int positionX { get; set; }
        public int positionY { get; set; }
        public bool alive { get; set; }
        public bool old { get; set; }
     

        public Villager()
        {
            
            alive = true;
            positionX = 0;
            positionY = 0;
            old = false;

        }
        public Villager(int _positionX, int _positionY)
        {
            positionX = _positionX;
            positionY = _positionY;
            

        }

      
    }
}
