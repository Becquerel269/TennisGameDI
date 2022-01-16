using System.Collections.Generic;
using TennisScoringDI.Models;

namespace TennisScoringDI.Services.ScoreCalculator
{
    public interface IScoreService
    {
        void SetupScoreTable(List<string> playernames);

        //if string is empty game not yet won, else returns winner name
        string GetWinner();

        ScoreTable GetTheScoreTable();

        ScoreTable PointScored(MoveResult moveResult, string playerName);
    }
}