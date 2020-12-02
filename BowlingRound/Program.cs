using System;
using System.Collections.Generic;

namespace BowlingRound
{
    public class Round
    {
        private List<int> _rolls = new List<int>(21);
        private int currentRoll = 0;
        public bool Complete { get;private set; } = false;

        public Round()
        {
            for (int i = 0; i <=21; i++)
            {
                _rolls.Add(0);
            }
        }

        public int Score
        {
            get
            {
                var score = 0;
                var rollCount = 0;

                for (var frame = 0; frame < 10; frame++)
                {
                    //If strike
                    if(_rolls[rollCount]==10)
                    {
                        score += 10 + _rolls[rollCount + 1] + _rolls[rollCount + 2];
                        rollCount++;
                    }
                    //If spare
                    else if(_rolls[rollCount]+_rolls[rollCount+1]==10)
                    {
                        score += 10 + _rolls[rollCount+2];
                        rollCount += 2;
                    }
                    else
                    {
                        score += _rolls[rollCount] + _rolls[rollCount + 1];
                        rollCount += 2;
                    }

                }
                return score;
            }
        }

        public void Roll(int pins)
        {
            _rolls[currentRoll++] = pins;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
