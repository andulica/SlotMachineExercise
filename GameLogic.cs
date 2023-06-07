using System.Reflection.Metadata.Ecma335;

namespace SlotMachineExercise
{
    internal class GameLogic
    {
        private const int COUNTER_TO_CHECK_HORIZONTAL = 1;
        private const int COUNTER_TO_CHECK_VERTICAL = 4;
        private const int GRID_SIZE = 3;
        private const int ELEMENT_NUMBER = 3;
        private readonly static Random rnd = new Random();

        public enum SlotMachineLine
        {
            ALL_HOR = 3,
            ALL_VER = 6,
            DIAG_TL = 7,
            DIAG_TR = 8
        }

        public static int AllLinesChecker (List<int> linesToPlay, int credits, int[,] grid)
        {
            int winnings = 0;

            for (int i = 0; i < linesToPlay.Count; i++)
            {
                if (credits >= linesToPlay.Count)
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
        private static int CheckHorizontal(int[,] grid, int lineToCheck)
        {
            return (grid[lineToCheck, 0] == grid[lineToCheck, 1] && grid[lineToCheck, 0] == grid[lineToCheck, 2]) ? 1 : 0;
        }

        //Checks if player won on vertical lines
        private static int CheckVertical(int[,] grid, int lineToCheck)
        {
            return (grid[0, lineToCheck] == grid[1, lineToCheck] && grid[0, lineToCheck] == grid[2, lineToCheck]) ? 1 : 0;
        }

        //Checks if player won on diagonal line starting from top left corner
       private static int CheckDiagonalTopLeft(int[,] grid)
        {
            return (grid[0, 0] == grid[1, 1] && grid[0, 0] == grid[2, 2]) ? 1 : 0;
        }

        //Checks if player won on diagonal line starting from top right corner
        private static int CheckDiagonalTopRight(int[,] grid)
        {
            return (grid[0, 2] == grid[1, 1] && grid[0, 2] == grid[2, 0]) ? 1 : 0;
        }
    }
}
