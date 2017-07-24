using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardShuffling
{
    class Snake
    {       

        public Snake()
        {

            int[] xPos = new int[100];
            int[] yPos = new int[100];
            xPos[0] = (35);
            yPos[0] = (20);

            int appleX = 0;
            int appleY = 0;

            bool isGameOn = true;
            bool isWallHit = false;
            bool isAppleEaten = false;

            int applesEaten = 0;
            int gameSpeed = 150;

            Console.CursorVisible = false;
            Console.Clear();

            Console.SetCursorPosition(xPos[0], yPos[0]);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine((char)214);

            BuildWall();
            SetApplePosition(out appleX, out appleY);
            PaintApple(appleX, appleY);

            ConsoleKey command = Console.ReadKey().Key;           

            do
            {                
                switch (command)
                {
                    case ConsoleKey.LeftArrow:
                        Console.SetCursorPosition(xPos[0], yPos[0]);
                        Console.Write(" ");
                        xPos[0]--;
                        break;

                    case ConsoleKey.UpArrow:
                        Console.SetCursorPosition(xPos[0], yPos[0]);
                        Console.Write(" ");
                        yPos[0]--;
                        break;

                    case ConsoleKey.RightArrow:
                        Console.SetCursorPosition(xPos[0], yPos[0]);
                        Console.Write(" ");
                        xPos[0]++;
                        break;

                    case ConsoleKey.DownArrow:
                        Console.SetCursorPosition(xPos[0], yPos[0]);
                        Console.Write(" ");
                        yPos[0]++;
                        break;

                }



                isWallHit = DidSnakeHitWall(xPos[0], yPos[0]);
                

                if (isWallHit)
                {
                    isGameOn = false;
                    Console.SetCursorPosition(28, 20);
                    Console.WriteLine("The snake hit the wall and died.");
                }

                isAppleEaten = DidSnakeHitApple(appleX, appleY, xPos[0], yPos[0]);


                if (isAppleEaten)
                {
                    applesEaten++;
                    PaintSnake(applesEaten, xPos, yPos, out xPos, out yPos);
                    SetApplePosition(out appleX, out appleY);
                    PaintApple(appleX, appleY);                    
                }
                else
                {
                    Console.SetCursorPosition(xPos[0], yPos[0]);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine((char)214);
                }

                if (Console.KeyAvailable)
                {
                    command = Console.ReadKey().Key;
                }
                
                System.Threading.Thread.Sleep(gameSpeed);
                

            } while (isGameOn);


            


        }

        private void PaintSnake(int applesEaten, int[] xPosIn, int[] yPosIn, out int[] xPosOut, out int[] yPosOut)
        {
            Console.SetCursorPosition(xPosIn[0], yPosIn[0]);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine((char)214);

            for (int i = 1; i < applesEaten + 1; i++)
            {
                
                Console.SetCursorPosition(xPosIn[i], yPosIn[i]);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("o");
            }

            Console.SetCursorPosition(xPosIn[applesEaten + 1], yPosIn[applesEaten + 1]);
            Console.WriteLine(" ");

            for (int i = applesEaten + 1; i > 1; i--)
            {
                xPosIn[i] = xPosIn[i - 1];
                yPosIn[i] = yPosIn[i - 1];
            }

            xPosOut = xPosIn;
            yPosOut = yPosIn;
        }

        private bool DidSnakeHitWall(int xPos, int yPos)
        {
            if (xPos == 1 || xPos == 70 || yPos == 1 || yPos == 40)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        private void BuildWall()
        {
            for (int i = 1; i < 41; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(1, i);
                Console.Write("#");
                Console.SetCursorPosition(70, i);
                Console.Write("#");
            }

            for (int i = 1; i < 71; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(i, 1);
                Console.Write("#");
                Console.SetCursorPosition(i, 40);
                Console.Write("#");
            }
        }

        private void SetApplePosition(out int appleX, out int appleY)
        {
            Random rand = new Random();
            appleX = rand.Next(2, 68);
            appleY = rand.Next(2, 38);
        }
       
        private void PaintApple(int appleX, int appleY)
        {
            Console.SetCursorPosition(appleX, appleY);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine((char)64);
        }
       
        private bool DidSnakeHitApple(int appleX, int appleY, int xPos, int yPos)
        {
            if(xPos == appleX && yPos == appleY)
            {
                return true;
            }
            else
            {
                return false;
            }
        }




    }
}
