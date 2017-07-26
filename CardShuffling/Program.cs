using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CardShuffling
{
    public enum suits {
        Hearts,
        Diamonds,
        Spades,
        Clubs
    };

    class Program
    {
        public static List<Player> PlayersInGame = new List<Player>();
        public Program()
        {
            GameChoice();
        }

        static void Main(string[] args)
        {
            GameChoice();               
        }

        public static void PrintList<T>(List<T> AnyList)
        {
            foreach (T item in AnyList)
            {
                Console.WriteLine(item);
            }
        }
        
        public static void GameChoice()
        {
            Deck deck1 = new Deck();
           
            string UserTryAgain = "n";
            do
            {
                Console.WriteLine("What Game would you like to play?");
                Console.WriteLine();
                Console.WriteLine("1 - War, 2 - BlackJack, 3 - Rock, Paper, Scissors, \n4 - Tic Tac Toe, 5 - Snake, " +
                    "6 - Hangman, Any other key to Exit ");
                bool UserChoice = int.TryParse(Console.ReadLine(), out int gameChoice);

                switch (gameChoice)
                {
                    case 1:
                        Console.WriteLine("You picked War ... Starting a game of War");
                        Console.WriteLine();
                        WarGame2 war = new WarGame2(deck1);
                        UserTryAgain = "n";
                        break;
                    case 2:
                        Console.WriteLine("You picked BlackJack ... Starting a game of BlackJack");
                        Console.WriteLine();
                        Blackjack blackjack = new Blackjack(deck1);
                        UserTryAgain = "n";
                        break;
                    case 3:
                        Console.WriteLine("You picked Rock, Paper, Scissors ... Starting a game of Rock, Paper, Scissors");
                        Console.WriteLine();
                        RPS rps = new RPS();
                        UserTryAgain = "n";
                        break;
                    case 4:
                        Console.WriteLine("You picked Tic Tac Toe ... Starting a game of Tic Tac Toe");
                        Console.WriteLine();
                        TicTacToe ttt = new TicTacToe();
                        UserTryAgain = "n";
                        break;
                    case 5:
                        Console.WriteLine("You picked Snake ... Starting a game of Snake");
                        Console.WriteLine();
                        Snake snake = new Snake();
                        UserTryAgain = "n";
                        break;
                    case 6:
                        Console.WriteLine("You picked Hangman ... Starting a game of Hangman");
                        Console.WriteLine();
                        Hangman hm = new Hangman();
                        UserTryAgain = "n";
                        break;
                    default:
                        Console.WriteLine("Please pick a valid Game Number");
                        Console.WriteLine("Would you like to try again? Y or N");
                        UserTryAgain = Console.ReadLine();
                        break;
                }
            } while (UserTryAgain.ToLower() == "y");
        }
    }
    public class Player
    {
        public Player()
        {
            PlayerName = "";
            PlayerHand = new List<Card>();
            DiscardList = new List<Card>();
        }
        public string PlayerName { get; set; }

        public List<Card> PlayerHand { get; set; }


        public List<Card> DiscardList { get; set; }

        public void HowManyPlayers()
        {
            int tryAgain = 1;
            do
            {
                Console.WriteLine("How Many players?");
                if (int.TryParse(Console.ReadLine(), out int numPlayers))
                {

                    for (int i = 0; i < numPlayers; i++)
                    {
                        AddPlayersInGame(i);
                    }
                    tryAgain = 0;
                }
                else
                {
                    Console.WriteLine("Please Enter a valid Number of Players");
                }

            } while (tryAgain != 0);
        }

        public void WarHowManyPlayers()
        {
            int tryAgain = 1;
            do
            {
                Console.WriteLine("How Many players?");
                if (int.TryParse(Console.ReadLine(), out int numPlayers) && numPlayers == 2)
                {

                    for (int i = 0; i < numPlayers; i++)
                    {
                        AddPlayersInGame(i);
                    }
                    tryAgain = 0;
                }
                else
                {
                    Console.WriteLine("Please Enter a valid Number of Players of 2");
                }

            } while (tryAgain != 0);
        }

        public void AddPlayersInGame(int count)
        {
            Player player = new Player()
            {
                PlayerName = "Player " + (count + 1),
                PlayerHand = new List<Card>(),
                DiscardList = new List<Card>()
            };

            Program.PlayersInGame.Add(player);

        }

        public override string ToString()
        {
            string retval = "";

            retval = PlayerName;

            foreach (Card c in PlayerHand)
            {
                retval += ", " + c.ToString();
            }

            return retval;
        }

    }

    public class Card
    {
        private int cardFace { get; set; }
        public suits cardSuit;

        public int getCardFace()
        {
            return this.cardFace;
        }
        public Card()
        {

        }
        public Card(int x, suits y)
        {
            cardFace = x;
            cardSuit = y;
        }

        public override string ToString()
        {
            if (cardFace == 1)
            {
                return "Ace of " + cardSuit;
            }
            if (cardFace == 11)
            {
                return "Jack of " + cardSuit;
            }
            if (cardFace == 12)
            {
                return "Queen of " + cardSuit;
            }
            if (cardFace == 13)
            {
                return "King of " + cardSuit;
            }
            else
            {
                return cardFace + " of " + cardSuit;
            }

        }
    }


    public class Deck
    {

        List<Card> deck = new List<Card>();

        List<int> deckFaces = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };

        public void PopulateDeck()
        {
            int i = 0;
            int j = 0;
            int k = 0;
            int h = 0;
            foreach (int face in deckFaces)
            {
                deck.Add(new Card(deckFaces[i], suits.Hearts));
                i++;
            }
            foreach (int face in deckFaces)
            {
                deck.Add(new Card(deckFaces[j], suits.Diamonds));
                j++;
            }
            foreach (int face in deckFaces)
            {
                deck.Add(new Card(deckFaces[k], suits.Spades));
                k++;
            }
            foreach (int face in deckFaces)
            {
                deck.Add(new Card(deckFaces[h], suits.Clubs));
                h++;
            }

            Shuffle.ShuffleDeck(deck);



        }

        public void PrintDeck()
        {
            foreach (Card card in deck)
            {
                Console.WriteLine(card);
            }



        }        

        public void Deal(List<Player> PlayersInGame)
        {
            
            int messedUp = 1;
            foreach (Player player in PlayersInGame)
            {

                do
                {
                    Console.WriteLine("How many Cards go to this Player? ");
                    string line = Console.ReadLine();

                    if (int.TryParse(line, out int numCards))
                    {
                        List<Card> cardsToGoInHand = new List<Card>();

                        if (numCards == 0)
                        {
                            Console.WriteLine("No cards dealt");
                            break;
                        }
                        for (int i = 0; i < numCards; i++)
                        {
                            cardsToGoInHand.Add(deck[0]);
                            deck.RemoveAt(0);

                        }


                        foreach (Card dealCard in cardsToGoInHand)
                        {
                            Card newDealCard = dealCard;
                            player.PlayerHand.Add(newDealCard);
                        }


                        cardsToGoInHand.Clear();
                        Console.WriteLine("You now have {0} cards left in the deck.", deck.Count);
                        messedUp = 0;

                    }
                    else
                    {
                        Console.WriteLine("Please Enter a valid number between 1 and 52.");
                        messedUp = 1;

                    }
                } while (messedUp != 0);

            }
        }

        public void WarDeal(List<Player> PlayersInGame)
        {

            int messedUp = 1;
            foreach (Player player in PlayersInGame)
            {

                do
                {
                    Console.WriteLine("How many Cards go to this Player? ");
                    string line = Console.ReadLine();

                    if (int.TryParse(line, out int numCards) && numCards == 26)
                    {
                        List<Card> cardsToGoInHand = new List<Card>();

                        if (numCards == 0)
                        {
                            Console.WriteLine("No cards dealt");
                            break;
                        }
                        for (int i = 0; i < numCards; i++)
                        {
                            cardsToGoInHand.Add(deck[0]);
                            deck.RemoveAt(0);

                        }


                        foreach (Card dealCard in cardsToGoInHand)
                        {
                            Card newDealCard = dealCard;
                            player.PlayerHand.Add(newDealCard);
                        }


                        cardsToGoInHand.Clear();
                        Console.WriteLine("You now have {0} cards left in the deck.", deck.Count);
                        messedUp = 0;

                    }
                    else
                    {
                        Console.WriteLine("Please Enter a valid number of 26.");
                        messedUp = 1;

                    }
                } while (messedUp != 0);

            }
        }

        public void BlackJackDeal(List<Player> PlayersInGame)
        {

            int messedUp = 1;
            foreach (Player player in PlayersInGame)
            {

                do
                {
                    Console.WriteLine("How many Cards go to this Player? ");
                    string line = Console.ReadLine();

                    if (int.TryParse(line, out int numCards))
                    {
                        List<Card> cardsToGoInHand = new List<Card>();

                        if (numCards == 0)
                        {
                            Console.WriteLine("No cards dealt");
                            break;
                        }
                        for (int i = 0; i < numCards; i++)
                        {
                            cardsToGoInHand.Add(deck[0]);
                            deck.RemoveAt(0);

                        }


                        foreach (Card dealCard in cardsToGoInHand)
                        {
                            Card newDealCard = dealCard;
                            player.PlayerHand.Add(newDealCard);
                        }


                        cardsToGoInHand.Clear();
                        Console.WriteLine("You now have {0} cards left in the deck.", deck.Count);
                        messedUp = 0;

                    }
                    else
                    {
                        Console.WriteLine("Please Enter a valid number between 1 and 52.");
                        messedUp = 1;

                    }
                } while (messedUp != 0);

            }
        }



    }

    public static class Shuffle
    {
        public static void ShuffleDeck(List<Card> shuffleCardList)
        {
            Random ranNum = new Random();

            for (int n = shuffleCardList.Count - 1; n > 0; --n)
            {

                int k = ranNum.Next(n + 1);
                Card temp = shuffleCardList[n];
                shuffleCardList[n] = shuffleCardList[k];
                shuffleCardList[k] = temp;

            }
        }
    }

}
