using System;
using System.Collections.Generic;
using TennisScoringDI.Models;

namespace TennisScoringDI.Services.ScoreCalculator
{
    public class ScoreService : IScoreService
    {
        private ScoreTable _scoreTable;

        public ScoreService()
        {
            _scoreTable = new ScoreTable();
            _scoreTable.PlayerScores = new List<PlayerScore>();
        }
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

            _scoreTable.PlayerScores = playerScores;
            
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
            if (moveResult == null)
            {
                throw new ArgumentNullException(nameof(moveResult));
            }
            if (String.IsNullOrEmpty(playerName))
            {
                throw new ArgumentNullException(nameof(playerName));
            }
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