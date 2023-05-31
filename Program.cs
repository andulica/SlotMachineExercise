namespace SlotMachineExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int creditsLeftAfterSpin = 0;                  
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

                //user presses 'm' which means that he chose to change the play values
                if (userChecker.Equals("m"))
                {
                    linesToPlay = new(GUI.ChooseLines());
                    if (creditsLeftAfterSpin < linesToPlay.Count)
                    {
                        creditsLeftAfterSpin += GUI.MoneyToPlay();
                    }
                    int[,] newScreen = GameLogic.PopulateGrid();
                    creditsLeftAfterSpin = GameLogic.AllLinesChecker(linesToPlay, creditsLeftAfterSpin, newScreen);
                    GUI.DisplayGrid(newScreen);
                    previousSpinSuccessful = true;

                }
                //user presses 'y' which means that he chose to play the same values from the previous successful spin
                else if (userChecker.Equals("y"))
                {                  
                    if (linesToPlay.Count > creditsLeftAfterSpin)
                    {
                        creditsLeftAfterSpin += GUI.MoneyToPlay();
                    }
                    else
                    {
                        int[,] generateNewScreen = GameLogic.PopulateGrid();
                        creditsLeftAfterSpin = GameLogic.AllLinesChecker(linesToPlay, creditsLeftAfterSpin, generateNewScreen);
                        GUI.DisplayGrid(generateNewScreen);
                        previousSpinSuccessful = true;

                    }
                }         
            }
        }   
    }
}