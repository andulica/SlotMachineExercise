namespace SlotMachineExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GUI.WelcomeMessage();
            GUI.PrintOptions();
            List<int> linesToPlay = new List<int>();
            int credits = 0;
            int[,] grid;
            int winnings;

            // Keeps playing until user decides to quit the game.
            while (true)
            {        
                // If no lines has been chosen or player pressed "m" he is promted to enter new values.
                if (!linesToPlay.Any() || GUI.DecideIfContinue().Equals("m"))
                {
                    linesToPlay = GUI.ChooseLines();
                    credits += GUI.MoneyToPlay(linesToPlay);
                }

                // Check if the player has enough credits for this round.
                if (credits < linesToPlay.Count)
                {
                    Console.WriteLine("Insufficient funds! Please add more.");
                    credits += GUI.MoneyToPlay(linesToPlay);
                }

                // If all conditions to play have been met, then the game plays a spin
                grid = GameLogic.PopulateGrid();
                GUI.DisplayGrid(grid);
                winnings = GameLogic.CheckAllLines(linesToPlay, grid);
                GUI.DisplayWinnings(winnings);
                credits = credits + winnings - linesToPlay.Count;
                GUI.DisplayCreditsLeft(credits);
            }
        }
    }

}