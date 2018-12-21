using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flood_It_Game
{
    public class Game
    {
        // 























        private int _gameRows;
        private int _gameCols;
        private int[,] _board;

        public Game(int difficulty)
        {
            if (difficulty == 1)
            {
                Cols = 15;
                Rows = 15;
                CreateBoard();
            }
            else if (difficulty == 2)
            {
                Cols = 30;
                Rows = 30;
            }
            else
            {
                Cols = 45;
                Rows = 45;
            }
        }

        public int Rows { get; set; }
        public int Cols { get; set; }

        public void CreateBoard()
        {
            _board = new int[Rows, Cols];
            Random rand = new Random();
            for (int x = 0; x < Rows; x++)
            {
                for (int y = 0; y < Cols; y++)
                {
                    _board[x, y] = rand.Next(1, 6);
                }
            }
        }
        /// <summary>
        /// Checks the array representing the board for a win. Returns false if an unmatched
        /// </summary>
        /// <param name="board"></param>
        /// <param name="rows">Number of rows for the current game.</param>
        /// <param name="cols">Number of columns for the current game.</param>
        /// <returns></returns>
        public bool HasWon(int[,] board)
        {
            //Maybe instead of having this. Maybe keep a private counter in UserInterface that
            // gets incremented everytime flood fill algorithm goes

            //check if all corners are same and if so then do full check
            for (int x = 0; x < Rows; x++)
            {
                for (int y = 0; y < Cols; y++)
                {
                    if (board[x, y] != board[0, 0])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
