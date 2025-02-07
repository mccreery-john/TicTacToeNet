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
        //For board: O = 0 and X = 1, -1 = free space
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

        }

        private void spaceClick(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int buttonNumber = Convert.ToInt32((string)button.Tag);
            button.Enabled = false;

            int win = winCheck(buttonNumber);
            if (win != 0)
            {

            }


        }

        int winCheck(int square)
        {
            int row = square / 3;
            int col = square % 3;

            if (horizontalCheck(row) == 1) //Check the row of played square
            {
                return 1;
            }
            else if (verticalCheck(col) == 1) //Check the col of the played square
            {
                return 2;
            }
            else
            {
                int diag = diagonalChecks();
                if (diag == 1)
                {
                    return 3;
                }
                else if (diag == 2)
                {
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

        int verticalCheck(int col)       //Return 1 if the game has been won, 0 if game has not been won
        {
            if (board[col] == board[1 * 3 + col] && board[1 * 3 + col] == board[2 * 3 + col])
            {
                return 1;
            }
            return 0;
        }

        int diagonalChecks()                         //Return 1 if left/top to bot/right, 2 if right/top to bot/left, 0 if game has not been won
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
