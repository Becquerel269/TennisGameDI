using TennisScoringDI.Models;

namespace TennisScoringDI.Services.Rules
{
    public interface IRulesService
    {
        MoveResult MakeAMove(ScoreTable scoreTable, string playerName);

        int NumberOfPlayers();
    }
}