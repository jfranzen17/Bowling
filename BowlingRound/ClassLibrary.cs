using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Player
    {
        public string name;
        public int score;
    }

    public class BowlingWithPeople

    {
        public List<Player> PlayerList = new List<Player>();
        public Player CurrentPlayer;

        public List<Player> StartGame(int numberOfPlayers)
        {
            var listOfPlayers = PlayerList;

            for (int i = 0; i < numberOfPlayers; i++)
            {
                var newPerson = new Player();

                if (i == 0)
                {
                    newPerson.name = "Juan";
                    CurrentPlayer = newPerson;
                }

                if (i == 1)
                    newPerson.name = "Mason";

                if (i == 2)
                    newPerson.name = "Alex";

                if (i == 3)
                    newPerson.name = "Duncan";

                listOfPlayers.Add(newPerson);
            }

            return listOfPlayers;
        }

        public void PrintPlayerNamesAndScores(List<Player> PlayerList)

        {
            foreach (var person in PlayerList)

            {
                Console.WriteLine("Name of player: " + person.name + " Score of player: " + person.score);
            }
        }
    }


    public class BowlingGame
    {
        private int[] rolls = new int[21];
        private int[] frame = new int[10];
        int currentRoll = 0;
        private bool isSpare(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1] == 10;
        }

        private bool isStrike(int frameIndex)
        {
            return rolls[frameIndex] == 10;
        }

        public void Roll(int pins)
        {
            rolls[currentRoll++] = pins;
        }

        public void Roll(int[] pins)
        {
            for (int i = 0; i < pins.Length; i++)
            {
                rolls[currentRoll++] = pins[i];
            }
        }

        public int Score()
        {
            int score = 0;
            int frameIndex = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (isSpare(frameIndex))
                {
                    score += 10 + rolls[frameIndex + 2];
                    frameIndex += 2;
                }
                else if (isStrike(frameIndex))
                {
                    score += 10 + rolls[frameIndex + 1] + rolls[frameIndex + 2];
                    frameIndex++;
                }
                else
                {
                    score += rolls[frameIndex] + rolls[frameIndex + 1];
                    frameIndex += 2;
                }

            }

            return score;
        }
    }
}
