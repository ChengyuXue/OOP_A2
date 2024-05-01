using System;

namespace OOP_A2
{
    internal class ThreeOrMore : Game
    {
        private int rollsTaken; // Field to store the number of rolls taken
        public int playerScore;
        public int computerScore;

        // Create a static instance of the Statistics class
        private static Statistics gameStatistics = Statistics.GetInstance();

        public ThreeOrMore() : base(5)
        {
        }

        public override void Play()
        {
            try
            {
                Console.WriteLine("Starting Three or More game...");
                playerScore = 0;
                computerScore = 0;
                rollsTaken = 0; 

                do
                {
                    Console.WriteLine("Player's turn:");
                    int playerTurnScore = PlayTurn();
                    playerScore += playerTurnScore;

                    if (playerScore >= 20)
                    {
                        Console.WriteLine("Congratulations! You've reached 20 points. You win!");
                        break;
                    }

                    Console.WriteLine($"Player's Total Score: {playerScore}");

                    Console.WriteLine("Computer's turn:");
                    int computerTurnScore = PlayTurn();
                    computerScore += computerTurnScore;

                    if (computerScore >= 20)
                    {
                        Console.WriteLine("The computer reached 20 points. You lose!");
                        break;
                    }

                    Console.WriteLine($"Computer's Total Score: {computerScore}");

                } while (true);

                // Record the game result in the Statistics class
                gameStatistics.RecordGameResult("Three or More", playerScore, rollsTaken);

                ReplayOrMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during Three or More gameplay: {ex.Message}");
            }
            
        }

        private int PlayTurn()
        {
            try
            {
                int[] rolls = RollAllDice();
                Array.Sort(rolls);
                Array.Reverse(rolls);
                rollsTaken++;

                Console.WriteLine($"Rolled: {string.Join(", ", rolls)}");

                int turnScore = CalculateScore(rolls);

                return turnScore;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during the turn: {ex.Message}");
                return 0;
            }
        }


        private int[] RollAllDice()
        {
            int[] rolls = new int[dice.Length];
            for (int i = 0; i < dice.Length; i++)
            {
                rolls[i] = dice[i].Roll();
            }
            return rolls;
        }

        private int CalculateScore(int[] rolls)
        {
            int score = 0;
            if (IsFiveOfAKind(rolls))
            {
                Console.WriteLine("5 of a kind rolled. Score: 12");
                score = 12;
            }
            else if (IsFourOfAKind(rolls))
            {
                Console.WriteLine("4 of a kind rolled. Score: 6");
                score = 6;
            }
            else if (IsThreeOfAKind(rolls))
            {
                Console.WriteLine("3 of a kind rolled. Score: 3");
                score = 3;
            }
            else if (IsTwoOfAKind(rolls))
            {
                Console.WriteLine("2 of a kind rolled, you have got a second chance");
                rolls = RollAllDice();
                Array.Sort(rolls);
                Array.Reverse(rolls);
                Console.WriteLine($"second chance rolled: {string.Join(", ", rolls)}");
                score = CalculateScore(rolls);
            }
            else
            {
                Console.WriteLine("Your roll comes up empty, tough luck!");
            }
            return score;
        }

        private bool IsTwoOfAKind(int[] rolls)
        {
            for (int i = 0; i < rolls.Length - 1; i++)
            {
                if (rolls[i] == rolls[i + 1])
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsThreeOfAKind(int[] rolls)
        {
            for (int i = 0; i < rolls.Length - 2; i++)
            {
                if (rolls[i] == rolls[i + 1] && rolls[i + 1] == rolls[i + 2])
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsFourOfAKind(int[] rolls)
        {
            for (int i = 0; i < rolls.Length - 3; i++)
            {
                if (rolls[i] == rolls[i + 1] && rolls[i + 1] == rolls[i + 2] && rolls[i + 2] == rolls[i + 3])
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsFiveOfAKind(int[] rolls)
        {
            for (int i = 0; i < rolls.Length - 4; i++)
            {
                if (rolls[i] == rolls[i + 1] && rolls[i + 1] == rolls[i + 2] && rolls[i + 2] == rolls[i + 3] && rolls[i + 3] == rolls[i + 4])
                {
                    return true;
                }
            }
            return false;
        }
    }
}
