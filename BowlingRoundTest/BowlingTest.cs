using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;
using System;

namespace BowlingRoundTest
{
    [TestClass]
    public class BowlingGameTest
    {
        private BowlingGame bowlingGame;

        public BowlingGameTest()
        {
            bowlingGame = new BowlingGame();
        }

        private void RollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                bowlingGame.Roll(pins); ;
            }
        }

        [TestMethod]
        public void Roll_AllGutters_ScoreZero()
        {
            RollMany(20, 0);
            Assert.AreEqual(0, bowlingGame.Score());
        }
        [TestMethod]
        public void RollReturnsTheNumberOfPinsKnockedDown()
        {
            bowlingGame.Roll(4);
            bowlingGame.Roll(2); ;
            Assert.AreEqual(6, bowlingGame.Score());
        }

        [TestMethod]
        public void Roll_AllTwos_Score40()
        {
            RollMany(20, 2);
            Assert.AreEqual(40, bowlingGame.Score());
        }

        [TestMethod]
        public void CanRoll_Spare_Score14()
        {
            bowlingGame.Roll(6);
            bowlingGame.Roll(4);
            bowlingGame.Roll(2);

            Assert.AreEqual(14, bowlingGame.Score());
        }

        [TestMethod]
        public void CanRoll_Strike_Score26()
        {
            bowlingGame.Roll(10);
            bowlingGame.Roll(2);
            bowlingGame.Roll(6);

            Assert.AreEqual(26, bowlingGame.Score());
        }
        [TestMethod]
        public void CanRoll_MaxGame_Score300()
        {
            RollMany(12, 10);
            Assert.AreEqual(300, bowlingGame.Score());
        }
        [TestMethod]
        public void CanRoll_AllSpare_Score150()
        {
            RollMany(21, 5);
            Assert.AreEqual(150, bowlingGame.Score());
        }

        [TestMethod]
        public void Roll_ASpareThenAStrike_Score38()
        {
            bowlingGame.Roll(5);
            bowlingGame.Roll(5);
            bowlingGame.Roll(10);
            bowlingGame.Roll(2);
            bowlingGame.Roll(2);
            Assert.AreEqual(38, bowlingGame.Score());
        }

        [TestMethod]
        public void Roll_ExtraRollIfSpareOrStrikeInLastFrame()
        {
            RollMany(18, 2);

            bowlingGame.Roll(5);
            bowlingGame.Roll(5);
            bowlingGame.Roll(2);
            Assert.AreEqual(48, bowlingGame.Score());

        }

        [TestMethod]
        public void Roll_DontGetExtraFrame()
        {
            RollMany(21, 2);
            Assert.AreEqual(40, bowlingGame.Score());
        }

        [TestMethod]
        public void RollAFullGame_TestRandomGameNoExtraRoll_Returns113()
        {
            bowlingGame.Roll(new int[] { 2, 8, 3, 7, 8, 1, 10, 6, 1, 5, 2, 5, 1, 8, 0, 10, 9, 0 });
            Assert.AreEqual(113, bowlingGame.Score());
        }

        [TestMethod]
        public void Score_Roll_TestRandomGameWithSpareThenStrikeAtEnd_Returns120()
        {
            bowlingGame.Roll(new int[] { 1, 1, 2, 3, 5, 5, 10, 10, 7, 2, 6, 2, 1, 3, 4, 2, 8, 2, 10});
            Assert.AreEqual(120, bowlingGame.Score());
        }

        [TestMethod]
        public void Score_Roll_TestRandomGameWithThreeStrikesAtEnd_Returns160()
        {
            bowlingGame.Roll(new int[] { 5, 5, 4, 2, 7, 3, 10, 9, 1, 5, 4, 10, 4, 4, 8, 2, 10, 10, 10});
            Assert.AreEqual(160, bowlingGame.Score());

        }

        [TestMethod]
        public void Game_StartAGameWith4People_ReturnTrue()
        {

            var newGame = new BowlingWithPeople();

            newGame.StartGame(2);

            var actual = newGame.PlayerList.Count;

            Assert.AreEqual(actual, 2);

        }

        [TestMethod]
        public void Game_ActivePlayer_ReturnTrue()
        {
            var newGame = new BowlingWithPeople();

            var newPlayer = new Player();
            newGame.PlayerList.Add(newPlayer);

            newGame.CurrentPlayer = newPlayer;

            var actual = newPlayer;

            Assert.AreEqual(actual, newGame.CurrentPlayer);

        }

        [TestMethod]
        public void Game_GetSecondPlayersScore_Returns7()
        {

            var newGame = new BowlingWithPeople();

            var listOfPlayers = newGame.StartGame(2);

            bowlingGame.Roll(7);
            bowlingGame.Roll(2);
            int score1 = bowlingGame.Score();
            newGame.CurrentPlayer.score = score1;

            newGame.CurrentPlayer = listOfPlayers[1];

            bowlingGame.Roll(1);
            bowlingGame.Roll(6);
            int score2 = bowlingGame.Score() - score1;
            newGame.CurrentPlayer.score = score2;

            var actual = listOfPlayers[1].score;

            Assert.AreEqual(7, actual);
        }

        [TestMethod]
        public void Game_GetNameFromPlayer_ReturnTrue()
        {
            var newGame = new BowlingWithPeople();

            var ListOfPlayers = newGame.StartGame(2);

            var actual = ListOfPlayers[1].name;

            Assert.AreEqual("Mason", actual);
        }
    }
}