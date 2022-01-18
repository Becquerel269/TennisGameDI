using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TennisScoringDI.Models;
using TennisScoringDI.Services.Player;
using TennisScoringDI.Services.ScoreCalculator;

namespace TennisScoringDITests
{
    [TestClass]
    public class TennisTests
    {
        private MoveResult moveResult;
        private PlayerScore playerOneScore, playerTwoScore;
        private ScoreTable scoreTable;
        private Player playerOne, playerTwo;

        //[TestMethod]
        //public void CurrentScore_Returns00_WhenNothingHasBeenScored()
        //{
        //    //Arrange
        //    int playeronescore = 0;
        //    int playertwoscore = 0;
        //    string expectedstring = "0 0";
        //    //Act
        //    var result = _scoreCalculator.CurrentScore(playeronescore, playertwoscore);
        //    //Assert
        //    Assert.AreEqual(result, expectedstring);
        //}

        [TestInitialize]
        public void TestInitialize()
        {
            
            moveResult = new MoveResult()
            {
                Points = 0,
                PointsDisplay = "0,0",
                HasWon = false,
            };
            playerOneScore = new PlayerScore()
            {
                Score = 0,
                PlayerName = "playerOne",
                ScoreDisplay = "0,0",
            };
            playerTwoScore = new PlayerScore()
            {
                Score = 0,
                PlayerName = "playerTwo",
                ScoreDisplay = "0,0",
            };
            var rob = new List<PlayerScore>();
            rob.Add(playerOneScore);
            rob.Add(playerTwoScore);
            scoreTable = new ScoreTable()
            {
                PlayerScores = rob,
            };
            playerOne = new Player()
            {
                PlayerName = "PlayerOne",
            };
            playerTwo = new Player()
            {
                PlayerName = "PlayerTwo",
            };
        }



        [TestMethod]
        public void PointsScored_ReturnAnEmptyScoreTable_WhenNothingHasBeenScoredByEitherPlayer()
        {
            //Arrange

            string newplayer = "playerOne";
            
            ScoreService scoreService = new ScoreService();
            

            //Act

            var result = scoreService.PointScored(moveResult, newplayer);

            //Assert

            Assert.AreEqual(0, result.PlayerScores.Count);
        }
    }

}