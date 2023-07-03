using System;

namespace SudokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new SudokuGame();
            game.Solve();
            game.DisplayGrid();
            Console.ReadKey();
        }
    }

    class SudokuGame
    {
        private readonly int[,] _grid = new[,]
        {
            {0, 3, 0, 0, 7, 0, 0, 0, 0},
            {6, 0, 0, 1, 9, 5, 0, 0, 0},
            {0, 9, 8, 0, 0, 0, 0, 6, 0},
            {8, 0, 0, 0, 6, 0, 0, 0, 3},
            {0, 0, 0, 8, 0, 3, 0, 0, 1},
            {7, 0, 0, 0, 2, 0, 0, 0, 6},
            {0, 6, 0, 0, 0, 0, 2, 8, 0},
            {0, 0, 0, 4, 0, 9, 0, 0, 0},
            {0, 0, 0, 0, 8, 0, 0, 7, 9}
        };

        public void Solve()
       {
            SolveSudoku(0,0);
        }

        public bool SolveSudoku(int row, int col)
        {
            if (row == 9)
            {
                row = 0;
                if (++col == 9)
                    return true;
            }

            if (_grid[row, col] != 0)
                return SolveSudoku(row + 1, col);

            for (int num = 1; num <= 9; num++)
            {
                if (IsValidInput(row, col, num))
                {
                    _grid[row, col] = num;
                    if (SolveSudoku(row + 1, col))
                        return true;
                }
            }

            _grid[row, col] = 0;
            return false;
        }

        private bool IsValidInput(int row, int col, int num)
        {
            for (int i = 0; i < 9; i++)
            {
                if (_grid[row, i] == num || _grid[i, col] == num || _grid[3 * (row / 3) + i / 3, 3 * (col / 3) + i % 3] == num)
                    return false;
            }
            return true;
        }

        public void DisplayGrid()
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    Console.Write(_grid[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}