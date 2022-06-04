using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardModel
{
    public class KnightMove
    {
        //chứa kết quả đường đi của quân mã sau khi thực hiện giải thuật backtracking
        public int[,] Result = new int[64, 2];

        //Chứa đường của quân mã có thể đi trên bàn cờ
        public int[] MoveX = new int[8];
        public int[] MoveY = new int[8];

        //Tạo bàn cờ
        public int[,] Table = new int[8, 8];

        //Đếm số ô quân mã đã đi trên bàn cờ
        public int count = 0;

        //Khởi tạo các đường đi quân mã có thể đi trên bàn cờ
        public KnightMove()
        {
            //X={ -2,-2,-1,-1, 1, 1, 2, 2}
            MoveX[0] = -2;
            MoveX[1] = -2;
            MoveX[2] = -1;
            MoveX[3] = -1;
            MoveX[4] = 1;
            MoveX[5] = 1;
            MoveX[6] = 2;
            MoveX[7] = 2;

            //Y={ -1, 1,-2, 2,-2, 2,-1, 1}
            MoveY[0] = -1;
            MoveY[1] = 1;
            MoveY[2] = -2;
            MoveY[3] = 2;
            MoveY[4] = -2;
            MoveY[5] = 2;
            MoveY[6] = -1;
            MoveY[7] = 1;
        }
        //Tạo bàn cờ
        public void CreateTable()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Table[i, j] = 0;
                }
            }
        }

        //Tìm đường đi của quân mã bằng giải thuật backtracking
        public void FindWay(int x, int y)
        {
            //Lưu bước đi vào 
            Result[count , 0] = x;
            Result[count , 1] = y;

            //Tăng giá trị bước đi
            count++;

            //Lưu bước vừa đi vào bàn cờ
            Table[x,y] = count;
            for (int i = 0; i < 8; i++)
            {
                //Kiểm tra xem mã đã đi hết bàn cờ chưa
                if (count == 64)
                {
                    return;
                }
                //Nếu chưa đi hết bàn cờ thì tạo bước đi mới
                int u = x + MoveX[i];//tạo một vị trí x mới
                int v = y + MoveY[i];//tạo một vịi trí y mới
                //Nếu hợp lẹ thì tiến hành di chuyển
                if (u >= 0 && u < 8 && v >= 0 && v < 8 && Table[u, v] == 0)
                {
                    FindWay(u, v);
                    if (count == 64)
                    {
                        return;
                    }
                }
            }
            //Nếu không tìm được bước đi thì ta phải trả lại các giá trị ban đầu
            count--;
            Table[x,y] = 0;
        }
    }
}
