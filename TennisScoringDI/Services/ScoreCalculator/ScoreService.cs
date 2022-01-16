using System;
using System.Collections.Generic;
using TennisScoringDI.Models;

namespace TennisScoringDI.Services.ScoreCalculator
{
    internal class ScoreService : IScoreService
    {
        private ScoreTable _scoreTable;

        
        public void SetupScoreTable(List<string> playerNames)
        {
            var playerScores = new List<PlayerScore>();
            foreach (var playerName in playerNames)
            {
                var playerScore = new PlayerScore
                {
                    PlayerName = playerName,
                    Score = 0,
                };
                playerScores.Add(playerScore);
            }

            _scoreTable = new ScoreTable
            {
                PlayerScores = playerScores,
            };
        }

        public string GetWinner()
        {
            throw new NotImplementedException();
        }

        public ScoreTable GetTheScoreTable()
        {
            return _scoreTable;
        }

        public ScoreTable PointScored(MoveResult moveResult, string playerName)
        {
            foreach (var playerScore in _scoreTable.PlayerScores)
            {
                if (playerScore.PlayerName == playerName)
                {
                    playerScore.ScoreDisplay = moveResult.PointsDisplay;
                    playerScore.Score += moveResult.Points;
                    break;
                }
            }
            return _scoreTable;
        }
    }
}