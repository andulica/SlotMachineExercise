namespace SlotMachineExercise
{
    //comment line to test the commit
    internal class GUI
    {
        private const int GRID_SIZE = 3;
        private const int MIN_LINE_TO_PLAY = 0;
        private const int MAX_LINE_TO_PLAY = 8;
        private const int ELEMENT_NUMBER = 3;
        private readonly static Random rnd = new Random();
        

        public static int[,] populateScreen()
        {
            //Populates a 2D array representing the screen of the slotmachine
            int[,] screen = new int[GRID_SIZE, GRID_SIZE];
            for (int row = 0; row < GRID_SIZE; row++)
            {
                for (int col = 0; col < GRID_SIZE; col++)
                {
                    screen[row, col] = rnd.Next(1, ELEMENT_NUMBER);
                }
            }
            return screen;
        }

        //Prints to the console welcome message
        public static void welcomeMessage()
        {
            Console.WriteLine("Welcome to SlotsMachine Ultimate Experience! ");
        }

        public static int moneyToPlay()
        {
            Console.WriteLine("Please enter the ammount of money you want to gamble: ");
            int moneyToPlay = Convert.ToInt32(Console.ReadLine());
            return moneyToPlay;
        }

        //Prints the bet options for user to the console
        public static void printOptions()
        {
            Console.WriteLine(
                " \n        7            8  " +
                " \n        '\\'        /   " +
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
        public static void printScreen(int[,] screen)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(" " + screen[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        //takes user Lines and adds them to a list. If the list is
        public static List<int> chooseLines()
        {
            List<int> chosenLines = new List<int>();
            int chosenLine = 0;

            bool finish = true;
            while (finish)
            {
                Console.WriteLine("Please select which lines you want to play. " +
                    "\nEach line is equal with $1 bet and you can keep adding them until you press 'n' or maximum number of lines is reached: ");
                try
                {
                    chosenLine = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    //instead of pressing n just make a function that presses exit or enter
                    Console.WriteLine("Do you really want to exit the choosing lines process ? If so, press 'y' or press 'n' to continue choosing more lines");
                    String userChecker = Convert.ToString(Console.ReadLine());
                    if (userChecker.Equals("y"))
                    {
                        finish = false;
                    }
                    else
                        continue;
                }

                if (chosenLines.Count > MAX_LINE_TO_PLAY || finish == false)
                {
                    finish = false;
                }
                else if (chosenLine < MIN_LINE_TO_PLAY || chosenLine > MAX_LINE_TO_PLAY || chosenLines.Contains(chosenLine))
                {
                    Console.WriteLine($"The line {chosenLine} is not correct, please enter another value");
                }
                else
                {
                    chosenLines.Add(chosenLine);                   

                }
            }

            return chosenLines;
        }
    }
}

