using System;
using System.Collections.Generic;
using System.Linq;

namespace TennisScoringDI.Services.Player
{
    public class PlayerService : IPlayerService
    {
        private readonly List<IPlayer> _Players;

        public PlayerService()
        {
            _Players = new List<IPlayer>();
        }

        public List<IPlayer> Players => _Players;

        public void AddPlayers(List<string> playerNames)
        {
            foreach (var playerName in playerNames)
            {
                Console.WriteLine(playerName);
                _Players.Add(new Player
                {
                    PlayerName = playerName
                });
            }
        }

        public List<string> GetPlayerNames()
        {
            return (from player in _Players
                    select player.PlayerName).ToList();
        }
    }
}