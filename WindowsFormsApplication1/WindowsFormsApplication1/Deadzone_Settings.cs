using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace WindowsFormsApplication1
{
    public partial class Deadzone_Settings : Form
    {
        public VideoCaptureDevice cam = null;
        public FilterInfoCollection usbCam;

        public bool addToggled = false;
        public bool removeToggled = false;
        public bool staticImageCaptured = false;

        public Deadzone_Settings()
        {
            InitializeComponent();
        }

        // The navigation buttons on top *******************************
        private void button1_Click(object sender, EventArgs e)
        {
            threshold_Settings_Form threshold_Settings = new threshold_Settings_Form();
            threshold_Settings.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            email_Settings_Form email_Settings = new email_Settings_Form();
            email_Settings.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Repository_Settings repository_Settings = new Repository_Settings();
            repository_Settings.Show();
            this.Close();
        }

        //**************************************************************

        void cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {

            screen.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void Deadzone_Settings_Load(object sender, EventArgs e)
        {
            usbCam = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach (FilterInfo camera in usbCam)
            {
                
            }
            if (usbCam.Count >= 1)
            {
                usbCam = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                cam = new VideoCaptureDevice(usbCam[1].MonikerString);

                cam.NewFrame += new NewFrameEventHandler(cam_NewFrame);

                addButton.Hide();

                cam.Start();
            }
            else
            {
                MessageBox.Show("YAMD cannot detect an available webcam. Please make sure that your device is property plugged into your computer and try again");
            }
        }
        //******************** Making Dead Zones ************************************************
        private void captureButton_Click(object sender, EventArgs e)
        {
            // screen.Image = (Bitmap)cam.SnapshotFr
        }

        private void screen_MouseDown(object sender, EventArgs e)
        {
            Rectangle rectangle = RectangleDrawer.Draw(this);
            tempLabel.Text = rectangle.X.ToString() + " " + rectangle.Y.ToString() + " " + rectangle.Width.ToString() + " " + rectangle.Height.ToString();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (staticImageCaptured)
            {
                addToggled = true;
                removeToggled = false;
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (staticImageCaptured)
            {
                addToggled = false;
                removeToggled = true;
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            addToggled = false;
            removeToggled = false;

            // the video stream can start again
            staticImageCaptured = false;
            if (cam != null)
            {
                cam.Start();
            }
        }
    }

    //************************ RectangleDrawer class *********************************************

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
                mMask.Close();
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

}
