using System;
using System.Diagnostics;

namespace OOP_A2
{
    internal class Testing
    {
        // Path to the test log file
        private static readonly string testLogPath = "testlog.txt";

        public static void TestMenu()
        {
            using (TextWriterTraceListener testLogListener = new TextWriterTraceListener(testLogPath))
            {
                Trace.Listeners.Add(testLogListener);

                try
                {
                    while (true)
                    {
                        Console.WriteLine("-----Test Menu-----:");
                        Console.WriteLine("1. Test Sevens Out");
                        Console.WriteLine("2. Test Three or More");
                        Console.WriteLine("3. Back to the main menu");
                        Console.WriteLine("Anyother key to exit the program");
                        Console.Write("Enter your choice (1, 2, 3, or anyother key):");

                        char choice = Console.ReadKey().KeyChar;
                        Console.WriteLine();

                        switch (choice)
                        {
                            case '1':
                                TestSevensOut();
                                return;
                            case '2':
                                TestThreeOrMore();
                                return;
                            case '3':
                                Program.DisplayMainMenu();
                                return;
                            default:
                                Console.WriteLine("\nExiting the program.");
                                return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine($"An error occurred during testing: {ex.Message}");
                }
            }
        }

        public static void TestSevensOut()
        {
            try
            {
                // Create an instance of the SevensOut game
                SevensOut game = new SevensOut();
                game.Play();

                // Assert for game logic
                bool sevensOutResult = game.rollTotal == 7;
                Debug.Assert(sevensOutResult, "Error, Sevens Out game test failed.");

                // Log the test result
                Trace.WriteLine($"Test Sevens Out: {(sevensOutResult ? "PASSED" : "FAILED")}");
            }
            catch (Exception ex)
            {
                // Log any exceptions during testing
                Trace.WriteLine($"An error occurred during Sevens Out testing: {ex.Message}");
            }
        }

        public static void TestThreeOrMore()
        {
            try
            {
                // Create an instance of the Three or More game
                ThreeOrMore game = new ThreeOrMore();
                game.Play();

                bool threeOrMoreResult = game.playerScore >= 20 || game.computerScore >= 20;
                Debug.Assert(threeOrMoreResult, "Error, Three or More game test failed.");

                // Log the test result
                Trace.WriteLine($"Test Three or More: {(threeOrMoreResult ? "PASSED" : "FAILED")}");
            }
            catch (Exception ex)
            {
                // Log any exceptions during testing
                Trace.WriteLine($"An error occurred during Three or More testing: {ex.Message}");
            }
        }
    }
}
