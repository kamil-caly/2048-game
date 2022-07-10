using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048_game
{
    public class GameOver
    {
        public bool IsGameOver(GameBoard gameBoard)
        {
            if(gameBoard.isBoardFull())
            {
                for (int r = 0; r < 4; r++)
                {

                    if (gameBoard.getFieldValue(r, 0) == gameBoard.getFieldValue(r, 1) ||
                         gameBoard.getFieldValue(r, 1) == gameBoard.getFieldValue(r, 2) ||
                         gameBoard.getFieldValue(r, 2) == gameBoard.getFieldValue(r, 3))
                    {
                        return false;
                    }
                    
                }

                for (int c = 0; c < 4; c++)
                {

                    if (gameBoard.getFieldValue(0, c) == gameBoard.getFieldValue(1, c) ||
                         gameBoard.getFieldValue(1, c) == gameBoard.getFieldValue(2, c) ||
                         gameBoard.getFieldValue(2, c) == gameBoard.getFieldValue(3, c))
                    {
                        return false;
                    }

                }

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
