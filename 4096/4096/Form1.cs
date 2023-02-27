using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4096
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        const int size = 5;
        Label[,] tiles = new Label[size, size];

        private void Form1_Load(object sender, EventArgs e)
        {
            tiles[0,0] = label1;
            tiles[0,1] = label2;
            tiles[0,2] = label3;
            tiles[0,3] = label4;
            tiles[0,4] = label5;

            tiles[1,0] = label6;
            tiles[1,1] = label7;
            tiles[1,2] = label8;
            tiles[1,3] = label9;
            tiles[1,4] = label10;

            tiles[2,0] = label11;
            tiles[2,1] = label12;
            tiles[2,2] = label13;
            tiles[2,3] = label14;
            tiles[2,4] = label15;

            tiles[3,0] = label16;
            tiles[3,1] = label17;
            tiles[3,2] = label18;
            tiles[3,3] = label19;
            tiles[3,4] = label20;

            tiles[4,0] = label21;
            tiles[4,1] = label22;
            tiles[4,2] = label23;
            tiles[4,3] = label24;
            tiles[4,4] = label25;
        }

        private void generateNewNumber()
        {
            Random rand = new Random();
            int i = rand.Next(0, 5);
            int j = rand.Next(0, 5);
            while (tiles[i, j].Text != "")
            {
                i = rand.Next(0, 5);
                j = rand.Next(0, 5);
            }
            tiles[i, j].Text = "2";
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                for (int j = 0; j < size; j++)
                {
                    for (int i = 0; i < size; i++)
                    {
                        if (tiles[i, j].Text == "")
                        {
                            int pos = i + 1;
                            while (pos < size && tiles[pos, j].Text == "")
                                pos++;
                            if (pos < size)
                            {
                                tiles[i, j].Text = tiles[pos, j].Text;
                                tiles[pos, j].Text = "";
                                if (i - 1 >= 0 && tiles[i, j].Text == tiles[i - 1, j].Text)
                                {
                                    tiles[i - 1, j].Text = (Convert.ToInt32(tiles[i - 1, j].Text) * 2).ToString();
                                    tiles[i, j].Text = "";
                                }
                            }
                        }
                    }
                }
            } 
            else if (e.KeyCode == Keys.Down)
            {
                for (int j = 0; j < size; j++)
                {
                    for (int i = size - 1; i >= 0; i--)
                    {
                        if (tiles[i, j].Text == "")
                        {
                            int pos = i - 1;
                            while (pos >= 0 && tiles[pos, j].Text == "")
                                pos--;
                            if (pos >= 0)
                            {
                                tiles[i, j].Text = tiles[pos, j].Text;
                                tiles[pos, j].Text = "";
                                if (i + 1 < size && tiles[i, j].Text == tiles[i + 1, j].Text)
                                {
                                    tiles[i + 1, j].Text = (Convert.ToInt32(tiles[i + 1, j].Text) * 2).ToString();
                                    tiles[i, j].Text = "";
                                }
                            }
                        }
                    }
                }
            }
            else if (e.KeyCode == Keys.Left)
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (tiles[i, j].Text == "")
                        {
                            int pos = j + 1;
                            while (pos < size && tiles[i, pos].Text == "")
                                pos++;
                            if (pos < size)
                            {
                                tiles[i, j].Text = tiles[i, pos].Text;
                                tiles[i, pos].Text = "";
                                if (j - 1 >= 0 && tiles[i, j].Text == tiles[i, j - 1].Text)
                                {
                                    tiles[i, j - 1].Text = (Convert.ToInt32(tiles[i, j - 1].Text) * 2).ToString();
                                    tiles[i, j].Text = "";
                                }
                            }
                        }
                    }
                }
            }
            else if (e.KeyCode == Keys.Right)
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = size - 1; j >= 0; j--)
                    {
                        if (tiles[i, j].Text == "")
                        {
                            int pos = j - 1;
                            while (pos >= 0 && tiles[i, pos].Text == "")
                                pos--;
                            if (pos >= 0)
                            {
                                tiles[i, j].Text = tiles[i, pos].Text;
                                tiles[i, pos].Text = "";
                                if (j + 1 < size && tiles[i, j].Text == tiles[i, j + 1].Text)
                                {
                                    tiles[i, j + 1].Text = (Convert.ToInt32(tiles[i, j + 1].Text) * 2).ToString();
                                    tiles[i, j].Text = "";
                                }
                            }
                        }
                    }
                }
            }
            generateNewNumber();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (tiles[i, j].Text == "2")
                        tiles[i, j].BackColor = Color.Lime;
                    else if (tiles[i, j].Text == "4")
                        tiles[i, j].BackColor = Color.Blue;
                    else if (tiles[i, j].Text == "8")
                        tiles[i, j].BackColor = Color.Purple;
                    else if (tiles[i, j].Text == "16")
                        tiles[i, j].BackColor = Color.Red;
                    else if (tiles[i, j].Text == "32")
                        tiles[i, j].BackColor = Color.Gold;
                    else if (tiles[i, j].Text == "64")
                        tiles[i, j].BackColor = Color.Turquoise;
                    else
                        tiles[i, j].BackColor = Color.Silver;
                }
            }
        }
    }
}
