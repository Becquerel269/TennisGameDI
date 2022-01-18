using System.Collections.Generic;
using TennisScoringDI.Services.Player;

namespace TennisScoringDI.Models
{
    public class PlayerScore
    {
        public int Score { get; set; }

        public string PlayerName { get; set; }

        public string ScoreDisplay { get; set; }
    }

    public class ScoreTable
    {
        public List<PlayerScore> PlayerScores { get; set; }
    }
}