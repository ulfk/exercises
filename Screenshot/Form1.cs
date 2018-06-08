
namespace ScreenshotApp
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Threading;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        private Bitmap screenshotBitmap;
        private Point prevFormLocation;
        private int prevFormWidth;
        private int prevFormHeight;

        private Point selectionStartPoint;
        private Point selectionEndPoint;
        private Rectangle selectionRectangle = new Rectangle();
        private readonly Brush selectionBrush = new SolidBrush(Color.FromArgb(128, 72, 145, 220));

        public Form1()
        {
            InitializeComponent();
        }

        private Bitmap ExecuteScreenShot()
        {
            var screenshotImage = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                           Screen.PrimaryScreen.Bounds.Height,
                                           PixelFormat.Format32bppArgb);
            var screenshotGraphics = Graphics.FromImage(screenshotImage);

            screenshotGraphics.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                              Screen.PrimaryScreen.Bounds.Y,
                                              0,
                                              0,
                                              Screen.PrimaryScreen.Bounds.Size,
                                              CopyPixelOperation.SourceCopy);

            return screenshotImage;
        }

        private void buttonExecScreenshot_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Thread.Sleep(200);
            screenshotBitmap = this.ExecuteScreenShot();
            this.Visible = true;

            ShowPictureBox();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            selectionStartPoint = e.Location;
            pictureBox.Invalidate();
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point tempEndPoint = e.Location;
                selectionRectangle = GetValidRectangle(selectionStartPoint, tempEndPoint);
                pictureBox.Invalidate();
            }
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (   pictureBox.Image != null 
                && selectionRectangle != null 
                && selectionRectangle.Width > 0 
                && selectionRectangle.Height > 0)
            {
                e.Graphics.FillRectangle(selectionBrush, selectionRectangle);
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                selectionEndPoint = e.Location;
                RestoreForm();
                SaveCroppedImage();
            }

            if (e.Button == MouseButtons.Right)
            {
                buttonExit.BringToFront();
            }
        }

        private void ShowPictureBox()
        {
            // save current window size and position
            this.prevFormLocation = this.Location;
            this.prevFormWidth = this.Width;
            this.prevFormHeight = this.Height;

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

            this.Cursor = Cursors.Cross;
        }

        private void RestoreForm()
        {
            this.selectionRectangle.Width = 0;
            this.selectionRectangle.Height = 0;
            this.pictureBox.Invalidate();
            this.pictureBox.Visible = false;

            this.Location = this.prevFormLocation;
            this.Width = this.prevFormWidth;
            this.Height = this.prevFormHeight;

            this.Cursor = Cursors.Default;
        }

        private void SaveCroppedImage()
        {
            var croppedImage = CropImage(screenshotBitmap, selectionStartPoint, selectionEndPoint);

            var result = saveFileDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                croppedImage.Save(saveFileDialog.FileName, ImageFormat.Png);
            }
        }

        private Bitmap CropImage(Image source, Point firstPoint, Point secondPoint)
        {
            var cropRectangle = GetValidRectangle(firstPoint, secondPoint);
            var croppedImage = new Bitmap(cropRectangle.Width, cropRectangle.Height);
            using (var graphics = Graphics.FromImage(croppedImage))
            {
                graphics.DrawImage(source, new Rectangle(0, 0, croppedImage.Width, croppedImage.Height), cropRectangle, GraphicsUnit.Pixel);
            }

            return croppedImage;
        }

        private Rectangle GetValidRectangle(Point firstPoint, Point secondPoint)
        {
            int posX, posY, width, height;

            posX = Math.Min(firstPoint.X, secondPoint.X);
            posY = Math.Min(firstPoint.Y, secondPoint.Y);
            width = Math.Abs(firstPoint.X - secondPoint.X);
            height = Math.Abs(firstPoint.Y - secondPoint.Y);

            return new Rectangle(posX, posY, width, height);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2,
                                      (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);
        }
    }
}
