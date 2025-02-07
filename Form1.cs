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
            
        }

        int winCheck(int square)
        {
            return 0;
        }

    }
}
