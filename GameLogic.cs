namespace SlotMachineExercise
{
    internal class GameLogic
    {
        private const int COUNTER_TO_CHECK_HORIZONTAL = 1;
        private const int COUNTER_TO_CHECK_VERTICAL = 4;
        private const int ELEMENT_NUMBER = 3;
        private readonly static Random rnd = new Random();

        public enum SlotMachineLine
        {
            ALL_HOR = 3,
            ALL_VER = 6,
            DIAG_TL = 7,
            DIAG_TR = 8
        }

        /// <summary>
        /// Checks if there are any matching lines. If matches are found, total credits won are returned
        /// </summary>
        /// <param name="linesToPlay"></param>
        /// <param name="grid"></param>
        /// <returns>A Integer representing the total winnings</returns>
        public static int CheckAllLines(List<int> linesToPlay, int[,] grid)
        {
            int winnings = 0;

            for (int i = 0; i < linesToPlay.Count; i++)
            {
                if (linesToPlay[i] <= (int)SlotMachineLine.ALL_HOR)
                {
                    winnings += CheckHorizontal(grid, linesToPlay[i] - COUNTER_TO_CHECK_HORIZONTAL);
                }

                if (linesToPlay[i] > (int)SlotMachineLine.ALL_HOR && linesToPlay[i] <= (int)SlotMachineLine.ALL_VER)
                {
                    winnings += CheckVertical(grid, linesToPlay[i] - COUNTER_TO_CHECK_VERTICAL);
                }

                if (linesToPlay[i] == (int)SlotMachineLine.DIAG_TL)
                {
                    winnings += CheckDiagonalTopLeft(grid);
                }

                if (linesToPlay[i] == (int)SlotMachineLine.DIAG_TR)
                {
                    winnings += CheckDiagonalTopRight(grid);
                }
            }
            return winnings;
        }
        /// <summary>
        /// Populates a grid 3x3 randomly with values of 1 and 2
        /// </summary>
        /// <returns>A 2D array</returns>
        public static int[,] PopulateGrid()
        {
            //Populates a 2D array representing the screen of the slotmachine
            int[,] screen = new int[Constants.GRID_SIZE, Constants.GRID_SIZE];
            for (int row = 0; row < Constants.GRID_SIZE; row++)
            {
                for (int col = 0; col < Constants.GRID_SIZE; col++)
                {
                    screen[row, col] = rnd.Next(1, ELEMENT_NUMBER);
                }
            }
            return screen;
        }

        /// <summary>
        /// Checks if player won on horizontal lines
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="lineToCheck"></param>
        /// <returns>A Integer representing the winnings on horizontal lines</returns>
        private static int CheckHorizontal(int[,] grid, int lineToCheck)
        {
            return (grid[lineToCheck, 0] == grid[lineToCheck, 1] && grid[lineToCheck, 0] == grid[lineToCheck, 2]) ? 1 : 0;
        }
        /// <summary>
        /// Checks if player won on vertical lines
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="lineToCheck"></param>
        /// <returns>A Integer representing the winnings on vertical lines</returns>
        private static int CheckVertical(int[,] grid, int lineToCheck)
        {
            return (grid[0, lineToCheck] == grid[1, lineToCheck] && grid[0, lineToCheck] == grid[2, lineToCheck]) ? 1 : 0;
        }
        /// <summary>
        /// Checks if player won on diagonal line starting from top left corner
        /// </summary>
        /// <param name="grid"></param>
        /// <returns>A Integer representing the win on vertical line starting from top left corner</returns>
        private static int CheckDiagonalTopLeft(int[,] grid)
        {
            return (grid[0, 0] == grid[1, 1] && grid[0, 0] == grid[2, 2]) ? 1 : 0;
        }

        /// <summary>
        /// Checks if player won on diagonal line starting from top right corner
        /// </summary>
        /// <param name="grid"></param>
        /// <returns>A Integer representing the win on vertical line starting from top right corner</returns>
        private static int CheckDiagonalTopRight(int[,] grid)
        {
            return (grid[0, 2] == grid[1, 1] && grid[0, 2] == grid[2, 0]) ? 1 : 0;
        }
    }
}
