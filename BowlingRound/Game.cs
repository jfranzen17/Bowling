using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingRound
{
    public class Player
    {
        string name;
    }
    public class Game
    {
        public List<Player> playersList { get; set; } = new List<Player>(4);
        public Player activePlayer { get;private set; }
        public Game(List<string> names)
        {
            for (int i = 0; i < names.Count; i++)
            {
                Player player = new Player(names);
            }
        }
        public void Roll(int pins)
        {
            activePlayer.Round.roll(pins);
            if (pins==10)
            {
                activePlayer = playersList[]
            }
        }
    }
}
