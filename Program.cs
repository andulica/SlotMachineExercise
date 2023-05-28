namespace SlotMachineExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int creditsLeftAfterSpin = 0;
            List<int> newLinesToPlay = new List<int>();           
            bool previousSpinSuccessful = false;

            GUI.WelcomeMessage();
            GUI.PrintOptions();
            List<int> linesToPlay = new (GUI.ChooseLines());
            int credits = GUI.MoneyToPlay();
            int[,] screen = GameLogic.PopulateGrid();
            bool continueGame = true;
            
            //keeps playing until user decides to quite the game
            while (continueGame)
            {
                if (previousSpinSuccessful == false)
                {
                    creditsLeftAfterSpin = GameLogic.AllLinesChecker(linesToPlay, credits, screen);
                    GUI.DisplayGrid(screen);
                }

                String userChecker = GUI.DecideIfContinue();

                if (userChecker.Contains("m"))
                {
                    newLinesToPlay = new(GUI.ChooseLines());
                    if (creditsLeftAfterSpin < newLinesToPlay.Count)
                    {
                        creditsLeftAfterSpin += GUI.MoneyToPlay();
                    }
                    int[,] newScreen = GameLogic.PopulateGrid();
                    creditsLeftAfterSpin = GameLogic.AllLinesChecker(newLinesToPlay, creditsLeftAfterSpin, newScreen);
                    GUI.DisplayGrid(newScreen);
                    previousSpinSuccessful = true;

                }
                else if (userChecker.Equals("y"))
                {
                    if (newLinesToPlay.Count == 0)
                    {
                        newLinesToPlay = linesToPlay;
                    }

                    if (newLinesToPlay.Count > creditsLeftAfterSpin)
                    {
                        creditsLeftAfterSpin += GUI.MoneyToPlay();
                    }
                    else
                    {
                        int[,] generateNewScreen = GameLogic.PopulateGrid();
                        creditsLeftAfterSpin = GameLogic.AllLinesChecker(newLinesToPlay, creditsLeftAfterSpin, generateNewScreen);
                        GUI.DisplayGrid(generateNewScreen);
                        previousSpinSuccessful = true;

                    }
                }         
            }
        }   
    }
}