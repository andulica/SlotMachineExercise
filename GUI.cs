namespace SlotMachineExercise
{
    //comment line to test the commit
    internal class GUI
    {
        private const int MIN_LINE_TO_PLAY = 0;
        private const int MAX_LINE_TO_PLAY = 8;
        private const int GRID_SIZE = 3;

        //Prints to the console welcome message
        public static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to SlotsMachine Ultimate Experience!");
        }

        //Gets user input and checks if the amount of money is composed of numbers only. If so, is being accepted as a valid input
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

                if (credits < linesToPlay.Count)
                {
                    Console.WriteLine("Insuficient funds!");
                }
                else
                {
                    return credits;
                }
            }          
        }

        //Prints the bet options for user to the console
        public static void PrintOptions()
        {
            Console.WriteLine(
                " \n        7            8  " +
                " \n          \\         /   " +
                " \n 1 --->  | x | x | x |  " +
                " \n         -------------  " +
                " \n 2 --->  | x | x | x |  " +
                " \n         -------------  " +
                " \n 3 --->  | x | x | x |  " +
                " \n           ^   ^   ^    " +
                " \n           |   |   |    " +
                " \n           4   5   6    ");
        }

        //prints the screen of the slotmachine to the console
        public static void DisplayGrid(int[,] screen)
        {
            for (int row = 0; row < GRID_SIZE; row++)
            {
                for (int col = 0; col < GRID_SIZE; col++)
                {
                    Console.Write(" " + screen[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        //takes user Lines and adds them to a list. If the list is
        public static List<int> ChooseLines()
        {
            List<int> linesToPlay = new List<int>();
            int chosenLine;

            bool finish = true;
            while (finish)
            {
                Console.WriteLine("\nPlease select which lines you want to play. " +
                    "\nEach line is equal with $1 bet and you can keep adding them until you reach maximum number of lines: ");
                bool validNumber = Int32.TryParse(Console.ReadLine(), out chosenLine);

                if (validNumber == false)
                {
                    Console.WriteLine("Do you really want to exit the choosing lines process ? If so, press 'y'");
                    String userChecker = Convert.ToString(Console.ReadLine());
                    if (userChecker.Equals("y"))
                    {
                        break;
                    }
                    else
                        continue;
                }

                if (linesToPlay.Count >= MAX_LINE_TO_PLAY)
                {
                    Console.WriteLine("Maximum number of lines to play have been reached.");
                    finish = false;
                }
                else if (linesToPlay.Contains(chosenLine))
                {
                    Console.WriteLine($"The line number {chosenLine} has been added already");
                }
                else if (chosenLine < MIN_LINE_TO_PLAY || chosenLine > MAX_LINE_TO_PLAY)
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

        public static String DecideIfContinue()
        {
            Console.WriteLine("If you wish to change the lines, please press 'm', otherwise press any button");
            return Convert.ToString(Console.ReadLine().ToLower());
        }

        public static void DisplayWinnings(int winnings)
        {
            Console.WriteLine($"You have won in total: {winnings} USD! ");
        }

        public static void DisplayCreditsLeft(int creditsLeft)
        {
            Console.WriteLine($"Total funds left = {creditsLeft} USD! ");
        }
    }
}

