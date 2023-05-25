using static SlotMachineExercise.GameLogic;

namespace SlotMachineExercise
{
    internal class GameLogic
    {
        private const int COUNTER_TO_CHECK_HORIZONTAL = 1;
        private const int COUNTER_TO_CHECK_VERTICAL = 4;
        private const int GRID_SIZE = 3;
        private const int ELEMENT_NUMBER = 3;
        private readonly static Random rnd = new Random();

        public enum CountLineCheck
        {
            Horizontal = 3,
            Vertical = 6,
            DiagonalTopLeft = 7,
            DiagonalTopRight = 8
        }

        public static int allLinesChecker (List<int> listChosenLines, int gambleSum, int[,] screen)
        {
            int sumWon = 0;

            for (int i = 0; i < listChosenLines.Count; i++)
            {
                if (gambleSum >= listChosenLines.Count)
                {
                    if (listChosenLines[i] <= (int)CountLineCheck.Horizontal)

                    {
                        sumWon += checkHorizontal(screen, listChosenLines[i] - COUNTER_TO_CHECK_HORIZONTAL);
                    }

                    if (listChosenLines[i] > (int)CountLineCheck.Horizontal && listChosenLines[i] <= (int)CountLineCheck.Vertical)
                    {
                        sumWon += checkVertical(screen, listChosenLines[i] - COUNTER_TO_CHECK_VERTICAL);
                    }

                    if (listChosenLines[i] == (int)CountLineCheck.DiagonalTopLeft)
                    {
                        sumWon += checkDiagonalTopLeft(screen);
                    }

                    if (listChosenLines[i] == (int)CountLineCheck.DiagonalTopRight)
                    {
                        sumWon += checkDiagonalTopRight(screen);
                    }
                }
                else
                {
                    Console.WriteLine("Insuficient funds!");
                }
            }

            Console.WriteLine($"You have won in total:{sumWon} USD! ");

            int sumLeftAfterSpin = (gambleSum - listChosenLines.Count) + sumWon;

            Console.WriteLine($"Total funds left = {sumLeftAfterSpin} USD! ");

            return sumLeftAfterSpin;
                  
        }

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

        //Checks if player won on horizontal lines
        private static int checkHorizontal(int[,] twoDArray, int lineToCheck)
        {
            if (twoDArray[lineToCheck, 0] == twoDArray[lineToCheck, 1] && twoDArray[lineToCheck, 0] == twoDArray[lineToCheck, 2])
            {
                return 1;
            }
            return 0;
        }

        //Checks if player won on vertical lines
        private static int checkVertical(int[,] twoDArray, int lineToCheck)
        {
            if (twoDArray[0, lineToCheck] == twoDArray[1, lineToCheck] && twoDArray[0, lineToCheck] == twoDArray[2, lineToCheck])
            {                
                return 1;
            }
            return 0;
        }

        //Checks if player won on diagonal from top left corner to bottom right corner
        private static int checkDiagonalTopLeft(int[,] twoDArray)
        {
            if (twoDArray[0, 0] == twoDArray[1, 1] && twoDArray[0, 0] == twoDArray[2, 2])
            {                
                return 1;
            }
            return 0;
        }

        //Checks if player won on diagonal from top right corner to bottom left corner
        private static int checkDiagonalTopRight(int[,] twoDArray)
        {
            if (twoDArray[0, 2] == twoDArray[1, 1] && twoDArray[0, 2] == twoDArray[2, 0])
            {
                return 1;
            }
            return 0;
        }     
    }
}
