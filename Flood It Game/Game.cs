/* Game.cs
 * Author: Matthew Walberg
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flood_It_Game
{
    /// <summary>
    /// Game class to hold most logic for the flood-it game.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Size fo the rows and columns in the current game.
        /// </summary>
        private int _size;

        /// <summary>
        /// 2D array holding the color numeric values of each square.
        /// </summary>
        private int[,] _boardArray;

        /// <summary>
        /// Constructor for game class setting size, creating the board, and setting turns.
        /// </summary>
        /// <param name="size">Size of board</param>
        public Game(int size)
        {
            _size = size;
            CreateBoardArray();
            TurnsAllowed();
        }

        /// <summary>
        /// Amount of allowed turns for the current game.
        /// </summary>
        public int Turns { get; set; }

        /// <summary>
        /// Fills 2D array with random numbers between 1 and 6 representing the color values.
        /// </summary>
        private void CreateBoardArray()
        {
            _boardArray = new int[_size, _size];
            Random rand = new Random();
            for (int row = 0; row < _size; row++)
            {
                for (int col = 0; col < _size; col++)
                {
                    _boardArray[row, col] = rand.Next(1, 6);
                }
            }
        }

        /// <summary>
        /// Sets Turns property for specific size of board.
        /// </summary>
        private void TurnsAllowed()
        {
            switch (_size)
            {
                case 10:
                    Turns = 17;
                    break;
                case 14:
                    Turns = 25;
                    break;
                case 18:
                    Turns = 32;
                    break;
                default:
                    Turns = 100;
                    break;
            }
        }

        /// <summary>
        /// Returns 2D board.
        /// </summary>
        /// <returns>Board filled with numeric color values.</returns>
        public int[,] GetBoard()
        {
            return _boardArray;
        }

        /// <summary>
        /// Flood fill algorithm using recursion to change all squares with same color value of [0,0] that are
        /// connected by cardinal directions to the new color.
        /// </summary>
        /// <param name="newColor"></param>
        /// <param name="oldColor"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public void FloodFill(int newColor, int oldColor, int row, int col)
        {
            if (_boardArray[row, col] != oldColor)
            {
                return;
            }
            _boardArray[row, col] = newColor;
            if (row > 0)
            {
                FloodFill(newColor, oldColor, row - 1, col);
            }
            if (row < _size - 1)
            {
                FloodFill(newColor, oldColor, row + 1, col);
            }
            if (col > 0)
            {
                FloodFill(newColor, oldColor, row, col - 1);
            }
            if (col < _size - 1)
            {
                FloodFill(newColor, oldColor, row, col + 1);
            }
        }

        /// <summary>
        /// Checks if all squares are the same color, indicating a win.
        /// </summary>
        /// <returns>Whether the user has won the game.</returns>
        public bool CheckWin()
        {
            if (_boardArray[_size - 1, _size - 1] != _boardArray[0, 0])
            {
                return false;
            }
            for (int x = 0; x < _size; x++)
            {
                for (int y = 0; y < _size; y++)
                {
                    if (_boardArray[x, y] != _boardArray[0, 0])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
