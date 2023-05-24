
namespace SlotMachineExercise
{
    internal class Program
    {

        const int MAX_NUMBER_FOR_A_LINE = 8;
        const int COUNTER_TO_CHECK_HORIZONTAL = 1;
        const int COUNTER_TO_CHECK_VERTICAL = 4;
        const int GRID_SIZE = 3;
        static void Main(string[] args)
        {
            //Populates a 2D array representing the screen of the slotmachine
            Random rnd = new Random();
            int[,] screen = new int[GRID_SIZE, GRID_SIZE];
            for (int i = 0; i < GRID_SIZE; i++)
            {
                for (int j = 0; j < GRID_SIZE; j++)
                {
                    screen[i, j] = rnd.Next(1, GRID_SIZE);
                }
            }

            List<int> listChosenLines = new List<int>();

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

            Console.WriteLine("Please select how much you want to gamble: ");
            int gambleSum = Convert.ToInt32(Console.ReadLine());

            bool start = false;
            //loops until player decides to start. He needs to choose atleast 1 line
            while (!start)
            {
                Console.WriteLine("Each line is $1 bet. Please enter the coresponding number for each line that you want to play: ");

                int chosenLine = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                if (chosenLine <= MAX_NUMBER_FOR_A_LINE && chosenLine > 0 && !listChosenLines.Contains(chosenLine))
                {
                    listChosenLines.Add(chosenLine);
                }
                else
                {
                    Console.WriteLine("Please enter a number from 1 to 8!" +
                        "\nAlso no repeating lines allowed! ");
                }

                Console.WriteLine("If you want to enter more lines, press Enter. If not , enter Start: ");
                string checkUser = Convert.ToString(Console.ReadLine().ToLower());

                if (checkUser == "start" && listChosenLines.Count >= 1)
                {
                    start = true;
                }
            }

            printArray(screen);

            int sumWon = 0;

            Console.WriteLine("The lines you chose to play are:  ");
            foreach (int line in listChosenLines)
            {
                Console.Write($" {line} ");
            }
            Console.WriteLine();



            for (int i = 0; i < listChosenLines.Count; i++)
            {
                if (gambleSum >= listChosenLines.Count)
                {
                    if (listChosenLines[i] <= 3)
                    {
                        sumWon += checkHorizontal(screen, listChosenLines[i] - COUNTER_TO_CHECK_HORIZONTAL);
                    }

                    if (listChosenLines[i] > 3 && listChosenLines[i] <= 6)
                    {
                        sumWon += checkVertical(screen, listChosenLines[i] - COUNTER_TO_CHECK_VERTICAL);
                    }

                    if (listChosenLines[i] == 7)
                    {
                        sumWon += checkDiagonal1(screen);
                    }

                    if (listChosenLines[i] == 8)
                    {
                        sumWon += checkDiagonal2(screen);
                    }
                }
                else
                {
                    Console.WriteLine("Insuficient funds!");
                }
            }

            Console.WriteLine($"You have won in total:{sumWon} USD! ");

            int totalSum = (gambleSum - listChosenLines.Count) + sumWon;

            Console.WriteLine($"Total funds left = {totalSum} USD! ");
        }


        //prints the screen of the slotmachine to the console
        public static void printArray(int[,] twoDArray)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int k = 0; k < 3; k++)
                {
                    Console.Write(" " + twoDArray[i, k] + " ");
                }
                Console.WriteLine();
            }
        }

        //Checks if player won on horizontal lines
        public static int checkHorizontal(int[,] twoDArray, int lineToCheck)
        {
            if (twoDArray[lineToCheck, 0] == twoDArray[lineToCheck, 1] && twoDArray[lineToCheck, 0] == twoDArray[lineToCheck, 2])
            {
                return 1;
            }
            return 0;
        }

        //Checks if player won on vertical lines
        public static int checkVertical(int[,] twoDArray, int lineToCheck)
        {
            if (twoDArray[0, lineToCheck] == twoDArray[1, lineToCheck] && twoDArray[0, lineToCheck] == twoDArray[2, lineToCheck])
            {
                Console.WriteLine("This is vertical");
                return 1;
            }
            return 0;
        }

        //Checks if player won on diagonal from top left corner to bottom right corner
        public static int checkDiagonal1(int[,] twoDArray)
        {
            if (twoDArray[0, 0] == twoDArray[1, 1] && twoDArray[0, 0] == twoDArray[2, 2])
            {
                Console.WriteLine("This is diagonal");
                return 1;
            }
            return 0;
        }

        //Checks if player won on diagonal from top right corner to bottom left corner
        public static int checkDiagonal2(int[,] twoDArray)
        {
            if (twoDArray[0, 2] == twoDArray[1, 1] && twoDArray[0, 2] == twoDArray[2, 0])
            {
                Console.WriteLine("This is diagonal2");
                return 1;
            }
            return 0;
        }
    }
}