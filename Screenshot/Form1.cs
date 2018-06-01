
namespace ScreenshotApp
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Threading;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Bitmap ExecuteScreenShot()
        {
            //Create a new bitmap.
            var bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                           Screen.PrimaryScreen.Bounds.Height,
                                           PixelFormat.Format32bppArgb);

            // Create a graphics object from the bitmap.
            var gfxScreenshot = Graphics.FromImage(bmpScreenshot);

            // Take the screenshot from the upper left corner to the right bottom corner.
            gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                        Screen.PrimaryScreen.Bounds.Y,
                                        0,
                                        0,
                                        Screen.PrimaryScreen.Bounds.Size,
                                        CopyPixelOperation.SourceCopy);

            // Save the screenshot to the specified path that the user has chosen.
            bmpScreenshot.Save(@"C:\temp\Screenshot.png", ImageFormat.Png);

            return bmpScreenshot;
        }

        private Bitmap screenshotBitmap;

        private void buttonExecScreenshot_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Thread.Sleep(200);
            screenshotBitmap = this.ExecuteScreenShot();
            this.Visible = true;

            // resize app window to fullscreen
            this.Location = new Point(0, 0);
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;

            // resize pictureBox to fullscreen
            this.pictureBox.Location = new Point(0, 0);
            this.pictureBox.Width = Screen.PrimaryScreen.Bounds.Width;
            this.pictureBox.Height = Screen.PrimaryScreen.Bounds.Height;
            this.pictureBox.Image = screenshotBitmap;
            this.pictureBox.Visible = true;
        }

        private void Form1_VisibleChanged(object sender, EventArgs e)
        {
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private Point RectStartPoint;
        private Point RectEndPoint;
        private bool RectValid = false;
        private Rectangle Rect = new Rectangle();
        private Brush selectionBrush = new SolidBrush(Color.FromArgb(128, 72, 145, 220));

        // Start Rectangle
        //
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            // Determine the initial rectangle coordinates...
            RectStartPoint = e.Location;
            RectValid = true;
            pictureBox.Invalidate();
        }

        // Draw Rectangle
        //
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && RectValid)
            {
                Point tempEndPoint = e.Location;
                Rect = GetValidRectangle(RectStartPoint, tempEndPoint);
                pictureBox.Invalidate();
            }
        }

        // Draw Area
        //
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (pictureBox.Image != null && Rect != null && Rect.Width > 0 && Rect.Height > 0)
            {
                e.Graphics.FillRectangle(selectionBrush, Rect);
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && RectValid)
            {
                RectEndPoint = e.Location;
                RectValid = false;
                SaveCroppedImage();
                Rect.Width = 0;
                Rect.Height = 0;
                pictureBox.Invalidate();
            }

            if (e.Button == MouseButtons.Right)
            {
                buttonExit.BringToFront();
            }
        }

        private void SaveCroppedImage()
        {
            var croppedImage = CropImage(screenshotBitmap, RectStartPoint, RectEndPoint);
            croppedImage.Save(@"C:\temp\Screenshot_Croped.png", ImageFormat.Png);
        }

        private Bitmap CropImage(Image source, Point firstPoint, Point secondPoint)
        {
            var crop = GetValidRectangle(firstPoint, secondPoint);
            var bmp = new Bitmap(crop.Width, crop.Height);
            using (var gr = Graphics.FromImage(bmp))
            {
                gr.DrawImage(source, new Rectangle(0, 0, bmp.Width, bmp.Height), crop, GraphicsUnit.Pixel);
            }
            return bmp;
        }

        private Rectangle GetValidRectangle(Point firstPoint, Point secondPoint)
        {
            int x, y, width, height;

            x = Math.Min(firstPoint.X, secondPoint.X);
            y = Math.Min(firstPoint.Y, secondPoint.Y);
            width = Math.Abs(firstPoint.X - secondPoint.X);
            height = Math.Abs(firstPoint.Y - secondPoint.Y);

            return new Rectangle(x, y, width, height);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2,
                                      (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);
        }
    }
}
