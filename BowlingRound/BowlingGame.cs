using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingRound
{
    public class BowlingGame
    {
        public List<Player> playersList { get; set; } = new List<Player>(4);

        int numOfPlayers = 0;

        public void HowManyPlayers(int numOfPlayers)
        {
            for (int i = 0; i < numOfPlayers; i++)
            {
                Player player = new Player();
            }
        }
        public void SetNameForPlayers(Player name)
        {
            for (int i = 0; i < numOfPlayers; i++)
            {
                player[i]
            }
        }
    }
    private int PlayGame()
        {
            var game = new BowlingGame();
            
        }

}