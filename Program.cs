namespace SlotMachineExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GUI.WelcomeMessage();
            GUI.PrintOptions();
            List<int> linesToPlay = new(GUI.ChooseLines());
            int credits = GUI.MoneyToPlay(linesToPlay);
            int[,] grid = GameLogic.PopulateGrid();
            bool continueGame = true;

            //first call of the Spin method is required so that changing the lines to play in the while loop becomes valid
            if (credits < linesToPlay.Count)
            {
                credits += GUI.MoneyToPlay(linesToPlay);
            }
            grid = GameLogic.PopulateGrid();
            GUI.DisplayGrid(grid);
            credits = GameLogic.CheckAllLines(linesToPlay, credits, grid);

            //keeps playing until user decides to quite the game
            while (continueGame) { 

                String userChecker = GUI.DecideIfContinue();

                switch (userChecker)
                {
                    case "m":
                        linesToPlay = new(GUI.ChooseLines());
                        if (credits < linesToPlay.Count)
                        {
                            credits += GUI.MoneyToPlay(linesToPlay);
                        }
                        grid = GameLogic.PopulateGrid();
                        GUI.DisplayGrid(grid);
                        credits = GameLogic.CheckAllLines(linesToPlay, credits, grid);
                        break;
                    case "y":
                        if (credits < linesToPlay.Count)
                        {
                            credits += GUI.MoneyToPlay(linesToPlay);
                        }
                        grid = GameLogic.PopulateGrid();
                        GUI.DisplayGrid(grid);
                        credits = GameLogic.CheckAllLines(linesToPlay, credits, grid);
                        break;
                }
            }                     
        }
    }
}