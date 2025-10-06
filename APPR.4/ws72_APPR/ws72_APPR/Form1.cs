using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ws72_APPR
{
    public partial class Form1: Form
    {
        List<string> Pieces = new List<string>();
        Piece currentPiece = null;
        PictureBox pcbFrom = null;
        PictureBox pcbTo = null;
        int horizontal = 0;
        int vertical = 0;
        string pieceOptions = "";
        List<Board> boardlist = new List<Board>();


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (PictureBox picturebox in gbxGame.Controls.OfType<PictureBox>())
            {
                picturebox.BackColor = Color.LightGray;
                picturebox.SizeMode = PictureBoxSizeMode.StretchImage;
                picturebox.AllowDrop = true;
            }

            boardlist.Clear();
            boardlist.Add(new Board(1, 1, "pcbOne"));
            boardlist.Add(new Board(2, 1, "pcbTwo"));
            boardlist.Add(new Board(3, 1, "pcbThree"));
            boardlist.Add(new Board(1, 2, "pcbFour"));
            boardlist.Add(new Board(2, 2, "pcbFive"));
            boardlist.Add(new Board(3, 2, "pcbSix"));
            boardlist.Add(new Board(1, 3, "pcbSeven"));
            boardlist.Add(new Board(2, 3, "pcbEight"));
            boardlist.Add(new Board(3, 3, "pcbNine"));
        }

        private void btnRook_Click(object sender, EventArgs e)
        {
            currentPiece = new Piece("Rook");
            currentPiece.SetLocation(1, 1);
            Pieces.Add("Rook-1,1");

            Bitmap bm = new Bitmap("C:\\Users\\svenm\\OneDrive - ROC Ter AA\\APPR.4\\ws72_APPR\\img\\black-rook.png");
            pcbOne.Image = bm;
        }

        private void btnKnight_Click(object sender, EventArgs e)
        {
            currentPiece = new Piece("Knight");
            currentPiece.SetLocation(1, 1);
            Pieces.Add("Knight-1,1");

            Bitmap bm = new Bitmap("C:\\Users\\svenm\\OneDrive - ROC Ter AA\\APPR.4\\ws72_APPR\\img\\black-horse.png");
            pcbOne.Image = bm;
        }

        private void btnQueen_Click(object sender, EventArgs e)
        {

            currentPiece = new Piece("Queen");
            currentPiece.SetLocation(1, 1);
            Pieces.Add("Queen-1,1");

            Bitmap bm = new Bitmap("C:\\Users\\svenm\\OneDrive - ROC Ter AA\\APPR.4\\ws72_APPR\\img\\black-queen.png");
            pcbOne.Image = bm;
        }

        private void btnBishop_Click(object sender, EventArgs e)
        {

            currentPiece = new Piece("Pawn");
            currentPiece.SetLocation(1, 1);
            Pieces.Add("Pawn-1,1");

            Bitmap bm = new Bitmap("C:\\Users\\svenm\\OneDrive - ROC Ter AA\\APPR.4\\ws72_APPR\\img\\black-bishop.png");
            pcbOne.Image = bm;
        }

        private void pcbAll_MouseDown(object sender, MouseEventArgs e)
        {
            ClearBoardcolors();
            pcbFrom = (PictureBox)sender;

            foreach(string piece in Pieces)
            {
                if(pcbFrom.Image != null)
                {
                    string[] parts = piece.Split('-');
                    string pieceOnly = parts[0];
                    string placeOnly = parts[1];
                    string[] placeParts = placeOnly.Split(',');
                    string placePartOneS = placeParts[0];
                    string placePartTwoS = placeParts[1];
                    string placePart = placePartOneS + placePartTwoS;
                    if (placePart == pcbFrom.Tag.ToString())
                    {
                        currentPiece = new Piece(pieceOnly);
                        int placePartOneI = Convert.ToInt32(placePartOneS);
                        int placePartTwoI = Convert.ToInt32(placePartTwoS);
                        currentPiece.SetLocation(placePartOneI, placePartTwoI);
                    }
                }

            }


            if(pcbFrom.Image != null)
            {
                GetBoardoptions();
                UpdateBoardpieceLocations();
                pcbFrom.DoDragDrop(pcbFrom.Image, DragDropEffects.Copy);
            }
        }

        private void pcbAll_DragDrop(object sender, DragEventArgs e)
        {
            pcbTo = (PictureBox)sender;
            Image getPicture = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            pcbTo.Image = getPicture;
            List<int> begone = new List<int>();
            string test = "";
            int l_amount = 0;
            foreach (string piece in Pieces)
            {
                string[] parts = piece.Split('-');
                string pieceOnly = parts[0];
                string placeOnly = parts[1];

                string[] placeParts = placeOnly.Split(',');
                string placePartOne = placeParts[0];
                string placePartTwo = placeParts[1];
                string placePart = placePartOne + placePartTwo;

                if (placePart == pcbFrom.Tag.ToString())
                {
                    placeOnly = pcbTo.Tag.ToString().Substring(0, 1).ToString();
                    placeOnly= placeOnly + "," + pcbTo.Tag.ToString().Substring(1, 1).ToString();
                    begone.Add(l_amount);
                    test = pieceOnly + "-" + placeOnly;
                }
                l_amount++;
            }
            begone.Sort((a, b) => b.CompareTo(a));
            foreach (int begoner in begone)
            {
                Pieces.RemoveAt(begoner);
            }

            if(test != "")
            {
                Pieces.Add(test);
            }

            horizontal = Convert.ToInt32(pcbTo.Tag.ToString().Substring(0, 1));
            vertical = Convert.ToInt32(pcbTo.Tag.ToString().Substring(1, 1));
            currentPiece.SetLocation(horizontal, vertical);



            pcbFrom.Image = null;
            ClearBoardcolors();
        }

        private void pcbAll_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap) && ((PictureBox)sender).BackColor == Color.Green)
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        public void GetBoardoptions()
        {
            pieceOptions = "";
            foreach (Board board in boardlist)
            {
                if (currentPiece != null)
                {
                    pieceOptions += currentPiece.GetMoveoptions(board.GetHorizontal(), board.GetVertical(), Pieces);
                }
            }
        }

        public void UpdateBoardpieceLocations()
        {
            for (int i = 0; i < pieceOptions.Length; i +=2)
            {
                foreach(PictureBox picturebox in gbxGame.Controls.OfType<PictureBox>())
                {
                    if(picturebox.Tag.ToString() == pieceOptions[i].ToString() + pieceOptions[i + 1].ToString() && picturebox.Image == null)
                    {
                        picturebox.BackColor = Color.Green;
                    }
                }
            }
        }
        
        public void ClearAllImagesFromPlayingfield()
        {
            foreach (PictureBox picturebox in gbxGame.Controls.OfType<PictureBox>())
            {
                picturebox.BackColor = Color.LightGray;
                picturebox.Image = null;
            }
        }

        public void ClearBoardcolors()
        {
            foreach (PictureBox picturebox in gbxGame.Controls.OfType<PictureBox>())
            {
                picturebox.BackColor = Color.LightGray;
            }
        }
    }
}
