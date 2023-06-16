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

            //keeps playing until user decides to quit the game
            while (true)
            {              
                if (!linesToPlay.Any() || GUI.DecideIfContinue().Equals("m"))
                {
                    linesToPlay = GUI.ChooseLines();
                    credits = GUI.MoneyToPlay(linesToPlay);
                }

                // Check if the player has enough credits for this round.
                if (credits < linesToPlay.Count)
                {
                    Console.WriteLine("Insufficient funds! Please add more.");
                    credits += GUI.MoneyToPlay(linesToPlay);
                }

                int[,] grid = GameLogic.PopulateGrid();
                GUI.DisplayGrid(grid);
                credits = GameLogic.CheckAllLines(linesToPlay, credits, grid);
            }
        }
    }

}