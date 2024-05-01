using System;

namespace OOP_A2
{
    internal class Program
    {
        private static Statistics gameStatistics = Statistics.GetInstance();
        static void Main(string[] args)
        {
            DisplayMainMenu();
        }

        public static void DisplayMainMenu()
        {
            try
            {
                Console.WriteLine("\n------Main Menu------");
                Console.WriteLine("1. SevensOut");
                Console.WriteLine("2. Three Or More");
                Console.WriteLine("3. View Game Statistics");
                Console.WriteLine("4. Open Testing Menu");
                Console.WriteLine("Anyother key to exit the program");
                Console.WriteLine("Enter your choice (1, 2, 3, 4 or anyother key):");

                char choice = Console.ReadKey().KeyChar;
                switch (choice)
                {
                    case '1':
                        new SevensOut().Play();
                        break;
                    case '2':
                        new ThreeOrMore().Play();
                        break;
                    case '3':
                        gameStatistics.DisplayStatistics();
                        DisplayMainMenu();
                        break;
                    case '4':
                        Testing.TestMenu();
                        return;
                    default:
                        Console.WriteLine("\nExiting the program.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while processing main menu input: {ex.Message}");
            }

        }
    }
}
