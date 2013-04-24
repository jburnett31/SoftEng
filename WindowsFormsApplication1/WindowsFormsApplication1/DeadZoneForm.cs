﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class DeadZoneForm : Form
    {
        public DeadZoneForm()
        {
            InitializeComponent();
        }

        private void screen_MouseDown(object sender, MouseEventArgs e)
        {
            Rectangle rc = RectangleDrawer.Draw(screen);

            addLabel.Visible = true;
        }

        private void screen_MouseEnter(object sender, EventArgs e)
        {
            addLabel.Visible = true;
        }

        private void addButton_MouseDown(object sender, EventArgs e)
        {
            addLabel.Visible = true;
        }

        private void screen_MouseDown(object sender, EventArgs e)
        {
            addLabel.Visible = true;
        }

        private void addButton_Click(object sender, EventArgs e)
        {

        }

        private void addLabel_Click(object sender, EventArgs e)
        {
            
        }

        private void screen_MouseUp(object sender, EventArgs e)
        {
            addLabel.Visible = true;
            int[] array = RectangleDrawer.returnParams();
            addLabel.Text = array.ToString();
        }

        private void DeadZoneForm_Load(object sender, EventArgs e)
        {

        }

        public static class RectangleDrawer
        {
            private static Form mMask;
            private static Point mPos;
            private static int x;
            private static int y;
            private static int w;
            private static int h;

            public static Rectangle Draw(Form parent)
            {
                // Record the start point
                mPos = parent.PointToClient(Control.MousePosition);
                // Create a transparent form on top of <frm>
                mMask = new Form();
                mMask.FormBorderStyle = FormBorderStyle.None;
                mMask.BackColor = Color.Aqua;
                mMask.TransparencyKey = mMask.BackColor;
                mMask.ShowInTaskbar = false;
                mMask.StartPosition = FormStartPosition.Manual;
                mMask.Size = parent.ClientSize;
                mMask.Location = parent.PointToScreen(Point.Empty);
                mMask.MouseMove += MouseMove;
                mMask.MouseUp += MouseUp;
                mMask.Paint += PaintRectangle;
                mMask.Load += DoCapture;
                // Display the overlay
                mMask.ShowDialog(parent);
                // Clean-up and calculate return value
                mMask.Dispose();
                mMask = null;
                Point pos = parent.PointToClient(Control.MousePosition);
                x = Math.Min(mPos.X, pos.X);
                y = Math.Min(mPos.Y, pos.Y);
                w = Math.Abs(mPos.X - pos.X);
                h = Math.Abs(mPos.Y - pos.Y);
                return new Rectangle(x, y, w, h);
            }
            private static void DoCapture(object sender, EventArgs e)
            {
                // Grab the mouse
                mMask.Capture = true;
            }
            private static void MouseMove(object sender, MouseEventArgs e)
            {
                // Repaint the rectangle
                mMask.Invalidate();
            }
            private static void MouseUp(object sender, MouseEventArgs e)
            {
                // Done, close mask
                mMask.Close(); //might not want -- we want the rectangle to continue to be displayed until reset
            }
            public static int[] returnParams()
            {
                int[] outputArray = new int[4];
                outputArray[0] = x;
                outputArray[1] = y;
                outputArray[2] = w;
                outputArray[3] = h;
                return outputArray;  
            }
            private static void PaintRectangle(object sender, PaintEventArgs e)
            {
                // Draw the current rectangle
                Point pos = mMask.PointToClient(Control.MousePosition);
                using (Pen pen = new Pen(Brushes.Black))
                {
                    pen.DashStyle = DashStyle.Dot;
                    e.Graphics.DrawLine(pen, mPos.X, mPos.Y, pos.X, mPos.Y);
                    e.Graphics.DrawLine(pen, pos.X, mPos.Y, pos.X, pos.Y);
                    e.Graphics.DrawLine(pen, pos.X, pos.Y, mPos.X, pos.Y);
                    e.Graphics.DrawLine(pen, mPos.X, pos.Y, mPos.X, mPos.Y);
                }
            }
        }

        private void addButton_Click_1(object sender, EventArgs e)
        {
           
        }
    }
}
