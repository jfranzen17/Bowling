using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingRound;
using System;

namespace BowlingRoundTest
{
    [TestClass]
    public class RoundTest
    {
        private Round round;

        [TestInitialize]
        public void Initialize()
        {
            round = new Round();
        }

        [TestMethod]
        public void Roll_AllGutters_ScoreZero()
        {
            for (var i = 0; i <= 20; i++)
            {
                round.Roll(0);
            }
            Assert.AreEqual(0, round.Score);
        }
        /*[TestMethod]
        public void RollReturnsTheNumberOfPinsKnockedDown()
        {
            for (var i = 0; i <= 21; i++)
            {
                round.Roll(i);
                Assert.AreEqual(i, round.Score);
            }
        }*/

        [TestMethod]
        public void Roll_AllTwos_Score40()
        {
            for (var i = 0; i <= 20; i++)
            {
                round.Roll(2);
            }
            Assert.AreEqual(40, round.Score);
        }

        [TestMethod]
        public void CanRoll_Spare_Score14()
        {
            round.Roll(6);
            round.Roll(4);
            round.Roll(2);

            Assert.AreEqual(14, round.Score);
        }

        [TestMethod]
        public void CanRoll_Strike_Score26()
        {
            round.Roll(10);
            round.Roll(2);
            round.Roll(6);

            Assert.AreEqual(26, round.Score);
        }
        [TestMethod]
        public void CanRoll_MaxGame_Score300()
        {
            for(var i=0;i<=21;i++)
            {
                round.Roll(10);
            }
            Assert.AreEqual(300, round.Score);
        }
        [TestMethod]
        public void CanRoll_AllSpare_Score150()
        {
            for(var i =0;i<=21;i++)
            {
                round.Roll(5);
            }
            Assert.AreEqual(150,round.Score);
        }

        [TestMethod]
        public void Roll_ASpareThenAStrike_Score38()
        {
            round.Roll(5);
            round.Roll(5);
            round.Roll(10);
            round.Roll(2);
            round.Roll(2);
            Assert.AreEqual(38,round.Score);
        }

        [TestMethod]
        public void Roll_ExtraRollIfSpareOrStrikeInLastFrame()
        {
            for (var i = 0; i < 18; i++)
            {
                round.Roll(2);
            }
            round.Roll(5);
            round.Roll(5);
            round.Roll(2);
            Assert.AreEqual(48, round.Score);

        }

        [TestMethod]
        public void Roll_DontGetExtraFrame()
        {
            for (int i = 0; i < 22; i++)
            {
                round.Roll(2);
            }
            Assert.AreEqual(40, round.Score);
        }

        [TestMethod]
        public void RoundCompleted()
        {
            Assert.IsFalse(round.Complete);
        }

        //private void RollAmount(int pins, int rolls)
        //{
        //    for (var i =0; i <rolls; i++)
        //    {
        //        round.Roll(pins);
        //    }
        //}

    }
}