using System;
namespace Game_of_life
{
    public class SingleRandom
    {

        private static SingleRandom random;
        protected Random randomGenerator {get; private set;}

        public SingleRandom()
        {
            randomGenerator = new Random();
        }
        public static SingleRandom getInstance()
        {
            if (random == null)
            {
                random = new SingleRandom();
                
            }
            return random;
        }
        public int GetInt(int x, int y)
        {
            
            return randomGenerator.Next(x, y);

        }
        public int GetInt(int x)
        {
            return randomGenerator.Next(x);
        }
        public int GetInt()
        {
            
            return randomGenerator.Next();

        }
        public double GetDouble()
        {
            return randomGenerator.NextDouble();

        }

    }
}
