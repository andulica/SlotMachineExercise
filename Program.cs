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

            //keeps playing until user decides to quite the game
            credits = GameLogic.Spin(linesToPlay, credits, screen);
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