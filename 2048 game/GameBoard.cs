using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048_game
{
    public class GameBoard
    {
        private const int rows = 4;
        private const int columns = 4;
        private int [,] board { get; set; }

        public GameBoard()
        {
            board = new int[rows, columns];

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    board[r, c] = 0;
                }
            }
        }

        public int getRows()
        {
            return rows;
        }

        public int getColumns()
        {
            return columns;
        }

        public int[,] getBoard()
        {
            return board;
        }

        public bool isBoardFull()
        {
            foreach (var field in board)
            {
                if(field == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public int getFieldValue(int r, int c)
        {
            return board[r, c];
        }

        public void setFieldValue(int r, int c, int value)
        {
            board[r, c] = value;
        }

        public bool isFieldEmpty(int r, int c)
        {
            return getFieldValue(r, c) == 0 ? true : false;
        }
    }
}
