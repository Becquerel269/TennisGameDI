using System.Collections.Generic;
using TennisScoringDI.Models;

namespace TennisScoringDI.Services.Player
{
    public interface IUIService
    {
        List<string> GetThePlayers(int numberOfPlayers);

        void DisplayTheScoreTable(ScoreTable scoreTable);

        void DisplayTheWinner();

        void DisplayPlayerMakingMove(string playerName);
    }
}