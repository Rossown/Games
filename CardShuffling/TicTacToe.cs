using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardShuffling
{
    class TicTacToe
    {
        List<string> board = new List<string> { "1","2","3","4","5","6","7","8","9" };
        string player1 = "X";
        string player2 = "O";

        bool winner = false;

        int turn = 0;
        public TicTacToe()
        {
            Play();

            Console.WriteLine("Done Playing Tic Tac Toe");

            Program pr = new Program();
        }

        public void Play()
        {
            for (int i = 0; i < board.Count; i++)
            {
                if (winner == false)
                {
                    MakeBoard();
                    Turn();
                    Winner();
                }
                else
                {

                    break;
                }
            }
            MakeBoard();
        }

        public void Turn()
        {
            if(turn % 2 == 0)
            {
                Console.WriteLine("Enter a number to Change to X");
                board[int.Parse(Console.ReadLine()) - 1] = player1;
                turn++;
            }
            else
            {
                Console.WriteLine("Enter a number to Change to O");
                board[int.Parse(Console.ReadLine()) - 1] = player2;
                turn++;
            }
        }

        public void MakeBoard()
        {
            int j = 0;
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("     |    |    ");
                Console.WriteLine(" {0}   | {1}  |  {2}", board[j++], board[j++], board[j++]);
                Console.WriteLine(" ----|----|----");

            }
        }

        public void Winner()
        {
              CheckHorizontal();
                CheckVertically();
                CheckDiagonallyTopLeft();
                CheckDiagonallyTopRight();

        }

        public void CheckHorizontal()
        {
            int s = 0;
            for (int i = 0; i < 3; i++)
            {
                
                if (board.ElementAt(s) == "X" && board.ElementAt(s+1) == "X" )
                {
                    if (board.ElementAt(s + 2) == "X")
                    {
                        Console.WriteLine();
                        Console.WriteLine("Player 1 Wins!");
                        Console.WriteLine();
                        winner = true;
                    }

                }
                else if (board.ElementAt(s) == "O" && board.ElementAt(s + 1) == "O")
                {
                    if (board.ElementAt(s + 2) == "O")
                    {
                        Console.WriteLine();
                        Console.WriteLine("Player 2 Wins!");
                        Console.WriteLine();
                        winner = true;
                    }
                }
                else
                {

                }
                s+=3;
            }
            
             
        }

        public void CheckVertically()
        {
            int s = 0;
            for (int i = 0; i < 3; i++)
            {
                if (board.ElementAt(s) == "X" && board.ElementAt(s+3) == "X")
                {
                    if (board.ElementAt(s + 6) == "X")
                    {
                        Console.WriteLine();
                        Console.WriteLine("Player 1 Wins!");
                        Console.WriteLine();
                        winner = true;
                    }
                }
                else if (board.ElementAt(s) == "O" && board.ElementAt(s+3) == "O")
                {
                    if (board.ElementAt(s + 6) == "O")
                    {
                        Console.WriteLine();
                        Console.WriteLine("Player 2 Wins!");
                        Console.WriteLine();
                        winner = true;
                    }
                }
                else
                {

                }
                s++;
            }
        }

        public void CheckDiagonallyTopLeft()
        {
            int s = 0;

            if (board.ElementAt(0) == "X" && board.ElementAt(4) == "X")
            {
                if (board.ElementAt(8) == "X")
                {
                    Console.WriteLine();
                    Console.WriteLine("Player 1 Wins!");
                    Console.WriteLine();
                    winner = true;
                }
            }
            else if (board.ElementAt(0) == "O" && board.ElementAt(4) == "O")
            {
                if (board.ElementAt(8) == "O")
                {
                    Console.WriteLine();
                    Console.WriteLine("Player 2 Wins!");
                    Console.WriteLine();
                    winner = true;
                }
            }
            else
            {
            }
        }
        public void CheckDiagonallyTopRight()
        {
            if (board.ElementAt(2) == "X" && board.ElementAt(4) == "X")
            {
                if (board.ElementAt(6) == "X")
                {
                    Console.WriteLine();
                    Console.WriteLine("Player 1 Wins!");
                    Console.WriteLine();
                    winner = true;
                }
            }
            else if (board.ElementAt(2) == "O" && board.ElementAt(4) == "O")
            {
                if (board.ElementAt(6) == "O")
                {
                    Console.WriteLine();
                    Console.WriteLine("Player 2 Wins!");
                    Console.WriteLine();
                    winner = true;
                }
            }
            else
            {
            }
        }
    }

    
}
