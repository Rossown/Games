using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardShuffling
{
    class Blackjack
    {
        public Blackjack(Deck deck)
        {
            deck.PopulateDeck();
            Player player = new Player();

            Console.WriteLine("Welcome to BlackJack!");
            Console.WriteLine("Goal of the game is to reach 21 without going over! If nobody \n reachs 21 the person closest to 21 wins!");

            player.HowManyPlayers();
            deck.Deal(Program.PlayersInGame);


            
        }
    }
}
