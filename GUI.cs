namespace SlotMachineExercise
{
    internal class GUI
    {
        /// <summary>
        /// Prints to the console welcome message.
        /// </summary>
        public static void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to SlotsMachine Ultimate Experience!");
        }

        /// <summary>
        ///  Gets user input and checks if the amount of money is composed of numbers only. If so, is being accepted as a valid input.
        /// </summary>
        /// <param name="linesToPlay"></param>
        /// <returns>the added credits.</returns>
        public static int GetMoneyToPlay()
        {
            while (true)
            {
                Console.WriteLine("Please enter the ammount of money you want to gamble: ");
                String stringCredits = Console.ReadLine();
                int credits;

                if (!int.TryParse(stringCredits, out credits))
                {
                    Console.WriteLine("Please enter any ammount of money represented in numbers only");
                }
                else
                {
                    return credits;
                }
            }
        }

        /// <summary>
        /// Prints the line choosing options for user to the console.
        /// </summary>
        public static void DisplayLineOptions()
        {
            Console.WriteLine(
                " \n        7            8  " +
                " \n          \\         /  " +
                " \n 1 --->  | x | x | x |  " +
                " \n         -------------  " +
                " \n 2 --->  | x | x | x |  " +
                " \n         -------------  " +
                " \n 3 --->  | x | x | x |  " +
                " \n           ^   ^   ^    " +
                " \n           |   |   |    " +
                " \n           4   5   6    ");

            Console.WriteLine(
            "\n   Here are your line options:" +
            "\n   1: Horizontal line 1" +
            "\n   2: Horizontal line 2" +
            "\n   3: Horizontal line 3" +
            "\n   4: Vertical line 1" +
            "\n   5: Vertical line 2" +
            "\n   6: Vertical line 3" +
            "\n   7: Diagonal line from top left" +
            "\n   8: Diagonal line from top right");
        }

        /// <summary>
        /// Prints the grid of the slotmachine to the console.
        /// </summary>
        /// <param name="screen"></param>
        public static void DisplaySlotMachineGrid(int[,] screen)
        {
            for (int row = 0; row < Constants.GRID_SIZE; row++)
            {
                Console.WriteLine("-----------------");
                for (int col = 0; col < Constants.GRID_SIZE; col++)
                {
                    Console.Write("| " + screen[row, col] + " | ");
                }
                Console.WriteLine();
            }
        }


        /// <summary>
        /// Prompts the user to select the lines that he wants to play. Also it takes the user input and checks if the entered value is a number.
        /// </summary>
        /// <returns>Returns a int representing the line number or a -1 representing line selection exit</returns>
        public static int GetValidLineSelection()
        {

            int chosenLine;
            Console.WriteLine("\nPlease select which lines you want to play. " +
                    "\nEach line is equal with $1 bet and you can keep adding them until you reach maximum number of lines: ");
            while (true)
            {
                bool validNumber = Int32.TryParse(Console.ReadLine(), out chosenLine);

                if (validNumber)
                {
                    return chosenLine;
                }

                char exitChoosingLines;
                GUI.ConfirmLineSelectionExitPrompt();
                Char.TryParse(Console.ReadLine(), out exitChoosingLines);
                if (exitChoosingLines.Equals(Constants.YES_ANSWER))
                {
                    break;
                }
            }
            return Constants.NEGATIVE_RETURN_VALUE;
        }

        /// <summary>
        /// Prompts the user if he really wants to exit line selection.
        /// </summary>
        public static void ConfirmLineSelectionExitPrompt()
        {
            Console.WriteLine("Do you really want to exit the choosing lines process? \nIf so, press 'y' or press any other key to continue adding lines: ");
        }

        /// <summary>
        /// Informs the user that maximum number of lines have been reached.
        /// </summary>
        public static void DisplayMaxLinesReachedMessage()
        {
            Console.WriteLine("Maximum number of lines to play have been reached.");
        }

        /// <summary>
        /// Informs the user that the line he had chose it was added already.
        /// </summary>
        /// <param name="chosenLine"></param>
        public static void AlertLineAlreadyAdded(int chosenLine)
        {
            Console.WriteLine($"The line number {chosenLine} has been added already");
        }

        /// <summary>
        /// Informs the user that the line he had chose is incorrect.
        /// </summary>
        /// <param name="chosenLine"></param>
        public static void AlertIncorrectLine(int chosenLine)
        {
            Console.WriteLine($"The line {chosenLine} is not correct, please enter another value between 1 and 8.");
        }

        /// <summary>
        /// Takes user input and return the line number introduced by the user.
        /// </summary>
        /// <returns>Returns the value entered by the user representing the line number.</returns>
        public static int GetUserInputLineNumber()
        {
            int chosenLine;
            bool validNumber = Int32.TryParse(Console.ReadLine(), out chosenLine);
            if (validNumber)
            {
                return chosenLine;
            }
            return 0;
        }

        /// <summary>
        /// Asks user if decides to continue to play with the same values or he wants to change them.
        /// </summary>
        /// <returns>A bool value. True if player decides to continue, false if he decides not to continue.</returns>
        public static bool GetUserContinueDecision()
        {
            char changeValue;
            Console.WriteLine("If you wish to change the lines, please press 'm', \n otherwise continue playing with the same values by pressing any key: ");
            bool changeValueTrue = Char.TryParse(Console.ReadLine(), out changeValue);
            if (changeValue.Equals(Constants.MODIFY_ANSWER))
            {
                return changeValueTrue;
            }
            return false;
        }

        /// <summary>
        /// Displays a message for invalid user input.
        /// </summary>
        public static void AlertNegativeNumber()
        {
            Console.WriteLine("No negative numbers are accepted.");
        }
        /// <summary>
        /// Displays winnings to the console.
        /// </summary>
        /// <param name="winnings"></param>
        public static void DisplayTotalWinnings(int winnings)
        {
            Console.WriteLine($"You have won in total: {winnings} USD! ");
        }

        /// <summary>
        /// Displays credits to the console.
        /// </summary>
        /// <param name="creditsLeft"></param>
        public static void DisplayTotalCredits(int creditsLeft)
        {
            Console.WriteLine($"Total funds left = {creditsLeft} USD! ");
        }

        /// <summary>
        /// Displays a message for insufficient funds.
        /// </summary>     
        public static void AlertInsufficientFunds()
        {
            Console.WriteLine("Insufficient funds! Please add more.");
        }

        /// <summary>
        /// Displays to the console the lines that player chose.
        /// </summary>
        /// <param name="chosenLines"></param>
        public static void DisplayChosenLines(List<int> chosenLines)
        {
            Console.Write($"Lines that you added are: ");
            foreach (int line in chosenLines)
            {
                Console.Write($" {line}, ");
            }
        }

        /// <summary>
        /// Player is asked to decide if he wants to exit or continue the game.
        /// </summary>
        /// <returns>A bool value. True if player decides to exit the game, false if he decides not to exit the game.</returns>
        public static bool GetUserExitGameDecision()
        {
            char exitAnswer;
            Console.WriteLine("\nYou don't enough credits to play. Do you want to quit the game? \nPress 'y' to exit or any other key to continue: ");
            bool userInputExit = Char.TryParse(Console.ReadLine(), out exitAnswer);
            if (exitAnswer.Equals(Constants.YES_ANSWER))
            {
                Console.WriteLine("Thank you for playing our game!");
                return userInputExit;
            }
            Console.WriteLine("You have chosen to continue!");
            return false;
        }
    }
}