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
        public string[] wordsArray;
        public List<string> easyWords = new List<string>();
        public List<string> mediumWords = new List<string>();
        public List<string> hardWords = new List<string>();
        private string word;
        public string tempWord = "";
        public List<char> letters = new List<char>();
        public bool GameOver = false;
        public int CorrectCount = 0;
        public int IncorrectCount = 0;

        public Hangman()
        {
            wordsArray = System.IO.File.ReadAllLines(@"C:\Users\rosso1n\Documents\Dictionary.txt");

            Console.WriteLine("Welcome to Hangman! This is a one or two player game!");
            int difficulty;
            var anotherBool = true;
            do
            {
                Console.WriteLine("What difficulty? 1 - Easy, 2 - Medium, 3 - Hard");
                if(int.TryParse(Console.ReadLine(), out difficulty))
                {
                    anotherBool = false;
                }


            } while (anotherBool);

            var WhatDifficulty = DetermineDifficulty(difficulty);

            HowManyPlayers();
            SetUpAndPlay(WhatDifficulty);

            Restart();

        }     
        private void HowManyPlayers()
        {
            var usertryagain = true;

            do
            {
                Console.WriteLine("Please enter number of players");
                int.TryParse(Console.ReadLine(), out int numPlayers);

                if (numPlayers == 1 || numPlayers == 2)
                {
                   if(numPlayers == 1)
                    {
                        Console.WriteLine("One player game");
                        players = numPlayers;

                    }
                    else
                    {
                        Console.WriteLine("Two player game");
                        players = numPlayers;

                    }
                    usertryagain = false;
                }
                else
                {
                    Console.WriteLine("Try again");
                }


            } while (usertryagain);            
        }
        private void SetUpAndPlay(List<string> words)
        {

            var guessWord = "";

            if (players == 1)
            {
                Random rand = new Random();
                var rN = rand.Next(0, words.Count);
                word = words.ElementAt(rN);
                tempWord = word;
                Console.WriteLine("The computer picked a random word, player guess a letter");
                OnePlayerGame();
            }
            else
            {
                Console.WriteLine("Printing the words");
                foreach (var item in words)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();

                Console.WriteLine("Player 1 pick a word for player two to guess");
                guessWord = Console.ReadLine();

                for (int i = 0; i < words.Count; i++)
                {
                    if (words[i] == guessWord)
                    {
                        word = words[i];
                        tempWord = word;
                        break;
                    }
                    else if (words.Count - 1 == i && words[i] != guessWord)
                    {
                        Console.WriteLine("Please pick a correct word. Try again here: ");
                        guessWord = Console.ReadLine();
                    }
                }
                Console.Clear();
                Console.WriteLine("Player 1 picked a word, Player 2 guesses the word!");
                TwoPlayerGame();
            }
        }
        private void OnePlayerGame()
        {
            DisplayWordHidden();
            GuessLetter();
            DetermineWin();
            
        }
        private void TwoPlayerGame()
        {

            DisplayWordHidden();
            GuessLetter();
            DetermineWin();

        }
        private void GuessLetter()
        {
            var tempBool = true;

            if (players == 1)
            {
                
                do
                {                    

                    Console.WriteLine("Player, guess a letter! Press 1 to guess the Word!");
                    Console.WriteLine();

                    char.TryParse(Console.ReadLine(),out char guess);

                    if (word.Contains(guess))
                    {
                        Console.WriteLine("Was in the word");
                        RevealLetter(guess);
                        CorrectCount++;


                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();

                        Console.WriteLine("Letters you've guessed! You get 8 Incorrect Attempts!");
                        var temp = "";
                        foreach (var item in letters)
                        {
                            temp += item + " ";
                        }

                        Console.WriteLine(temp);
                        Console.WriteLine();

                        RevealLetter(guess);

                    }
                    else if (guess == '1')
                    {
                        Console.WriteLine("Enter the word you think is correct!");
                        var guessWord = Console.ReadLine();
                        GuessWord(guessWord);
                       
                    }
                    else
                    {
                        Console.WriteLine("That letter was not in the word, try again!");

                        IncorrectCount++;
                        letters.Add(guess);

                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();

                        Console.WriteLine("Letters you've guessed! You get 8 Incorrect Attempts!");
                        var temp = "";
                        foreach (var item in letters)
                        {
                            temp += item + " ";
                        }

                        Console.WriteLine(temp);
                        Console.WriteLine();

                        RevealLetter(guess);
                    }


                    
                    if(CorrectCount == word.Length || IncorrectCount == 8)
                    {
                        tempBool = false;
                    }



                } while (tempBool);
            }
            else
            {
                do
                {                   

                    Console.WriteLine("Player 2, guess a letter! Press 1 to guess the Word!");
                    char.TryParse(Console.ReadLine(), out char guess);

                    if (word.Contains(guess))
                    {
                        Console.WriteLine("Was in the word");
                        RevealLetter(guess);
                        CorrectCount++;

                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();

                        Console.WriteLine("Letters you've guessed! You get 8 Incorrect Attempts!");
                        var temp = "";
                        foreach (var item in letters)
                        {
                            temp += item + " ";
                        }

                        Console.WriteLine(temp);
                        Console.WriteLine();

                        RevealLetter(guess);
                    }
                    else if (guess == '1')
                    {
                        Console.WriteLine("Enter the word you think is correct!");
                        var guessWord = Console.ReadLine();
                        GuessWord(guessWord);
                    }
                    else
                    {
                        Console.WriteLine("That letter was not in the word, try again!");

                        IncorrectCount++;
                        letters.Add(guess);

                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();

                        Console.WriteLine("Letters you've guessed! You get 8 Incorrect Attempts!");
                        var temp = "";
                        foreach (var item in letters)
                        {
                            temp += item + " ";
                        }

                        Console.WriteLine(temp);
                        Console.WriteLine();

                        RevealLetter(guess);


                    }

                    if (CorrectCount == word.Length || IncorrectCount == 8)
                    {
                        tempBool = false;
                    }

                } while (tempBool);
                
            }
        }
        private void GuessWord(string input)
        {
            if(input == word)
            {
                CorrectCount = word.Length;
            }
            else
            {
                Console.WriteLine("That was not the word. You now have one less attempt!");
                IncorrectCount++;

                System.Threading.Thread.Sleep(1500);
                Console.Clear();

                Console.WriteLine("Letters you've guess!");
                Console.WriteLine();
                var temp = "";
                foreach (var item in letters)
                {
                    temp += item + " ";
                }

                Console.WriteLine(temp);
                RevealLetter(' ');
            }
        }
        private void DisplayWordHidden()
        {
            string temp = "";
            for (int i = 0; i < tempWord.Length; i++)
            {
                tempWord = tempWord.Replace(tempWord[i], '*');
            }
            Console.WriteLine(tempWord);
        }
        private void RevealLetter(char letter)
        {
            char[] tempWordArray = tempWord.ToArray();

            for (int i = 0; i < word.Length; i++)
            {
                if (letter == word[i])
                {
                    tempWordArray[i] = word[i];

                }
            }

            tempWord = string.Empty;
            foreach (var item in tempWordArray)
            {
                tempWord += item;
            }
            Console.WriteLine(tempWord);

        }
        private void DetermineWin()
        {
            if(CorrectCount == word.Length)
            {
                Console.WriteLine("Congratulations, you guessed the word!");
            } else if (IncorrectCount == 8)
            {
                Console.WriteLine("Sorry, you did not guess the word! The word was {0}", word);
            }
        }
        private List<string> DetermineDifficulty(int d)
        {
            foreach (var item in wordsArray)
            {
                if(item.Length < 6)
                {
                    easyWords.Add(item);
                } 
                else if(item.Length > 6 && item.Length < 12)
                {
                    mediumWords.Add(item);
                }
                else
                {
                    hardWords.Add(item);
                }
            }

            switch (d)
            {
                case 1:
                    {
                        Console.WriteLine("You picked Easy");
                        return easyWords;
                    }
                case 2:
                    {
                        Console.WriteLine("You picked Medium");
                        return mediumWords;
                    }
                case 3:
                    {
                        Console.WriteLine("You picked Hard");
                        return hardWords;
                    }
                default:
                    return easyWords;
            }


        }

        private void Restart()
        {            
            Console.WriteLine("Exiting the game");
            System.Threading.Thread.Sleep(2000);            
            Console.Clear();          
            Program pr = new Program();

        }









    }
}
