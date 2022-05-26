using System;
namespace Game_of_life
{
    public class Game
    {
        private Villager[,] villagers;
        private int[,] consistences; //1 смерть,2 - добавление, 3 - остаться
        private int players;
   
        public SingleRandom random;


        public Game()
        {
            random = SingleRandom.getInstance();
            consistences = new int[10, 10];
            villagers = new Villager[10, 10];
            players = 0;

        }

        public void startGame()
        {
           

            Console.WriteLine("сколько групп по 3 жителя вам нужно? выберите от 1 до 33");
            int.TryParse(Console.ReadLine(), out int groupCount);
            Console.Clear();
            if (groupCount >= 1 && groupCount < 34)
            {

                createPlayers(0, 0, 0, 0, groupCount);
                 Console.ReadLine();
                while(players>0)
                {
                    move();
                }
            }
            else
            {
                Console.WriteLine("эррор");
            }

        }

        public int neighbourCount(int posX, int posY)
        {

         
                if (posY == 0 && posX < 8 && posX > 1)
                //проверко верхней стороны
                return checkSide(posX, posY);
                else

                if (posX == 0 && posY < 8 && posY > 1)
                // проверка левой стороны
                return checkSide1(posX, posY);
                else

                if (posX == 9 && posY < 8 && posY > 1)
                // проверка правой стороны
                return checkSide3(posX, posY);
                else

                if (posY == 9 &&
                   posX < 8 && posX > 1)
                return checkSide2(posX, posY);
                //проверка нижней стороны
                else

                if (posY == 0 && posX == 0)
                //проверка верхнего левого угла
                return checkAngle(posX, posY);
                else

                if (posY == 9 && posX == 0)
                //проверка нижнего левого угла
                return checkAngle1(posX, posY);
                else

                if (posY == 0 && posX == 9)
                //проверка верхнего правого угла
                return checkAngle2(posX, posY);
                else

                if (posY == 9 && posX == 9)
                //проверка нижнего правого угла
                return checkAngle3(posX, posY);
                else

                if (posY > 0 && posY <= 8
                && posX > 0 && posX <= 8)
                {
                //проверка поля, где объект не находится на краю
                return checkPole(posX, posY);
                }

            return 0;


        }

        public void move()
        {
            int neighbours = 0;
            
            for (int h = 0; h < 10; h++)
            {
                for (int l = 0; l < 10; l++)
                {
                   
                    if (villagers[h, l] == null)
                    {
                       neighbours = neighbourCount(h, l);//
                        if (neighbours==3)
                        {
                           consistences[h,l] = 2;
                        }
                       if (neighbours!=3)
                        {

                            consistences[h, l] = 3;
                        }
                    }
                    else
                    {
                        neighbours = neighbourCount(h, l);//
                        if (neighbours == 3)
                        {
                            consistences[h, l] = 3;
                        }
                        if (neighbours != 3)
                        {
                            consistences[h, l] = 1;
                        }
                    }
                }
            }
       
            for (int n = 0; n < 10; n++)
            {
                for (int t = 0; t < 10; t++)
                {
                        if (consistences[n, t] == 1)
                        {
                            villagers[n, t] = null;
                            Console.SetCursorPosition(n, t);
                            Console.Write(" ");
                            players--;
                            neighbours = 0;
                        }
                    
                        if (consistences[n, t] == 2)
                        {
                            villagers[n,t] = new Villager();
                            Console.SetCursorPosition(n, t);
                            Console.Write("@");
                            players++;
                            neighbours = 0;
                        }   
                }
            }
            consistences = new int[10, 10];
            Console.ReadLine();
        }
        public void createPlayers(int startPosX, int startPosY,int difPos, int difPos2, int groups)
        {
           
            int j = 0;

            for (int i =0; i<groups; i++)
            {
                
               
                startPosX = random.GetInt(0, 10);
                startPosY = random.GetInt(0, 10);
                villagers[startPosX, startPosY] = new Villager(startPosX, startPosY);
                Console.SetCursorPosition(startPosX, startPosY);
                Console.Write('@');
                players++;
              
                while (j!=2)
                {

                    difPos = random.GetInt(-1, 2);
                    difPos2 = random.GetInt(-1, 2);
                    while (startPosX+difPos > 9 || startPosY+difPos2 > 9|| startPosX+difPos<0|| startPosY+ difPos2 <0)
                    {
                        difPos = random.GetInt(-1, 2);
                        difPos2 = random.GetInt(-1, 2);

                    }
       

                    if (villagers[startPosX+difPos,startPosY+difPos2] == null)
                    {
                        villagers[startPosX + difPos, startPosY + difPos2] =
                         new Villager(startPosX + difPos, startPosY + difPos2);
                        Console.SetCursorPosition(startPosX + difPos, startPosY + difPos2);
                        Console.Write('@');
                        players++;
                     
                        j++;
                    }
                 
                }
                j = 0;
            }

            
            
        }

            public int checkAngle(int posX, int posY)//левый верхний
            {
            int neighbours = 0;
                if (villagers[posX + 1, posY] != null) neighbours += 1;
                if (villagers[posX + 1, posY + 1] != null) neighbours += 1;
                if (villagers[posX, posY + 1] != null) neighbours += 1;
                return neighbours;
            }
            public int checkAngle1(int posX, int posY)// левый нижний
            {
            int neighbours = 0;
            if (villagers[posX + 1, posY - 1] != null) neighbours += 1;
                if (villagers[posX + 1, posY] != null) neighbours += 1;
                if (villagers[posX, posY - 1] != null) neighbours += 1;
                return neighbours;
            }
            public int checkAngle2(int posX, int posY)//правый верхний
            {
            int neighbours = 0;
            if (villagers[posX - 1, posY] != null) neighbours += 1;
                if (villagers[posX - 1, posY + 1] != null) neighbours += 1;
                if (villagers[posX, posY + 1] != null) neighbours += 1;
                return neighbours;

            }
            public int checkAngle3(int posX, int posY)//проверка нижнего правого угла
            {
            int neighbours = 0;
            if (villagers[posX - 1, posY] != null) neighbours += 1;

                if (villagers[posX - 1, posY - 1] != null) neighbours += 1;
                if (villagers[posX, posY - 1] != null) neighbours += 1;
                return neighbours;
            }
        public int checkSide(int posX,int posY) //проверка верхней стороны
        {

            int neighbours = 0;
            if (villagers[posX + 1, posY] != null) neighbours += 1;
            if (villagers[posX + 1, posY+1] != null) neighbours += 1;
            if (villagers[posX, posY+1] != null) neighbours += 1;
            if (villagers[posX - 1, posY+1] != null) neighbours += 1;
            if (villagers[posX - 1, posY] != null) neighbours += 1;
            return neighbours;
        }
        public int checkSide1(int posX, int posY) //проверка левой
        {
            int neighbours = 0;
            if (villagers[posX, posY + 1] != null) neighbours += 1;
            if (villagers[posX, posY - 1] != null) neighbours += 1;
            if (villagers[posX + 1, posY - 1] != null) neighbours += 1;
            if (villagers[posX + 1, posY] != null) neighbours += 1;
            if (villagers[posX + 1, posY + 1] != null) neighbours += 1;
            return neighbours;
        }
        public int checkSide2(int posX, int posY) //проверка нижней стороны
        {
            int neighbours = 0;
            if (villagers[posX +1, posY -1] != null) neighbours += 1;
            if (villagers[posX - 1, posY] != null) neighbours += 1;
            if (villagers[posX, posY - 1] != null) neighbours += 1;
            if (villagers[posX-1, posY - 1] != null) neighbours += 1;
            if (villagers[posX + 1, posY ] != null) neighbours += 1;
            return neighbours;            

           
        }
        public int checkSide3(int posX, int posY) //проверка правой стороны
        {

            int neighbours = 0;
            if (villagers[posX - 1, posY - 1] != null) neighbours += 1;
            if (villagers[posX - 1, posY] != null) neighbours += 1;
            if (villagers[posX, posY - 1] != null) neighbours += 1;
            if (villagers[posX, posY + 1] != null) neighbours += 1;
            if (villagers[posX - 1, posY + 1] != null) neighbours += 1;
            return neighbours;
         
        }
        public int checkPole(int posX, int posY)// все что не находитсч на краю поля
            {
            int neighbours = 0;
            if (villagers[posX + 1, posY] != null) neighbours += 1;
                if (villagers[posX + 1, posY+1] != null) neighbours += 1;
                if (villagers[posX, posY + 1] != null) neighbours += 1;
                if (villagers[posX - 1, posY + 1] != null) neighbours += 1;
                if (villagers[posX - 1, posY] != null) neighbours += 1;
                if (villagers[posX - 1, posY - 1] != null) neighbours += 1;
                if (villagers[posX, posY - 1] != null) neighbours += 1;
                if (villagers[posX -1 , posY + 1] != null) neighbours += 1;
            return neighbours;

            
        }
    }
}
