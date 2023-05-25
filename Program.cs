namespace SlotMachineExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int creditsLeftAfterSpin = 0;
            List<int> newLinesToPlay = new List<int>();           
            bool previousSpinSuccessful = false;

            GUI.welcomeMessage();
            GUI.printOptions();
            List<int> linesToPlay = new (GUI.chooseLines());
            int credits = GUI.moneyToPlay();
            int[,] screen = GameLogic.populateScreen();
            bool continueGame = true;


            //keeps playing until user decides to quite the game
            while (continueGame)
            {
                if (previousSpinSuccessful == false)
                {
                    creditsLeftAfterSpin = GameLogic.allLinesChecker(linesToPlay, credits, screen);
                    GUI.printScreen(screen);
                }

                Console.WriteLine("If you wish to continue with the same gamble, please press 'y.' \nAlternatively, if you prefer to modify your playing values, press 'm'.");
                String userChecker = Convert.ToString(Console.ReadLine().ToLower());


                if (userChecker.Equals("m"))
                {
                    newLinesToPlay = new(GUI.chooseLines());
                    if (creditsLeftAfterSpin < newLinesToPlay.Count)
                    {
                        creditsLeftAfterSpin = +GUI.moneyToPlay();
                    }
                    int[,] newScreen = GameLogic.populateScreen();
                    creditsLeftAfterSpin = GameLogic.allLinesChecker(newLinesToPlay, creditsLeftAfterSpin, newScreen);
                    GUI.printScreen(newScreen);
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
                        creditsLeftAfterSpin = +GUI.moneyToPlay();
                    }
                    else
                    {
                        int[,] generateNewScreen = GameLogic.populateScreen();
                        creditsLeftAfterSpin = GameLogic.allLinesChecker(newLinesToPlay, creditsLeftAfterSpin, generateNewScreen);
                        GUI.printScreen(generateNewScreen);
                        previousSpinSuccessful = true;

                    }
                }         
            }
        }   
    }
}