using System;


namespace OOP_A2
{
    internal class SevensOut : Game
    {
        private int rollsTaken;
        public int rollTotal;

        private static Statistics gameStatistics = Statistics.GetInstance();

        public SevensOut() : base(2)
        {
            rollsTaken = 0;
            rollTotal = 0; // Initialize rollTotal
        }

        public override void Play()
        {
            try
            {
                Console.WriteLine("Starting Sevens Out game...");
                TotalScore = 0;

                while (true)
                {
                    rollTotal = dice[0].Roll() + dice[1].Roll(); // Calculate rollTotal
                    Console.WriteLine($"Rolled: {dice[0].Value}, {dice[1].Value} Total: {rollTotal}");
                    TotalScore += rollTotal;

                    rollsTaken++; // Increment rolls taken with each roll

                    if (rollTotal == 7)
                    {
                        Console.WriteLine("You rolled a 7. Game over!");
                        break;
                    }
                    else
                    {
                        if (dice[0].Value == dice[1].Value)
                        {
                            Console.WriteLine($"Double! Adding double the total to your score");
                            TotalScore += rollTotal;
                        }
                        Console.WriteLine($"Total: {TotalScore}");
                    }
                }

                // Record the game result by passing the TotalScore achieved in the game
                gameStatistics.RecordGameResult("Sevens Out", TotalScore, rollsTaken);

                ReplayOrMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during gameplay: {ex.Message}");
            }
        }

        public int GetRollsTaken()
        {
            return rollsTaken;
        }


    }

}
