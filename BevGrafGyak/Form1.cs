﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GrafikaDLL;

namespace BevGrafGyak
{
    public partial class Form1 : Form
    {
        Graphics g;
        Bitmap bmp;

        bool drawing = false;

        PointF p0 = new PointF();
        public Form1()
        {
            InitializeComponent();

            bmp = new Bitmap(canvas.Width, canvas.Height);
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    bmp.SetPixel(x, y, Color.White);
                }
                canvas.Image = bmp;
            }
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:

                    drawing = true;
                    p0 = e.Location;
                    break;

                case MouseButtons.None:
                    break;

                case MouseButtons.Right:
                    bmp.FillRecursiveFourway(Color.Red, Color.Yellow, e.X, e.Y);
                    canvas.Invalidate();
                    break;

                case MouseButtons.Middle:
                    break;

                case MouseButtons.XButton1:
                    break;

                case MouseButtons.XButton2:
                    break;

                default:
                    break;
            }
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                bmp.SetLine(p0.X, p0.Y, e.X, e.Y, Color.Red);
                p0 = e.Location;
                canvas.Invalidate();
            }

        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            drawing = false;
        }
    }
}
