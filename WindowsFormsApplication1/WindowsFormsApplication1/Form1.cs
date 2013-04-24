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
    public partial class Form1 : Form
    {
        public VideoCaptureDevice cam = null;
        public FilterInfoCollection usbCam;

        public bool addToggled = false;
        public bool removeToggled = false;
        public bool captureMode = false;


        public Form1()
        {
            InitializeComponent();
        }

        private void screen_MouseDown(object sender, MouseEventArgs e)
        {
            Rectangle rc = RectangleDrawer.Draw(this);
            Console.WriteLine(rc.ToString());//eventually, save this end rectangle to array - this might be in MouseUp
        }

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

        void cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {

            screen.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*usbCam = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach (FilterInfo camera in usbCam)
            {
                MessageBox.Show(camera.Name);
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
            }*/
        }

        /*private void screen_MouseDown(object sender, EventArgs e)
        {
            if (addToggled)
            {
                
            }
            //    record this point and the point of release of mouse
            
            //else if (the remove zone button has been clicked last)
            //    record this point and remove any deadzones with this point in them
            //else (do nothing)
        }*/

        private void screen_MouseUp(object sender, EventArgs e)
        {
            //    if (the area is greater than one pixel) - put this in the MouseUp method
            //         put an indicator, like an outline of the rectangle or fill it in - call a method to do this
            //         calculate the new areas that are still supposed to be monitored - should this be a vector of rectangles?
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (captureMode)
            {
                addToggled = true;
                removeToggled = false;
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (captureMode)
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
            captureMode = false;
        }

        private void captureButton_Click(object sender, EventArgs e)
        {
            // take image of screen
            if (cam != null)
            {
                cam.Stop();
                captureMode = true; // available to add/remove zones
            }
        }


    }

    public static class RectangleDrawer
    {
        private static Form mMask;
        private static Point mPos;
        public static Rectangle Draw(Form parent) {
        // Record the start point
        mPos = parent.PointToClient(Control.MousePosition);
        // Create a transparent form on top of <frm>
        mMask = new Form();
        mMask.FormBorderStyle = FormBorderStyle.None;
        mMask.BackColor = Color.Transparent;
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
        int x = Math.Min(mPos.X, pos.X);
        int y = Math.Min(mPos.Y, pos.Y);
        int w = Math.Abs(mPos.X - pos.X);
        int h = Math.Abs(mPos.Y - pos.Y);
        return new Rectangle(x, y, w, h);
  }
  private static void DoCapture(object sender, EventArgs e) {
    // Grab the mouse
    mMask.Capture = true;
  }
  private static void MouseMove(object sender, MouseEventArgs e) {
    // Repaint the rectangle
    mMask.Invalidate();
  }
  private static void MouseUp(object sender, MouseEventArgs e) {
    // Done, close mask
    mMask.Close(); //might not want -- we want the rectangle to continue to be displayed until reset
  }
  private static void PaintRectangle(object sender, PaintEventArgs e) {
    // Draw the current rectangle
    Point pos = mMask.PointToClient(Control.MousePosition);
    using (Pen pen = new Pen(Brushes.Black)) {
      pen.DashStyle = DashStyle.Dot;
      e.Graphics.DrawLine(pen, mPos.X, mPos.Y, pos.X, mPos.Y);
      e.Graphics.DrawLine(pen, pos.X, mPos.Y, pos.X, pos.Y);
      e.Graphics.DrawLine(pen, pos.X, pos.Y, mPos.X, pos.Y);
      e.Graphics.DrawLine(pen, mPos.X, pos.Y, mPos.X, mPos.Y);
    }
  }
}
}


