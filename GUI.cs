namespace SlotMachineExercise
{
    internal class GUI
    {
        /// <summary>
        /// Prints to the console welcome message
        /// </summary>
        public static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to SlotsMachine Ultimate Experience!");
        }

        /// <summary>
        ///  Gets user input and checks if the amount of money is composed of numbers only. If so, is being accepted as a valid input
        /// </summary>
        /// <param name="linesToPlay"></param>
        /// <returns>the added credits</returns>
        public static int MoneyToPlay(List<int> linesToPlay)
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
        /// Prints the line choosing options for user to the console
        /// </summary>
        public static void PrintOptions()
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
        /// Prints the grid of the slotmachine to the console
        /// </summary>
        /// <param name="screen"></param>
        public static void DisplayGrid(int[,] screen)
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
        /// Takes user Lines and adds them to a list
        /// </summary>
        /// <returns>A list with the lines chosen by the user</returns>
        public static List<int> ChooseLines()
        {
            List<int> linesToPlay = new List<int>();
            int chosenLine;

            PrintOptions();
            bool finish = true;
            while (finish)
            {
                Console.WriteLine("\nPlease select which lines you want to play. " +
                    "\nEach line is equal with $1 bet and you can keep adding them until you reach maximum number of lines: ");
                bool validNumber = Int32.TryParse(Console.ReadLine(), out chosenLine);

                if (validNumber == false)
                {
                    Console.WriteLine("Do you really want to exit the choosing lines process? \nIf so, press 'y' or press any other key to continue adding lines: ");
                    char userChecker = Convert.ToChar(Console.ReadLine());
                    if (userChecker.Equals(Constants.YES_ANSWER))
                    {
                        break;
                    }
                    else
                        continue;
                }

                if (linesToPlay.Count >= Constants.MAX_LINE_TO_PLAY)
                {
                    Console.WriteLine("Maximum number of lines to play have been reached.");
                    finish = false;
                }
                else if (linesToPlay.Contains(chosenLine))
                {
                    Console.WriteLine($"The line number {chosenLine} has been added already");
                }
                else if (chosenLine < Constants.MIN_LINE_TO_PLAY || chosenLine > Constants.MAX_LINE_TO_PLAY)
                {
                    Console.WriteLine($"The line {chosenLine} is not correct, please enter another value between 1 and 8.");
                }
                else
                {
                    linesToPlay.Add(chosenLine);
                }

                Console.Write($"Lines that you added are: ");

                foreach (int line in linesToPlay)
                {
                    Console.Write($" {line}, ");
                }
            }
            return linesToPlay;
        }

        /// <summary>
        /// Asks user if decides to continue to play with the same values or he wants to change them
        /// </summary>
        /// <returns>A boolean value. True if player decides to contiue, false if he decides not to continue</returns>
        public static bool DecideIfContinue()
        {
            Console.WriteLine("If you wish to change the lines, please press 'm', \notherwise continue playing with the same values by pressing any key: ");
            char userInput =Convert.ToChar(Console.ReadLine());
            if (userInput.Equals(Constants.MODIFY_ANSWER))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Displays winnings to the console
        /// </summary>
        /// <param name="winnings"></param>
        public static void DisplayWinnings(int winnings)
        {
            Console.WriteLine($"You have won in total: {winnings} USD! ");
        }

        /// <summary>
        /// Displays credits to the console
        /// </summary>
        /// <param name="creditsLeft"></param>
        public static void DisplayCredits(int creditsLeft)
        {
            Console.WriteLine($"Total funds left = {creditsLeft} USD! ");
        }
        /// <summary>
        /// Displays a message for insufficient funds
        /// </summary>
        public static void InsufficientFunds()
        {
            Console.WriteLine("Insufficient funds! Please add more.");
        }
        /// <summary>
        /// Player is asked to decide if he wants to exit or continue the game
        /// </summary>
        /// <returns>A boolean value. True if player decides to exit the game, false if he decides not to exit the game.</returns>
        public static bool DecideIfExitGame()
        {
            Console.WriteLine("\nYou don't enough credits to play. Do you want to quit the game? \nPress 'y' to exit or any other key to continue: ");
            char userInput = Convert.ToChar(Console.ReadLine());
            if (userInput.Equals(Constants.YES_ANSWER))
            {
                Console.WriteLine("Thank you for playing our game!");
                return true;
            }
            Console.WriteLine("You have chosen to continue!");
            return false;
        }
    }
}