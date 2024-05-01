using System;
using System.Collections.Generic;

namespace OOP_A2
{
    internal class Statistics
    {
        private static Statistics instance;
        private Dictionary<string, GameStatistics> gameStats;

        private Statistics()
        {
            gameStats = new Dictionary<string, GameStatistics>();
        }

        public static Statistics GetInstance()
        {
            if (instance == null)
            {
                instance = new Statistics();
            }
            return instance;
        }

        public void RecordGameResult(string gameType, int score, int rollsTaken)
        {
            try
            {
                if (!gameStats.ContainsKey(gameType))
                {
                    gameStats[gameType] = new GameStatistics();
                }

                gameStats[gameType].TotalPlays++;

                // Update high score based on the game type
                if (gameType == "Sevens Out")
                {
                    // Update high score 
                    gameStats[gameType].HighScore = Math.Max(gameStats[gameType].HighScore, score);
                }
                else if (gameType == "Three or More" || rollsTaken < gameStats[gameType].HighScore)
                {
                    gameStats[gameType].HighScore = rollsTaken;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while recording game result: {ex.Message}");
            }
        }





        public void DisplayStatistics()
        {   
            Console.WriteLine();
            Console.WriteLine("Game Statistics:");

            if (gameStats.Count == 0)
            {
                Console.WriteLine("No game statistics recorded.");
                return;
            }

            foreach (var kvp in gameStats)
            {
                Console.WriteLine($"Game Type: {kvp.Key}");
                Console.WriteLine($"Total Plays: {kvp.Value.TotalPlays}");
                Console.WriteLine($"High Score: {kvp.Value.HighScore}");
                Console.WriteLine();
            }
        }
    }

    internal class GameStatistics
    {
        public int TotalPlays { get; set; }
        public int HighScore { get; set; }
    }
}