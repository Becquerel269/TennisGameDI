using System;
using TennisScoringDI.Models;

namespace TennisScoringDI.Services.Rules
{
    public class TennisRulesService : IRulesService
    {
        private const int LOVE = 0;
        private const int FIFTEEEN = 1;
        private const int THIRTY = 2;
        private const int FOURTY = 3;
        private const int ADVANTAGE = 4;

        public MoveResult MakeAMove(ScoreTable scoreTable, string playerName)
        {
            PlayerScore currentPlayerScore = null;
            bool deuceDetected = true;
            foreach (var playerScore in scoreTable.PlayerScores)
            {
                if (playerScore.Score != 40)
                {
                    deuceDetected = false;
                }
                if (playerScore.PlayerName == playerName)
                {
                    currentPlayerScore = playerScore;
                }
            }
            int point;
            point = RandomPoints();
            if (point == 0)
            {
                return new MoveResult()
                {
                    Points = point,
                    PointsDisplay = currentPlayerScore?.ScoreDisplay,
                    HasWon = false,
                };
            }

            switch (currentPlayerScore.Score)
            {
                case 0:
                case 15:
                    return new MoveResult()
                    {
                        Points = 15,
                        PointsDisplay = (currentPlayerScore.Score + 15).ToString(),
                        HasWon = false,
                    };

                case 30:
                    return new MoveResult()
                    {
                        Points = 10,
                        PointsDisplay = (currentPlayerScore.Score + 10).ToString(),
                        HasWon = false,
                    };

                case 40:
                    if (!deuceDetected || (deuceDetected && currentPlayerScore.ScoreDisplay == "ADVANTAGE"))
                    {
                        return new MoveResult()
                        {
                            Points = 20,
                            PointsDisplay = (currentPlayerScore.Score + 20).ToString(),
                            HasWon = true,
                        };
                    }
                    else
                    {
                        return new MoveResult()
                        {
                            Points = 0,
                            PointsDisplay = "ADVANTAGE",
                            HasWon = false,
                        };
                    }
                default:
                    throw new Exception($"Unexpected Player Score {currentPlayerScore?.Score}");
            }
        }

        private static int RandomPoints()
        {
            int point;
            Random random = new Random();
            if (random.Next(2) == 0)
            {
                point = 0;
            }
            else
            {
                point = 1;
            }

            return point;
        }

        public int NumberOfPlayers()
        {
            return 2;
        }
    }
}