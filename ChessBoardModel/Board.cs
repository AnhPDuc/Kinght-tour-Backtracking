using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ChessBoardModel
{
    public class Board
    {

        public int Size { get; set; }       //Size 8x8
        public Cell[,] theGrid { get; set; }//Mảng 2D 

        public KnightMove Knight=new KnightMove();

        public Board(int s)
        {
            Size = s;//size của board
            theGrid=new Cell[Size,Size];//tạo mảng 2D
            for(int i=0;i<Size;i++)
            {
                for(int j=0;j<Size;j++)
                {
                    theGrid[i,j] = new Cell(i,j);
                }
            }
        }
        public void MarkNextLegalMoves(Cell currentCell,int x,int y)
        {
            Knight.count = 0;
            Knight.CreateTable();
            Knight.FindWay(x, y);
        }

    }
}
