using System;
using System.Collections.Generic;
using TennisScoringDI.Models;

namespace TennisScoringDI.Services.Player
{
    public class UIService : IUIService
    {
        public List<string> GetThePlayers(int numberOfPlayers)
        {
            List<string> players = new List<string>();
            for (var i = 0; i < numberOfPlayers; i++)
            {
                Console.WriteLine($"What is your name player {i + 1}?");
                var input = Console.ReadLine();
                players.Add(input);
            }
            return players;
            //add test for GetThePlayers
        }

        public void DisplayTheScoreTable(ScoreTable scoreTable)
        {
            Console.WriteLine("------");
            Console.WriteLine("The Current Score is:");
            foreach (var score in scoreTable.PlayerScores)
            {
                Console.WriteLine($"Player {score.PlayerName}: Score {score.ScoreDisplay}");
            }
            Console.WriteLine("------");
        }

        public void DisplayTheWinner()
        {
            Console.WriteLine("Game Over");
        }

        public void DisplayPlayerMakingMove(string playerName)
        {
            Console.WriteLine($"{playerName} is making a move");
        }
    }
}