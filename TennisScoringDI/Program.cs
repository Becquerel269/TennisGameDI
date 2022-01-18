using System;
using TennisScoringDI.Services;
using TennisScoringDI.Services.Player;
using TennisScoringDI.Services.Rules;
using TennisScoringDI.Services.ScoreCalculator;

namespace TennisScoringDI
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the game");

            IPlayerService playerService = new PlayerService();
            IUIService uIService = new UIService();
            IScoreService scoreService = new ScoreService();
            IRulesService tennisRulesService = new TennisRulesService();
            IGameService gameService = new GameService(playerService, uIService, scoreService, tennisRulesService);
            var numberOfPlayers = tennisRulesService.NumberOfPlayers();
            gameService.GetThePlayers(numberOfPlayers);
            gameService.DisplayTheScoreTable();
            gameService.PlayTheGame();

            Console.ReadLine();
        }
    }
}