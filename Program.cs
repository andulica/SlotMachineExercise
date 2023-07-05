namespace SlotMachineExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GUI.DisplayWelcomeMessage();
            List<int> linesToPlay = new List<int>();
            int credits = 0;
            int[,] grid;
            int winnings;
            bool quit = false;
            
            // Keeps playing until user decides to quit the game.
            while (true)
            {
                // If no lines has been chosen or player pressed "m" to modify the values, he is promted to enter new values.
                if (!linesToPlay.Any() || GUI.GetUserContinueDecision())
                {
                    linesToPlay = GameLogic.AddLinesToList();
                    GUI.DisplayChosenLines(linesToPlay);
                    credits += GUI.GetMoneyToPlay();
                }

                // Check if the player has enough credits for this round.
                // Also once the user get to the stage when he needs more credits to continue playing, he is asked if he wants to quit the game or not.     
                while (credits < linesToPlay.Count)
                {
                    quit = GUI.GetUserExitGameDecision();
                    if (quit)
                    {
                        break;
                    }
                    GUI.AlertInsufficientFunds();
                    credits += GUI.GetMoneyToPlay();
                }
                
                if (quit)
                {
                    break;
                }
                // If all conditions to play have been met, then the game plays a spin.
                grid = GameLogic.GenerateRandomGrid();
                GUI.DisplaySlotMachineGrid(grid);
                winnings = GameLogic.CheckAllLines(linesToPlay, grid);
                GUI.DisplayTotalWinnings(winnings);
                credits = credits + winnings - linesToPlay.Count;
                GUI.DisplayTotalCredits(credits);
            }
        }
    }
}