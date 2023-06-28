namespace SlotMachineExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GUI.WelcomeMessage();
            List<int> linesToPlay = new List<int>();
            int credits = 0;
            int[,] grid;
            int winnings;
            bool quit = false;
            
            // Keeps playing until user decides to quit the game.
            while (true)
            {
                // If no lines has been chosen or player pressed "m" to modify the values, he is promted to enter new values.
                if (!linesToPlay.Any() || GUI.DecideIfContinue())
                {
                    linesToPlay = GameLogic.AddLineToList();
                    GUI.OutPutChoseLines(linesToPlay);
                    credits += GUI.MoneyToPlay(linesToPlay);
                }

                // Check if the player has enough credits for this round.
                // Also once the user get to the stage when he needs more credits to continue playing, he is asked if he wants to quit the game or not.     
                while (credits < linesToPlay.Count)
                {
                    quit = GUI.DecideIfExitGame();
                    if (quit)
                    {
                        break;
                    }
                    GUI.InsufficientFunds();
                    credits += GUI.MoneyToPlay(linesToPlay);
                }
                
                if (quit)
                {
                    break;
                }
                // If all conditions to play have been met, then the game plays a spin.
                grid = GameLogic.PopulateGrid();
                GUI.DisplayGrid(grid);
                winnings = GameLogic.CheckAllLines(linesToPlay, grid);
                GUI.DisplayWinnings(winnings);
                credits = credits + winnings - linesToPlay.Count;
                GUI.DisplayCredits(credits);
            }
        }
    }
}