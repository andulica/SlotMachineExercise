
namespace SlotMachineExercise
{
    internal class Program
    {

        private static int p1 = 0;
        private static int p2 = 0;
        private static int sum = 0;


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



            while (!start)

            {

                Console.WriteLine("Please enter the number corresponding for each line." +
                    "\n For each line it would be 1 USD bet: ");
                int chosenLine = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                if (chosenLine <= 8 && chosenLine > 0)
                {
                    listChosenLines.Add(chosenLine);
                }
                else
                {
                    Console.WriteLine("Please enter a number from 0 to 8: ");
                }



                Console.WriteLine("If you want to enter more lines, press Enter. If not , enter Start: ");
                string checkUser = Convert.ToString(Console.ReadLine().ToLower());

                if (checkUser == "start")
                {

                    start = true;
                }

            }

            Console.WriteLine("Please select how much you want to gamble: ");
            int gambleSum = Convert.ToInt32(Console.ReadLine());


            printArray(screen);

            if (listChosenLines.Count <= gambleSum)
            {
                for (int i = 0; i < listChosenLines.Count; i++)
                {
                    if (listChosenLines[i] == 1)
                    {
                        checkHorizontal(screen);
                    }
                    else if (listChosenLines[i] == 2)
                    {
                        checkHorizontal(screen);
                    }
                    else if (listChosenLines[i] == 3)
                    {
                        checkHorizontal(screen);
                    }
                    else if (listChosenLines[i] == 4)
                    {
                        checkVertical(screen);
                    }
                    else if (listChosenLines[i] == 5)
                    {
                        checkVertical(screen);
                    }
                    else if (listChosenLines[i] == 6)
                    {
                        checkVertical(screen);
                    }
                    else if (listChosenLines[i] == 7)
                    {
                        checkDiagonal1(screen);
                    }
                    else if (listChosenLines[i] == 8)
                    {
                        checkDiagonal2(screen);
                    }

                }

            }

            else
            {
                Console.WriteLine("Insuficient funds: ");
            }

            Console.WriteLine("You have won in total: " + sum + " USD! ");

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


        public static int checkHorizontal(int[,] twoDArray)
        {
            if (twoDArray[p1, p2] == twoDArray[p1, p2 + 1] && twoDArray[p1, p2] == twoDArray[p1, p2 + 2])
            {
                sum += 1;
                Console.WriteLine("This is horizontal");
            }
            return sum;
        }


        public static int checkVertical(int[,] twoDArray)
        {

            if (twoDArray[p1, p2] == twoDArray[p1 + 1, p2] && twoDArray[p1, p2] == twoDArray[p1 + 2, p2])
            {
                sum += 1;
                Console.WriteLine("This is vertical");
            }


            return sum;
        }

        public static int checkDiagonal1(int[,] twoDArray)
        {

            if (twoDArray[p1, p2] == twoDArray[p1 + 1, p2 + 1] && twoDArray[p1, p2] == twoDArray[p1 + 2, p2 + 2])
            {
                sum += 1;
                Console.WriteLine("This is diagonal1");
            }


            return sum;
        }

        public static int checkDiagonal2(int[,] twoDArray)
        {

            if (twoDArray[p1, p2 + 2] == twoDArray[p1 + 1, p2 + 1] && twoDArray[p1, p2 + 2] == twoDArray[p1 + 2, p2])
            {
                sum += 1;
                Console.WriteLine("This is diagonal2");
            }


            return sum;
        }

    }
}