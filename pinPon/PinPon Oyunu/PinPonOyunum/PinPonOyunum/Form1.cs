﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PinPonOyunum
{
    public partial class gameForm : Form
    {
        public int speed_left = 4;
        public int speed_top = 4;
        public int points = 0;

        public gameForm()
        {
            InitializeComponent();

            timer1.Enabled = true;
            Cursor.Hide();
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            this.Bounds = Screen.PrimaryScreen.Bounds;

            racket.Top = playGround.Bottom -(playGround.Bottom/10);

            gameover_Lbl.Left = (playGround.Width / 2) - (gameover_Lbl.Width / 2);
            gameover_Lbl.Top = (playGround.Height / 2) - (gameover_Lbl.Height / 2);
            gameover_Lbl.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            racket.Left = Cursor.Position.X - (racket.Width / 2);
            ball.Left += speed_left;
            ball.Top += speed_top;

            if(ball.Left<=playGround.Left)
            {
                speed_left = -speed_left;
            }
            if (ball.Right >= playGround.Right)
            {
                speed_left = -speed_left;
            }
            if (ball.Top <= playGround.Top)
            {
                speed_top = -speed_top;
            }
            if (ball.Bottom >= playGround.Bottom)
            {
                gameover_Lbl.Visible = true;
                timer1.Enabled = false;
            }
            if (ball.Bottom >= racket.Top && ball.Bottom <= racket.Bottom && ball.Left >= racket.Left && ball.Right <= racket.Right)
            {
                speed_top += 2;
                speed_left += 2;
                speed_top = -speed_top;
                points += 1;
                points_Lbl.Text = points.ToString();

                Random r = new Random();
                playGround.BackColor = Color.FromArgb(r.Next(150, 255), r.Next(150, 255), r.Next(150, 255));


            }
        }

        private void gameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if(e.KeyCode==Keys.F1)
            {
                ball.Top = 50;
                ball.Left = 50;
                speed_left = 4;
                points_Lbl.Text = "0";
                timer1.Enabled = true;
                gameover_Lbl.Visible = false;
                playGround.BackColor = Color.White;

            }
        }
    }
}
