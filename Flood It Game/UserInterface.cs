/* UserInterface.cs
 * Author: Matthew Walberg
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flood_It_Game
{
    public partial class UserInterface : Form
    {   
        /// <summary>
        /// Constant int holding the size in pixels for each square
        /// </summary>
        private const int _squareSize = 20; 

        /// <summary>
        /// Size of rows and columns of current game
        /// </summary>
        private int _boardSize;

        /// <summary>
        /// Turn user is on
        /// </summary>
        private int _turn = 0;

        /// <summary>
        /// Creates game object
        /// </summary>
        private Game _game;
        
        /// <summary>
        /// Create GUI and sets up game.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
            _boardSize = Convert.ToInt32(uxSizeList.Text.Substring(0, 2)); // Sets to value in drop down box
            _game = new Game(_boardSize);
            DrawBoard(_game.GetBoard());
            uxTurns.Text = "Turns: " + _turn + "/" + _game.Turns;
        }
        
        /// <summary>
        /// Creates a new game board
        /// </summary>
        /// <param name="board">2D board with all the color values</param>
        private void DrawBoard(int [,] board)
        {
            uxBoard.Width = _squareSize * _boardSize;
            uxBoard.Height = uxBoard.Width; 
            Padding pad = new Padding();
            pad.Left = 0;
            pad.Right = 0;
            while (uxBoard.Controls.Count > 0)
            {
                uxBoard.Controls.Clear();
            }
            if (_boardSize == 10)
            {
                uxBoard.Location = new Point(91, 118);
            }
            else if (_boardSize == 14)
            {
                uxBoard.Location = new Point(51, 78);
            }
            else
            {
                uxBoard.Location = new Point(11, 38);
            }
            for (int row = 0; row < _boardSize; row++)
            {
                for (int col = 0; col < _boardSize; col++)
                {
                    Label square = new Label();
                    square.Width  = _squareSize;
                    square.Height = _squareSize;
                    square.Margin = pad;
                    int temp = board[row, col];
                    switch (temp)
                    {
                        case 1:
                            square.BackColor = Color.Red;
                            break;
                        case 2:
                            square.BackColor = Color.Blue;
                            break;
                        case 3:
                            square.BackColor = Color.Orange;
                            break;
                        case 4:
                            square.BackColor = Color.Green;
                            break;
                        case 5:
                            square.BackColor = Color.Purple;
                            break;
                        case 6:
                            square.BackColor = Color.Yellow;
                            break;
                    }
                    square.Name = row + "," + col;
                    square.Click += new EventHandler(Square_Click);
                    uxBoard.Controls.Add(square);
                    
                }
            }
        }

        /// <summary>
        /// Redraws the board without creating a new one
        /// </summary>
        /// <param name="board">2D board with all the color values</param>
        private void RedrawBoard(int [,] board)
        {
            for (int row = 0; row < _boardSize; row++)
            {
                for (int col = 0; col < _boardSize; col++)
                {
                    Label square = (Label)uxBoard.Controls[row + "," + col];
                    int temp = board[row, col];
                    switch (temp)
                    {
                        case 1:
                            square.BackColor = Color.Red;
                            break;
                        case 2:
                            square.BackColor = Color.Blue;
                            break;
                        case 3:
                            square.BackColor = Color.Orange;
                            break;
                        case 4:
                            square.BackColor = Color.Green;
                            break;
                        case 5:
                            square.BackColor = Color.Purple;
                            break;
                        case 6:
                            square.BackColor = Color.Yellow;
                            break;
                    }
                }
            }
        }
        
        /// <summary>
        /// Handles the event of the user clicking on one of the squares of the board.
        /// Uses flood fill algorithm, redraws board, and checks for if won or lost.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Square_Click(object sender, EventArgs e)
        {
            string[] coords = ((Label)sender).Name.Split(',');
            int[,] board = _game.GetBoard();
            int temp = board[Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1])];
            if (temp == board[0, 0])
            {
                return;
            }
            else
            {
                _game.FloodFill(temp, board[0, 0], 0, 0);
                RedrawBoard(_game.GetBoard()); 
                _turn++;
                uxTurns.Text = "Turns: " + _turn + "/" + _game.Turns;
                if (_game.CheckWin())
                {
                    uxBoard.Enabled = false;
                    MessageBox.Show("You won!");
                }
                else
                {
                    if (_game.Turns == _turn)
                    {
                        uxBoard.Enabled = false;
                        MessageBox.Show("Oh no! You lost.");
                    }
                }
            }
        }
        
        /// <summary>
        /// Handles when new game button is clicked. Restarts game with values in drop down boxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxNewGame_Click(object sender, EventArgs e)
        {
            uxBoard.Visible = false;
            uxBoard.Enabled = true;
            _boardSize = Convert.ToInt32(uxSizeList.Text.Substring(0,2));
            _game = new Game(_boardSize);
            _turn = 0;
            uxTurns.Text = "Turns: " + _turn + "/" + _game.Turns;
            DrawBoard(_game.GetBoard());
            uxBoard.Visible = true;
        }
    }
}