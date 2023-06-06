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

        public static int AllLinesChecker (List<int> linesToPlay, int credits, int[,] grid)
        {
            int winnings = 0;

            for (int i = 0; i < linesToPlay.Count; i++)
            {
                if (credits >= linesToPlay.Count)
                {
                    if (linesToPlay[i] <= (int)CountLineCheck.Horizontal)

                    {
                        winnings += CheckHorizontal(grid, linesToPlay[i] - COUNTER_TO_CHECK_HORIZONTAL);
                    }

                    if (linesToPlay[i] > (int)CountLineCheck.Horizontal && linesToPlay[i] <= (int)CountLineCheck.Vertical)
                    {
                        winnings += CheckVertical(grid, linesToPlay[i] - COUNTER_TO_CHECK_VERTICAL);
                    }

                    if (linesToPlay[i] == (int)CountLineCheck.DiagonalTopLeft)
                    {
                        winnings += CheckDiagonalTopLeft(grid);
                    }

                    if (linesToPlay[i] == (int)CountLineCheck.DiagonalTopRight)
                    {
                        winnings += CheckDiagonalTopRight(grid);
                    }
                }
                else
                {
                    GUI.DisplayMsgInsufficientCredits();
                }
            }

            GUI.DisplayWinnings(winnings);

            credits = (credits - linesToPlay.Count) + winnings;

            GUI.DisplayCreditsLeft(credits);

            return credits;
                  
        }

        public static int Spin (List<int> linesToPlay, int credits, int[,] grid)          
        {
            if (linesToPlay.Count > credits)
            {
                credits += GUI.MoneyToPlay();
            }
            grid = GameLogic.PopulateGrid();            
            GUI.DisplayGrid(grid);
            return GameLogic.AllLinesChecker(linesToPlay, credits, grid);
        }

        public static int[,] PopulateGrid()
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
        private static int CheckHorizontal(int[,] twoDArray, int lineToCheck)
        {
            return (twoDArray[lineToCheck, 0] == twoDArray[lineToCheck, 1] && twoDArray[lineToCheck, 0] == twoDArray[lineToCheck, 2]) ? 1 : 0;
        }

        //Checks if player won on vertical lines
        private static int CheckVertical(int[,] twoDArray, int lineToCheck)
        {
            return (twoDArray[0, lineToCheck] == twoDArray[1, lineToCheck] && twoDArray[0, lineToCheck] == twoDArray[2, lineToCheck]) ? 1 : 0;
        }

        //Checks if player won on diagonal from top left corner to bottom right corner
        private static int CheckDiagonalTopLeft(int[,] twoDArray)
        {
            return (twoDArray[0, 0] == twoDArray[1, 1] && twoDArray[0, 0] == twoDArray[2, 2]) ? 1 : 0;
        }

        //Checks if player won on diagonal from top right corner to bottom left corner
        private static int CheckDiagonalTopRight(int[,] twoDArray)
        {
            return (twoDArray[0, 2] == twoDArray[1, 1] && twoDArray[0, 2] == twoDArray[2, 0]) ? 1 : 0;
        }     
    }
}
