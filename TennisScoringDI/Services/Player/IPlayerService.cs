using System.Collections.Generic;

namespace TennisScoringDI.Services.Player
{
    public interface IPlayerService
    {
        List<IPlayer> Players { get; }

        void AddPlayers(List<string> playerName);

        List<string> GetPlayerNames();
    }
}