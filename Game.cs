using System;

namespace OOP_A2
{
    internal abstract class Game
    {

        protected Die[] dice;
        public int TotalScore { get; protected set; }


        public Game(int numberOfDice)
        {
            dice = new Die[numberOfDice];
            for (int i = 0; i < numberOfDice; i++)
            {
                dice[i] = new Die();
            }
        }

        public abstract void Play();
        protected void ReplayOrMenu()
        {
            Console.Write("Press 'Y' to play again or anyother key to reurning to main menu.");
            char choice = Console.ReadKey().KeyChar;
            Console.WriteLine();
            if (char.ToUpper(choice) == 'Y')
            {
                Play(); // Restart the game
            }
            else
            {
                Console.WriteLine("Returning to main menu.");
                Program.DisplayMainMenu();
            }
        }

    }
}
