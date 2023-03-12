
namespace SlotMachineExercise
{
    internal class Program
    {


        static void Main(string[] args)
        {

            Random rnd = new Random();
            int[,] screen = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    screen[i, j] = rnd.Next(1, 3);

                }
            }

            List<int> listChosenLines = new List<int>();
            bool start = false;


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


            //loops until player decides to start. He needs to choose atleast 1 line
            while (!start)

            {

                Console.WriteLine("Each line is $1 bet. Please enter the coresponding number for each line: ");

                int chosenLine = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                if (chosenLine <= 8 && chosenLine > 0 && !listChosenLines.Contains(chosenLine))
                {
                    listChosenLines.Add(chosenLine);
                }
                else
                {
                    Console.WriteLine("Please enter a number from 0 to 8!" +
                        "\nAlso no repeating lines allowed! ");
                }



                Console.WriteLine("If you want to enter more lines, press Enter. If not , enter Start: ");
                string checkUser = Convert.ToString(Console.ReadLine().ToLower());

                if (checkUser == "start" && listChosenLines.Count >= 1)
                {

                    start = true;
                }

            }

            Console.WriteLine("Please select how much you want to gamble: ");
            int gambleSum = Convert.ToInt32(Console.ReadLine());


            printArray(screen);

            int sumWon = 0;

            Console.WriteLine($"This lines you chose to play are:  ");

            foreach (int line in listChosenLines)
            {
                Console.Write($" {line} ");
            }
            Console.WriteLine();

            if (gambleSum >= listChosenLines.Count)
            {

                if (listChosenLines.Contains(1))
                {
                    sumWon += checkHorizontal(screen, 0);
                }
                if (listChosenLines.Contains(2))
                {
                    sumWon += checkHorizontal(screen, 1);
                }
                if (listChosenLines.Contains(3))
                {
                    sumWon += checkHorizontal(screen, 2);
                }
                if (listChosenLines.Contains(4))
                {
                    sumWon += checkVertical(screen, 0);
                }
                if (listChosenLines.Contains(5))
                {
                    sumWon += checkVertical(screen, 1);
                }
                if (listChosenLines.Contains(6))
                {
                    sumWon += checkVertical(screen, 2);
                }
                if (listChosenLines.Contains(7))
                {
                    sumWon += checkDiagonal1(screen);
                }
                if (listChosenLines.Contains(8))
                {
                    sumWon += checkDiagonal2(screen);
                }

                Console.WriteLine($"You have won in total:{sumWon} USD! ");

                int totalSum = (gambleSum - listChosenLines.Count) + sumWon;

                Console.WriteLine($"Total funds left = {totalSum} USD! ");
            }

            else
            {
                Console.WriteLine("Insuficient funds: ");
            }


        }


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


        public static int checkHorizontal(int[,] twoDArray, int lineToCheck)
        {

            if (twoDArray[lineToCheck, 0] == twoDArray[lineToCheck, 1] && twoDArray[lineToCheck, 0] == twoDArray[lineToCheck, 2])
            {

                Console.WriteLine("This is horizontal");
                return 1;
            }
            return 0;
        }


        public static int checkVertical(int[,] twoDArray, int lineToCheck)
        {

            if (twoDArray[0, lineToCheck] == twoDArray[1, lineToCheck] && twoDArray[0, lineToCheck] == twoDArray[2, lineToCheck])
            {

                Console.WriteLine("This is vertical");
                return 1;
            }
            return 0;

        }

        public static int checkDiagonal1(int[,] twoDArray)
        {

            if (twoDArray[0, 0] == twoDArray[1, 1] && twoDArray[0, 0] == twoDArray[2, 2])
            {

                Console.WriteLine("This is diagonal");
                return 1;
            }

            return 0;
        }

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