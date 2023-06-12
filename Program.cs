namespace SlotMachineExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GUI.WelcomeMessage();
            GUI.PrintOptions();
                             
            //keeps playing until user decides to quite the game
            while (true) {
                List<int> linesToPlay = (GUI.ChooseLines());
                int credits = GUI.MoneyToPlay(linesToPlay);
                int[,] grid = GameLogic.PopulateGrid();

                if (credits < linesToPlay.Count)
                {
                    credits += GUI.MoneyToPlay(linesToPlay);
                }
                grid = GameLogic.PopulateGrid();
                GUI.DisplayGrid(grid);
                credits = GameLogic.CheckAllLines(linesToPlay, credits, grid);

                String userChecker = GUI.DecideIfContinue();
                if (userChecker.Equals("m"))
                {
                    linesToPlay = (GUI.ChooseLines());
                }                
            }                     
        }
    }
}