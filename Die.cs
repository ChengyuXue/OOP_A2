using System;

namespace OOP_A2
{
    internal class Die
    {
        // Property to hold the current die value
        public int Value { get; private set; }

        // Random number generator for rolling the die
        private static Random random = new Random();

        // Method to roll the die and return the result
        public int Roll()
        {
            try
            {
                // Generate a random number between 1 and 6 for the die roll
                Value = random.Next(1, 7);
                return Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while rolling the die: {ex.Message}");
                return 0; // Return a default value
            }
        }

    }
}