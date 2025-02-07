using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeNet
{
    public partial class Form1 : Form
    {
        string turn = "X";
        int turnCounter = 0;

        //Board Values:     O = 0,     X = 1,    open = -1
        int[] board = {
            -1, -1, -1,
            -1, -1, -1,
            -1, -1, -1
        };

        public Form1()
        {
            InitializeComponent();

        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            //Enable all spaces
            space0.Enabled = true;
            space1.Enabled = true;
            space2.Enabled = true;
            space3.Enabled = true;
            space4.Enabled = true;
            space5.Enabled = true;
            space6.Enabled = true;
            space7.Enabled = true;
            space8.Enabled = true;

            //Clear spaces
            space0.Text = "";
            space1.Text = "";
            space2.Text = "";
            space3.Text = "";
            space4.Text = "";
            space5.Text = "";
            space6.Text = "";
            space7.Text = "";
            space8.Text = "";

            //Reset colors
            space0.BackColor = SystemColors.ControlLight;
            space1.BackColor = SystemColors.ControlLight;
            space2.BackColor = SystemColors.ControlLight;
            space3.BackColor = SystemColors.ControlLight;
            space4.BackColor = SystemColors.ControlLight;
            space5.BackColor = SystemColors.ControlLight;
            space6.BackColor = SystemColors.ControlLight;
            space7.BackColor = SystemColors.ControlLight;
            space8.BackColor = SystemColors.ControlLight;

            //Reset turn values
            turn = "X";
            turnLabel.Text = "Turn: X";
            turnCounter = 0;
            turnLabel.ForeColor = Color.Black;

            //Reset board array
            for (int i = 0; i < board.Length; i++)
            {
                board[i] = -1;
            }

        }

        private void spaceClick(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int buttonNumber = Convert.ToInt32((string)button.Tag);
            button.Enabled = false;
            button.Text = turn;
            if (turn ==  "X")
            {
                board[buttonNumber] = 1;
            } else if (turn == "O") 
            {
                board[buttonNumber] = 0;
            }

            int win = winCheck(buttonNumber);
            if (win != 0)                           //Win
            {
                disableSpaces();
                winState(win, buttonNumber);
            }else if (turnCounter == 8)             //Draw
            {
                disableSpaces();
                turnLabel.Text = "IT'S A DRAW!";
                turnLabel.ForeColor = Color.Red;
            }
            else                                    //Change turn
            {
                if (turn == "X")
                {
                    turn = "O";
                }else if (turn == "O") 
                {
                    turn = "X";
                }

                turnLabel.Text = "Turn: " + turn;
                turnCounter++;
                
            }

        }

        private void disableSpaces()
        {
            //Disable all spaces
            space0.Enabled = false;
            space1.Enabled = false;
            space2.Enabled = false;
            space3.Enabled = false;
            space4.Enabled = false;
            space5.Enabled = false;
            space6.Enabled = false;
            space7.Enabled = false;
            space8.Enabled = false;
            return;
        }

        void winState(int winType, int square)
        {
            if (board[square] == 0)
            {
                turnLabel.Text = "O HAS WON!";
                turnLabel.ForeColor = Color.Red;

            } else if (board[square] == 1)
            {
                turnLabel.Text = "X HAS WON!";
                turnLabel.ForeColor = Color.Red;
            }
        }

        void highlightRow(int row)
        {
            switch (row) {
                case 0:
                    space0.BackColor = Color.Red;
                    space1.BackColor = Color.Red;
                    space2.BackColor = Color.Red;
                    break;
                case 1:
                    space3.BackColor = Color.Red;
                    space4.BackColor = Color.Red;
                    space5.BackColor = Color.Red;
                    break;
                case 2:
                    space6.BackColor = Color.Red;
                    space7.BackColor = Color.Red;
                    space8.BackColor = Color.Red;
                    break;
            }
        }

        void highlightCol(int col)
        {
            switch (col)
            {
                case 0:
                    space0.BackColor = Color.Red;
                    space3.BackColor = Color.Red;
                    space6.BackColor = Color.Red;
                    break;
                case 1:
                    space1.BackColor = Color.Red;
                    space4.BackColor = Color.Red;
                    space7.BackColor = Color.Red;
                    break;
                case 2:
                    space2.BackColor = Color.Red;
                    space5.BackColor = Color.Red;
                    space8.BackColor = Color.Red;
                    break;
            }
        }

        void highlightDiag(int diag)
        {
            if (diag == 1)
            {
                space0.BackColor = Color.Red;
                space4.BackColor = Color.Red;
                space8.BackColor = Color.Red;
            }else if (diag == 2)
            {
                space2.BackColor = Color.Red;
                space4.BackColor = Color.Red;
                space6.BackColor = Color.Red;
            }
        }

        int winCheck(int square)
        {
            int row = square / 3;
            int col = square % 3;

            if (horizontalCheck(row) == 1) //Check the row of played square
            {
                highlightRow(row);
                return 1;
            }
            else if (verticalCheck(col) == 1) //Check the col of the played square
            {
                highlightCol(col);
                return 2;
            }
            else
            {
                int diag = diagonalChecks();
                if (diag == 1)
                {
                    highlightDiag(diag);
                    return 3;
                }
                else if (diag == 2)
                {
                    highlightDiag(diag);
                    return 4;
                }
                else
                {
                    return 0;
                }
            }
        }

        int horizontalCheck(int row)       //Return 1 if the game has been won 0 if game has not been won
        {
            if (board[row * 3 + 0] == board[row * 3 + 1] && board[row * 3 + 1] == board[row * 3 + 2])
            {
                return 1;
            }
            return 0;
        }

        int verticalCheck(int col)         //Return 1 if the game has been won, 0 if game has not been won
        {
            if (board[col] == board[1 * 3 + col] && board[1 * 3 + col] == board[2 * 3 + col])
            {
                return 1;
            }
            return 0;
        }

        int diagonalChecks()               //Return 1 if left/top to bot/right, 2 if right/top to bot/left, 0 if game has not been won
        {
            if (board[4] < 0)   //If middle space is open no diagnal wins possible
            {
                return 0;
            }
            if (board[0] == board[4] && board[4] == board[8]) //Top left to bottom right diagonal
            {
                return 1;
            }
            if (board[2] == board[4] && board[4] == board[6]) //Top right ot bottom left diagonal
            {
                return 2;
            }
            return 0; //No win
        }

    }
}
