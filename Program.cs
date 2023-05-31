namespace SlotMachineExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {                          
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
                    credits = GameLogic.Spin(screen, linesToPlay, credits);
                    GUI.DisplayGrid(screen);
                }

                String userChecker = GUI.DecideIfContinue();

                //user presses 'm' which means that he chose to change the play values
                if (userChecker.Equals("m"))
                {
                    linesToPlay = new(GUI.ChooseLines());                 
                    credits = GameLogic.Spin(screen, linesToPlay, credits);
                    previousSpinSuccessful = true;                    

                }
                //user presses 'y' which means that he chose to play the same values from the previous successful spin
                else if (userChecker.Equals("y"))
                {                                                                      
                    credits = GameLogic.Spin(screen, linesToPlay, credits);
                    previousSpinSuccessful = true;                  
                }         
            }
        }   
    }
}