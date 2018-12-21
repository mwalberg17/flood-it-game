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
        private const int _squareSize = 20; // Constant int to easily change the size of each square
        private int _boardSize;             // Int to hold the size of the rows and columns of the current game
        private int _turnsAllowed;          // Int representing the amount of turns allowed in the current game
        private int _turn = 0;             // Int representing which turn the user is on
        private int[,] _boardArray;        // 2-Dimensional array to hold numeric value of color


        public UserInterface()
        {
            InitializeComponent();
            _boardSize = Convert.ToInt32(uxSizeList.Text.Substring(0, 2)); // Sets to value in drop down box
            TurnsAllowed();                                                // Calls method to set _turnsAllowed int
            CreateBoardArray();
            DrawBoard();
            uxTurns.Text = "Turns: " + _turn + "/" + _turnsAllowed;
        }

        private void CreateBoardArray()
        {
            _boardArray = new int[_boardSize, _boardSize];
            Random rand = new Random();
            for (int row = 0; row < _boardSize; row++)
            {
                for (int col = 0; col < _boardSize; col++)
                {
                    _boardArray[row, col] = rand.Next(1, 6);
                }
            }
        }

        private void DrawBoard()
        {
            uxBoard.Width = _squareSize * _boardSize;
            uxBoard.Height = uxBoard.Width; //maybe + _squareSize
            Padding pad = new Padding();
            pad.Left = 0;
            pad.Right = 0;
            while (uxBoard.Controls.Count > 0)
            {
                uxBoard.Controls.Clear();
            }
            for (int row = 0; row < _boardSize; row++)
            {
                for (int col = 0; col < _boardSize; col++)
                {
                    Label square = new Label();
                    square.Width  = _squareSize;
                    square.Height = _squareSize;
                    square.Margin = pad;
                    int temp = _boardArray[row, col];
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
                    square.Name = temp.ToString();
                    square.Click += new EventHandler(Square_Click);
                    uxBoard.Controls.Add(square);
                    //initialize turns number
                }
            }
        }

        private void TurnsAllowed()
        {
            switch (_boardSize)
            {
                case 10:
                    _turnsAllowed = 17;
                    break;
                case 14:
                    _turnsAllowed = 25;
                    break;
                case 18:
                    _turnsAllowed = 32;
                    break;
                default:
                    _turnsAllowed = 100;
                    break;
            }
        }

        private void FloodFill(int newColor, int oldColor, int row, int col) //or "RedrawBoard()"
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
            if (row < _boardSize - 1)
            {
                FloodFill(newColor, oldColor, row + 1, col);
            }
            if (col > 0)
            {
                FloodFill(newColor, oldColor, row, col - 1);
            }
            if (col < _boardSize - 1)
            {
                FloodFill(newColor, oldColor, row, col + 1);
            }
        }

        // Maybe instead of having this. Maybe keep a private counter in UserInterface that
        // gets incremented everytime flood fill algorithm goes
        private void Square_Click(object sender, EventArgs e)
        {
            int temp = Convert.ToInt32(((Label)sender).Name);
            if (temp == _boardArray[0, 0])
            {
                return;
            }
            else
            {
                FloodFill(temp, _boardArray[0, 0], 0, 0);
                DrawBoard(); //redrawBoard
                _turn++;
                //if won
                    //end game
                //else
                    //if no more turns
                        //end game
                    //else
                        
                    

            }
                //FloodFill();
                //If the player
        }

        private void uxNewGame_Click(object sender, EventArgs e)
        {
            _boardSize = Convert.ToInt32(uxSizeList.Text.Substring(0,2));
            _turn = 0;
            DrawBoard();
        }
    }
}
