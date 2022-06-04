using ChessBoardModel;

namespace Knight
{
    public partial class Form1 : Form
    {
        //Tạo bàn cờ
        static Board myBoard = new Board(8);

        //Tạo matrix các button
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
                    if ((i + j) % 2 == 1)
                    {
                        btnGrid[i, j].BackColor = Color.FromArgb(228, 165, 72);
                        btnGrid[i, j].FlatAppearance.BorderColor = Color.FromArgb(228, 165, 72);
                    }
                    else
                    {
                        btnGrid[i, j].BackColor = Color.FromArgb(242, 228, 203);
                        btnGrid[i, j].FlatAppearance.BorderColor = Color.FromArgb(242, 228, 203);
                    }


                }
            }
        }
        private void populateGrid()
        {
            //Thay đổi kích cỡ font chữ
            ChangeFont(18);

            //Thiết lập kích cỡ panel
            panel1.Width = 800;
            panel1.Height = panel1.Width;

            //Lấy kích cỡ mỗi button 
            int buttonSize = panel1.Width / myBoard.Size;

            //Lấy kích cỡ cữa picture bằng với button
            pictureBox1.Height = buttonSize;
            pictureBox1.Width=buttonSize;

            //Tạo button 
            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    btnGrid[i, j] = new Button();

                    //Thiết lập kích cỡ của button
                    btnGrid[i, j].Height = buttonSize;
                    btnGrid[i, j].Width = buttonSize;
                }
            }

            //Trang trí lại button
            CustomButton(btnGrid);

            //
            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    //Nếu click lên button thì chạy hàm Grid_Button_Click
                    btnGrid[i, j].Click += Grid_Button_Click;

                    panel1.Controls.Add(btnGrid[i, j]);

                    btnGrid[i, j].Location = new Point(i * buttonSize, j * buttonSize);

                    //Tạo tên của từng ô theo quy tắc cờ vua
                    btnGrid[i, j].Text = Convert.ToChar(i + 65) + "" + (8-j);
                    btnGrid[i, j].Tag = new Point(i, j);
                }
            }
        }
        private void Grid_Button_Click(object? sender, EventArgs e)
        {
            //lấy tọa độ của nút bấm vào
            Button clickedButton = (Button)sender;
            Point location = (Point)clickedButton.Tag;

            int x = location.X;
            int y = location.Y;

            //Clear bàn cờ
            Cell currentCell = myBoard.theGrid[x, y];
            for(int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    btnGrid[i, j].Text = "";
                }    
            }

            //Đặt vị trí xuất hiện quân ngựa tại nút bấm vào
            pictureBox1.Location = btnGrid[x, y].Location;

            //Cho xuất hiện quân ngựa
            pictureBox1.Visible = true;
            panel1.Refresh();
            
            //Tìm kiếm đường đi cho quân ngưa
            myBoard.MarkNextMoves(currentCell, x, y);
            
            ChangeFont(40);


            for (int i = 0; i < 64; i++)
            {
                //Gán tọa độ quân ngựa đi 
                x = myBoard.Knight.Result[i, 0];
                y = myBoard.Knight.Result[i, 1];

                //Gán lại tọa độ xuất hiện quân ngựa trên bàn cờ
                pictureBox1.Location = btnGrid[x, y].Location;
                panel1.Refresh();
                //Thread.Sleep(400);

                //Những ô quân ngựa đi qua sẽ đánh dấu "x" tức là đã đi qua
                btnGrid[x, y].Text = "x";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}