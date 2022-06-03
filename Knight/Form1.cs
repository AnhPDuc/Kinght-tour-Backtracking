using ChessBoardModel;

namespace Knight
{
    public partial class Form1 : Form
    {
        static Board myBoard = new Board(8);
        public Button[,] btnGrid = new Button[myBoard.Size, myBoard.Size];
        public Form1()
        {
            InitializeComponent();
            populateGrid();
        }
        private void ChangeFont(int x)
        {
            panel1.ForeColor = Color.Black;
            panel1.Font = new Font("Arial", x, FontStyle.Bold, GraphicsUnit.Point);
        }
        private void CustomButton(Button[,] btnGrid)
        {
            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    btnGrid[i, j].FlatStyle = FlatStyle.Flat;
                    if ((i + j) % 2 == 0)
                    {
                        btnGrid[i, j].BackColor = Color.Red;
                        btnGrid[i, j].FlatAppearance.BorderColor = Color.Red;
                    }
                    else
                    {
                        btnGrid[i, j].BackColor = Color.Pink;
                        btnGrid[i, j].FlatAppearance.BorderColor = Color.Pink;
                    }


                }
            }
        }
        private void populateGrid()
        {
            ChangeFont(18);
            panel1.Width = 800;
            int buttonSize = panel1.Width / myBoard.Size;
            panel1.Height = panel1.Width;
            pictureBox1.Height = buttonSize;
            pictureBox1.Width=buttonSize;

            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    btnGrid[i, j] = new Button();
                }
            }

            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    btnGrid[i, j].Height = buttonSize;
                    btnGrid[i, j].Width = buttonSize;

                    btnGrid[i, j].Click += Grid_Button_Click;

                    panel1.Controls.Add(btnGrid[i, j]);

                    btnGrid[i, j].Location = new Point(i * buttonSize, j * buttonSize);


                    btnGrid[i, j].Text = Convert.ToChar(i + 65) + "" + (j + 1);
                    btnGrid[i, j].Tag = new Point(i, j);
                }
            }
            CustomButton(btnGrid);
        }
        private void Grid_Button_Click(object? sender, EventArgs e)
        {
            //get row collums
            Button clickedButton = (Button)sender;
            Point location = (Point)clickedButton.Tag;

            int x = location.X;
            int y = location.Y;

            Cell currentCell = myBoard.theGrid[x, y];
            for(int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    btnGrid[i, j].Text = "";
                }    
            }
            pictureBox1.Location = btnGrid[x, y].Location;
            pictureBox1.Visible = true;
            panel1.Refresh();
            
            myBoard.MarkNextLegalMoves(currentCell, x, y);
            
            ChangeFont(40);
            for (int i = 0; i < 64; i++)
            {
                x = myBoard.Knight.Result[i, 0];
                y = myBoard.Knight.Result[i, 1];
                pictureBox1.Location = btnGrid[x, y].Location;
                panel1.Refresh();
                Thread.Sleep(400);
                btnGrid[x, y].Text = "x";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}