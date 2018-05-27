
namespace ShuffleCards
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class ShuffleCardsForm : Form
    {
        private PictureBox[] PictureBoxes;
        private Random RandomGenerator;

        public ShuffleCardsForm()
        {
            InitializeComponent();
            this.GeneratePictureBoxes();
            RandomGenerator = new Random();
        }

        private void GeneratePictureBoxes()
        {
            var cardFilenames = CardFileFactory.GetFilenames();
            PictureBoxes = new PictureBox[cardFilenames.Count];
            var pictureCounter = 0;
            foreach(var filename in cardFilenames)
            {
                var picBox = CreatePictureBox(pictureCounter, filename);
                picBox.BringToFront();
                picBox.Visible = true;
                PictureBoxes[pictureCounter] = picBox;
                pictureCounter++;
            }
        }

        private PictureBox CreatePictureBox(int cardIndex, string filename)
        {
            return new PictureBox
            {
                Name = $"PictureBox{cardIndex:00}",
                Image = Image.FromFile(filename),
                Parent = this.picturePanel,
                Location = CreateCardPosition(cardIndex),
                Size = new Size(CardFileFactory.ImageWidth, CardFileFactory.ImageHeight)
            };
        }

        private Point CreateCardPosition(int cardIndex)
        {
            var row = cardIndex / CardFileFactory.RowLength;
            var column = cardIndex % CardFileFactory.RowLength;
            var posX = column * (CardFileFactory.ImageWidth + CardFileFactory.ImageMargin);
            var posY = row * (CardFileFactory.ImageHeight + CardFileFactory.ImageMargin);
            return new Point(posX, posY);
        }

        private void buttonShuffle_Click(object sender, System.EventArgs e)
        {
            Shuffle(100);
        }

        private void Shuffle(int numberOfExchanges)
        {
            for(var idx = 0; idx < numberOfExchanges; idx++)
            {
                var cardA = GetRandomIndex();
                var cardB = GetRandomIndex(cardA);
                ExchangeCards(cardA, cardB);
            }
        }

        private void ExchangeCards(int cardA, int cardB)
        {
            var location = PictureBoxes[cardA].Location;
            PictureBoxes[cardA].Location = PictureBoxes[cardB].Location;
            PictureBoxes[cardB].Location = location;
        }

        private int GetRandomIndex(int butNotThisIndex = -1)
        {
            int randomNumber;
            do
            {
                randomNumber = RandomGenerator.Next(0, PictureBoxes.Length);
            } while (randomNumber == butNotThisIndex);

            return randomNumber;
        }

        private void buttonReset_Click(object sender, System.EventArgs e)
        {
            var pictureCounter = 0;
            foreach (var pictureBox in PictureBoxes)
            {
                pictureBox.Location = CreateCardPosition(pictureCounter);
                pictureCounter++;
            }
        }
    }
}
