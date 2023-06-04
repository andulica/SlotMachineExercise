namespace SlotMachineExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GUI.WelcomeMessage();
            GUI.PrintOptions();
            List<int> linesToPlay = new(GUI.ChooseLines());
            int credits = GUI.MoneyToPlay();
            int[,] screen = GameLogic.PopulateGrid();
            bool continueGame = true;

            //first call of the Spin method is required so that changing the lines to play in the while loop becomes valid
            credits = GameLogic.Spin(linesToPlay, credits, screen);

            //keeps playing until user decides to quite the game
            while (continueGame) { 

                String userChecker = GUI.DecideIfContinue();

                switch (userChecker)
                {
                    case "m":
                        linesToPlay = new(GUI.ChooseLines());
                        credits = GameLogic.Spin(linesToPlay, credits, screen);
                        break;
                    case "y":
                        credits = GameLogic.Spin(linesToPlay, credits, screen);
                        break;
                }
            }                     
        }
    }
}