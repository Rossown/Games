using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardShuffling
{
    enum Choice
    {
        rock = 1,
        paper = 2,
        scissors = 3
    }
    class RPS
    {

        private int computerTotal;
        private int userTotal;
        public RPS()
        {
            Console.WriteLine("");
            Console.WriteLine("Welcome to Rock, Paper, Scissors!");

            play();

            Console.WriteLine("Done playing Rock, Paper, Scissors");

            Program pr = new Program();
                        
        }

        public void play()
        {
            int goAgain = 1;
            do
            {

                int user = UserChoice();
                int computer = ComputerChoice();
                Winner(user, computer);
                Console.WriteLine("Would you like to go again? 1 - Yes 0 - No");
                goAgain = int.Parse(Console.ReadLine());
                Console.WriteLine();

            } while (goAgain == 1);

            FinalWinner(userTotal, computerTotal);
        }

        public int UserChoice()
        {
            int goAgain = 0;
            int retval = 0;
            do
            {
                Console.WriteLine("1 - Rock, 2 - Paper, or 3 - Scissors?");
                var userChoice = Console.ReadLine();
                Console.WriteLine();
                if (userChoice.ToLower() == Choice.rock.ToString().ToLower() || int.Parse(userChoice) == Choice.rock.GetHashCode())
                {
                    Console.WriteLine("You picked {0}", Choice.rock);
                    goAgain = 1;
                    retval = Choice.rock.GetHashCode();
                }
                else if (userChoice.ToLower() == Choice.paper.ToString().ToLower() || int.Parse(userChoice) == Choice.paper.GetHashCode())
                {
                    Console.WriteLine("You picked {0}", Choice.paper);
                    goAgain = 1;
                    retval = Choice.paper.GetHashCode();
                }
                else if (userChoice.ToLower() == Choice.scissors.ToString().ToLower() || int.Parse(userChoice) == Choice.scissors.GetHashCode())
                {
                    Console.WriteLine("You picked {0}", Choice.scissors);
                    goAgain = 1;
                    retval = Choice.scissors.GetHashCode();
                }
                else
                {
                    Console.WriteLine("Please pick a valid option");
                }

            } while (goAgain == 0);

            return retval;
        }

        public int ComputerChoice()
        {
            Random computer = new Random();
            int cc = computer.Next(1, 4);
            int retval = 0;
            if (cc == Choice.rock.GetHashCode())
            {
                Console.WriteLine("Computer picked {0}", Choice.rock);
                retval = Choice.rock.GetHashCode();
            }
            else if (cc == Choice.paper.GetHashCode())
            {
                Console.WriteLine("Computer picked {0}", Choice.paper);
                retval = Choice.paper.GetHashCode();
            }
            else if (cc == Choice.scissors.GetHashCode())
            {
                Console.WriteLine("Computer picked {0}", Choice.scissors);
                retval =  Choice.scissors.GetHashCode();
            }

            return retval;
            
        }

        public void Winner(int u, int c)
        {
            Console.WriteLine();
            if (u == 3 && c == 1)
            {
                Console.WriteLine("Computer Wins!");
                computerTotal++;
            }
            else if (u > c)
            {
                Console.WriteLine("Player Wins!");
                userTotal++;
            }
            
            if(c == 3 && u == 1)
            {
                Console.WriteLine("Player Wins!");
                userTotal++;
            }
            else if (c > u)
            {
                Console.WriteLine("Computer Wins!");
                computerTotal++;
            }

            if( u == c)
            {
                Console.WriteLine("Tie!");
            }
        }

        public void FinalWinner(int u, int c)
        {
            Console.WriteLine("Player Final Score is {0} - Computer Final Score is {1}", userTotal, computerTotal);
            if (u > c)
            {
                Console.WriteLine("Player is the Final Winner!");
            } else if( c > u)
            {
                Console.WriteLine("Computer is the Final Winner!");
            }
            else
            {
                Console.WriteLine("Nobody wins ... It's a Tie!");
            }
        }
    }
}
