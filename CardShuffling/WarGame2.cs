using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardShuffling
{
    class WarGame2
    {
        private List<Card> WinnersCards = new List<Card>();


        public WarGame2(Deck deck)
        {
            deck.PopulateDeck();
            Player player = new Player();

            Console.WriteLine("Lets play War! 26 Cards go to Each Player!");
            Console.WriteLine();
            player.WarHowManyPlayers();

            deck.WarDeal(Program.PlayersInGame);

            Play(Program.PlayersInGame);

            

            Console.WriteLine("\n" + "END");


            Program pr = new Program();
        }

        public void Play(List<Player> players)
        {
            int _COUNT = Counter(Program.PlayersInGame[0].PlayerHand, Program.PlayersInGame[1].PlayerHand);
            if (!IsMT(Program.PlayersInGame[0].PlayerHand) && !IsMT(Program.PlayersInGame[1].PlayerHand))
            {
                for (int i = 0; i < _COUNT; i++)
                {
                    if (IsMT(Program.PlayersInGame[0].PlayerHand) || IsMT(Program.PlayersInGame[1].PlayerHand))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\n" + " Round {0}", (i + 1));

                        Card P1Card = PlayCard(Program.PlayersInGame[0].PlayerHand);
                        Card P2Card = PlayCard(Program.PlayersInGame[1].PlayerHand);                         

                        DetermineWinnerAndMoveCards(P1Card, P2Card);
                    }
                    
                }

            }
            PrintDiscardAndPlayerHandCounts();
            Console.WriteLine("press enter to continue");
            Console.ReadLine();
            FinalWinnerIfEmpty(players);

        }
        public void PrintDiscardAndPlayerHandCounts()
        {
            Console.WriteLine();
            Console.WriteLine(Program.PlayersInGame[0].PlayerName + "' Hand Count =   " + Program.PlayersInGame[0].PlayerHand.Count);
            Console.WriteLine(Program.PlayersInGame[0].PlayerName + "' Discard Count =   " + Program.PlayersInGame[0].DiscardList.Count);
            Console.WriteLine();
            Console.WriteLine(Program.PlayersInGame[1].PlayerName + "' Hand Count =  " + Program.PlayersInGame[1].PlayerHand.Count);
            Console.WriteLine(Program.PlayersInGame[1].PlayerName + "' Discard Count =   " + Program.PlayersInGame[1].DiscardList.Count);

        }
        public Card PlayCard(List<Card> PlayerHandPlayCard)
        {
            Card tempCard = new Card();

            tempCard = PlayerHandPlayCard.ElementAt(0);
            Console.WriteLine(tempCard.ToString());
            PlayerHandPlayCard.RemoveAt(0);

            return tempCard;
        }
        public void RemoveCard(List<Player> PlayerHandRemoveCard)
        {
            foreach (var player in PlayerHandRemoveCard)
            {
                player.PlayerHand.RemoveAt(0);
            }
        }
        public void DetermineWinnerAndMoveCards(Card P1Card, Card P2Card)
        {
            if(P1Card.getCardFace() > P2Card.getCardFace())
            {
                Console.WriteLine("Player 1 is the Winner");
                WinnersListAdd(P1Card, P2Card);
                AddWinnersListToPlayersDiscardList(WinnersCards, Program.PlayersInGame[0]);
                WinnersCards.Clear();
            }
            else if (P1Card.getCardFace() < P2Card.getCardFace())
            {
                Console.WriteLine("Player 2 is the Winner");
                WinnersListAdd(P1Card, P2Card);
                AddWinnersListToPlayersDiscardList(WinnersCards, Program.PlayersInGame[1]);
                WinnersCards.Clear();
            }
            else
            {
                Console.WriteLine("SAME CARD");
                WinnersListAdd(P1Card, P2Card);

                int stupidCounter1 = Program.PlayersInGame[0].PlayerHand.Count;
                int stupidCounter2 = Program.PlayersInGame[1].PlayerHand.Count;

                if (stupidCounter1 > 2 && stupidCounter2 > 2 )
                {
                    Console.WriteLine("Forfeiting next card");
                    RemoveCard(Program.PlayersInGame);

                    P1Card = PlayCard(Program.PlayersInGame[0].PlayerHand);
                    P2Card = PlayCard(Program.PlayersInGame[1].PlayerHand);


                    DetermineWinnerAndMoveCards(P1Card, P2Card);
                }
                else
                {
                    FinalWinnerDuringWar(P1Card, P2Card);
                    
                }
            }
        }
        public void FinalWinnerIfEmpty(List<Player> players)
        {
            ReFillDeck(Program.PlayersInGame);
            if (!IsMT(Program.PlayersInGame[0].PlayerHand) && !IsMT(Program.PlayersInGame[1].PlayerHand))
            {
                Shuffle.ShuffleDeck(Program.PlayersInGame[0].PlayerHand);
                Shuffle.ShuffleDeck(Program.PlayersInGame[1].PlayerHand);
                Play(players);
            }
            else
            {
                if (IsMT(Program.PlayersInGame[0].PlayerHand))
                {
                    Console.WriteLine("Player 1 ran out of cards");
                    Console.WriteLine("Player 2 Wins! Player 1 Loses");
                }
                else if (IsMT(Program.PlayersInGame[1].PlayerHand))
                {
                    Console.WriteLine("Player 2 ran out of cards");
                    Console.WriteLine("Player 1 Wins! Player 2 Loses");
                }

                Console.ReadKey();

            }
        }
        public void FinalWinnerDuringWar(Card P1Card, Card P2Card)
        {
            ReFillDeck(Program.PlayersInGame);

            if (IsMT(Program.PlayersInGame[0].PlayerHand) || IsMT(Program.PlayersInGame[1].PlayerHand))
            {

                if (IsMT(Program.PlayersInGame[0].PlayerHand))
                {
                    Console.WriteLine("Player 1 ran out of cards");
                    Console.WriteLine("Player 2 Wins! Player 1 Loses");
                }
                else if (IsMT(Program.PlayersInGame[1].PlayerHand))
                {
                    Console.WriteLine("Player 2 ran out of cards");
                    Console.WriteLine("Player 1 Wins! Player 2 Loses");
                }
                Console.ReadKey();
            }
            else
            {
                Shuffle.ShuffleDeck(Program.PlayersInGame[0].PlayerHand);
                Shuffle.ShuffleDeck(Program.PlayersInGame[1].PlayerHand);

                WinnersListAdd(Program.PlayersInGame[0].PlayerHand[0], Program.PlayersInGame[1].PlayerHand[0]);
                Program.PlayersInGame[0].PlayerHand.RemoveAt(0); 
                Program.PlayersInGame[1].PlayerHand.RemoveAt(0);



                P1Card = Program.PlayersInGame[0].PlayerHand[0];
                P2Card = Program.PlayersInGame[1].PlayerHand[0];

                Console.WriteLine(P1Card.ToString());
                Console.WriteLine(P2Card.ToString());

                DetermineWinnerAndMoveCards(P1Card, P2Card);
            }
        }
        public void WinnersListAdd(Card P1, Card P2)
        {
            WinnersCards.Add(P1);
            WinnersCards.Add(P2);
        }
        public int Counter(List<Card> Cardlist1, List<Card> Cardlist2)
        {
            int retval = 0;
            if(Cardlist1.Count > Cardlist2.Count)
            {
                retval = Cardlist2.Count;
            }
            else if(Cardlist1.Count < Cardlist2.Count)
            {
                retval = Cardlist1.Count;
            }
            else
            {
                retval = Cardlist1.Count;
            }
            return retval;
        }
        public bool IsMT(List<Card> CardList)
        {
            bool retval = false;

            if(CardList.Count == 0)
            {
                retval = true;
            }

            return retval;
        }
        public void ReFillDeck(List<Player> players)
        {

            foreach (Player player in players)
            {
                foreach (Card discardCard in player.DiscardList)
                {
                    player.PlayerHand.Add(discardCard);
                }                
                player.DiscardList.Clear();
                Console.WriteLine();
            }

        }
        public void AddWinnersListToPlayersDiscardList(List<Card> winners, Player player)
        {
            foreach (var card in winners)
            {
                player.DiscardList.Add(card);
            }
        }



    }
}
