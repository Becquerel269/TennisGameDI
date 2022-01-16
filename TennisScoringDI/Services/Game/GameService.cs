using System;
using TennisScoringDI.Services.Player;
using TennisScoringDI.Services.Rules;
using TennisScoringDI.Services.ScoreCalculator;

namespace TennisScoringDI.Services
{
    public class GameService : IGameService
    {
        private readonly IPlayerService _playerService;
        private readonly IUIService _uIService;
        private readonly IScoreService _scoreService;
        private readonly IRulesService _rulesService;

        public GameService(IPlayerService playerService, IUIService uIService, IScoreService scoreService, IRulesService rulesService)
        { 
            _playerService = playerService;
            _uIService = uIService;
            _scoreService = scoreService;
            _rulesService = rulesService;
        }

        public void GetThePlayers(int numberOfPlayers)
        {
            var players = _uIService.GetThePlayers(numberOfPlayers);
            _scoreService.SetupScoreTable(players);
            _playerService.AddPlayers(players);
        }

        public void DisplayTheScoreTable()
        {
            _uIService.DisplayTheScoreTable(_scoreService.GetTheScoreTable());
        }

        public void PlayTheGame()
        {
            int max = 100;
            var count = 0;
            bool playerHasWon = false;
            for (; ;)
            {
                count++;
                var playerNames = _playerService.GetPlayerNames();

                foreach (var playerName in playerNames)
                {
                    _uIService.DisplayPlayerMakingMove(playerName);
                    var moveResult = _rulesService.MakeAMove(_scoreService.GetTheScoreTable(), playerName);
                    if (moveResult.HasWon == true)
                    {
                        playerHasWon = true;
                        _uIService.DisplayTheWinner();
                        break;
                    }
                    var scoreTable = _scoreService.PointScored(moveResult, playerName);
                    _uIService.DisplayTheScoreTable(scoreTable);
                }
                if (playerHasWon == true)
                {
                    break;
                }
                if (count > max)
                {
                    break;
                }
            }
        }
    }
}