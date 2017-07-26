using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardShuffling
{
    class Hangman
    {
        public int players;
        public string[] words = { "dog", "computer","monitor","ocean", "coffee", "lemonade","University","charlevoix" };
        private string word;
        public List<string> letters = new List<string>();
        public Hangman()
        {
            Console.WriteLine("Welcome to Hangman! This is a one or two player game!");

            var usertryagain = false;


            do
            {
                Console.WriteLine("Please enter number of players");
                int.TryParse(Console.ReadLine(), out int numPlayers);

                if (numPlayers == 1 || numPlayers == 2)
                {
                    switch (numPlayers)
                    {
                        case 1:
                            Console.WriteLine("One player game");
                            players = numPlayers;
                            usertryagain = true;
                            OnePlayerGame();
                            break;
                        case 2:
                            Console.WriteLine("Two player game");
                            players = numPlayers;
                            usertryagain = true;
                            TwoPlayerGame();
                            break;
                        default:
                            Console.WriteLine("Try again");
                            break;
                    }
                }
                else
                {
                    usertryagain = false;
                }


            } while (!usertryagain);

        }

        private void OnePlayerGame()
        {
            SetUp();
            
        }

        private void TwoPlayerGame()
        {

            SetUp();
            
            
        }

        private void SetUp()
        {
            Console.WriteLine("Printing the words");
            foreach (var item in words)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            var guessWord = "";
            if(players == 1)
            {
                Random rand = new Random();
                var rN = rand.Next(0, words.Length);
                guessWord = words[rN];
            }
            else
            {
                Console.WriteLine("Player 1 pick a word for player two to guess");
                guessWord = Console.ReadLine();

                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i] == guessWord)
                    {
                        word = words[i];
                        break;
                    }
                    else if (words.Length - 1 == i && words[i] != guessWord)
                    {
                        Console.WriteLine("Please pick a correct word. Try again here: ");
                        guessWord = Console.ReadLine();
                    }
                }
                
                Console.WriteLine();
            }

            Console.Clear();
        }

        private void CheckGuessedLetter(char letter)
        {
            
        }
        private void GuessLetter(string word)
        {
            if(players == 1)
            {
                Console.WriteLine("The computer picked a random word, player guess a letter");
                var guess = Console.ReadLine();
                letters.Add(guess);
            }
            else
            {
                Console.WriteLine("Player 1 picked a word, player two guess a letter");
                var guess = Console.ReadLine();
                letters.Add(guess);
            }
        }

    }
}
