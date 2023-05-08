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

        private void start_button_Click(object sender, EventArgs e)
        {
            menu.Enabled = false;
            menu.Visible = false;

            title.Enabled = false;
            title.Visible = false;

            start_button.Enabled = false;
            start_button.Visible = false;

            quit_button.Enabled = false;
            quit_button.Visible = false;

            tiles = new Label[,]{
                { label1, label2, label3, label4, label5 },
                { label6, label7, label8, label9, label10 },
                { label11, label12, label13, label14, label15},
                { label16, label17, label18, label19, label20 },
                { label21, label22, label23, label24, label25},
            };

            timer1.Enabled = true;
        }

        private void quit_button_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit?", "Quit Game", MessageBoxButtons.YesNo) == DialogResult.Yes)
                this.Close();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                for (int j = 0; j < size; j++)
                {
                    for (int i = 1; i < size; i++)
                    {
                        if (!string.IsNullOrEmpty(tiles[i, j].Text))
                        {
                            int k = i;
                            while (k > 0 && string.IsNullOrEmpty(tiles[k - 1, j].Text)) k--;
                            if (k > 0 && tiles[k - 1, j].Text == tiles[i, j].Text)
                            {
                                int value = int.Parse(tiles[i, j].Text) * 2;
                                tiles[k - 1, j].Text = value.ToString();
                                tiles[i, j].Text = "";
                            }
                            else if (k != i) // Move to new position
                            {
                                tiles[k, j].Text = tiles[i, j].Text;
                                tiles[i, j].Text = "";
                            }
                        }
                    }
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                for (int j = 0; j < size; j++)
                {
                    for (int i = size - 2; i >= 0; i--)
                    {
                        if (!string.IsNullOrEmpty(tiles[i, j].Text))
                        {
                            int k = i;
                            while (k < size - 1 && string.IsNullOrEmpty(tiles[k + 1, j].Text)) k++;
                            if (k < size - 1 && tiles[k + 1, j].Text == tiles[i, j].Text)
                            {
                                int value = int.Parse(tiles[i, j].Text) * 2;
                                tiles[k + 1, j].Text = value.ToString();
                                tiles[i, j].Text = "";
                            }
                            else if (k != i)
                            {
                                tiles[k, j].Text = tiles[i, j].Text;
                                tiles[i, j].Text = "";
                            }
                        }
                    }
                }
            }
            else if (e.KeyCode == Keys.Left)
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 1; j < size; j++)
                    {
                        if (!string.IsNullOrEmpty(tiles[i, j].Text))
                        {
                            int k = j;
                            while (k > 0 && string.IsNullOrEmpty(tiles[i, k - 1].Text)) k--;
                            if (k > 0 && tiles[i, k - 1].Text == tiles[i, j].Text)
                            {
                                int value = int.Parse(tiles[i, j].Text) * 2;
                                tiles[i, k - 1].Text = value.ToString();
                                tiles[i, j].Text = "";
                            }
                            else if (k != j)
                            {
                                tiles[i, k].Text = tiles[i, j].Text;
                                tiles[i, j].Text = "";
                            }
                        }
                    }
                }
            }
            else if (e.KeyCode == Keys.Right)
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = size - 2; j >= 0; j--) 
                    {
                        if (!string.IsNullOrEmpty(tiles[i, j].Text))
                        {
                            int k = j;
                            while (k < size - 1 && string.IsNullOrEmpty(tiles[i, k + 1].Text)) k++; 
                            if (k < size - 1 && tiles[i, k + 1].Text == tiles[i, j].Text) 
                            {
                                int value = int.Parse(tiles[i, j].Text) * 2;
                                tiles[i, k + 1].Text = value.ToString();
                                tiles[i, j].Text = "";
                            }
                            else if (k != j) 
                            {
                                tiles[i, k].Text = tiles[i, j].Text;
                                tiles[i, j].Text = "";
                            }
                        }
                    }
                }
            }
            generateNewNumber();
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
                        tiles[i, j].BackColor = Color.AliceBlue;
                    else if (tiles[i, j].Text == "128")
                        tiles[i, j].BackColor = Color.Cyan;
                    else if (tiles[i, j].Text == "256")
                        tiles[i, j].BackColor = Color.Turquoise;
                    else if (tiles[i, j].Text == "512")
                        tiles[i, j].BackColor = Color.Linen;
                    else if (tiles[i, j].Text == "1024")
                        tiles[i, j].BackColor = Color.Navy;
                    else if (tiles[i, j].Text == "2048")
                        tiles[i, j].BackColor = Color.Magenta;
                    else if (tiles[i, j].Text == "4096")
                    {
                        tiles[i, j].BackColor = Color.SkyBlue;
                        gameOver(true);
                    }
                    else
                        tiles[i, j].BackColor = Color.Silver;
                }
            }
        }

        private void gameOver(bool win)
        {
            timer1.Enabled = false;

            menu.Enabled = true;
            menu.Visible = true;

            if (win)
                title.Text = "You Win!";
            else
                title.Text = "Game Over!";
            title.Enabled = true;
            title.Visible = true;

            start_button.Text = "Play Again!";
            start_button.Enabled = true;
            start_button.Visible = true;

            quit_button.Enabled = true;
            quit_button.Visible = true;
        }
    }
}
