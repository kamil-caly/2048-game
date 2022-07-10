using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048_game
{
    public class RandomNumberLogic
    {
        public int randomValue { get; set; }
        public Random random { get; set; } = new Random();
        public RandomNumberLogic()
        {
            randomValue = random.Next(1, 11);
        }

        //////////// at start on the board we have two random value(10% - 4, 90% - 2) ////////////
        public void setStartGameValueToBoard(GameBoard gameBoard)
        {
            int temp = 2;
            while(temp > 0)
            {
                int rowRand = random.Next(0, 4), colRand = random.Next(0, 4); // do 4 bo wtedy max value to 3
                if (gameBoard.isFieldEmpty(rowRand, colRand))
                {
                    gameBoard.setFieldValue(rowRand, colRand, this.getRandomValue());
                    temp--;
                }
            }  
        }

        public void setRandomValueAfterMove(GameBoard gameBoard)
        {
            if(!gameBoard.isBoardFull())
            {
                while (true)
                {
                    int rowRand = random.Next(0, 4), colRand = random.Next(0, 4); // do 4 bo wtedy max value to 3
                    if (gameBoard.isFieldEmpty(rowRand, colRand))
                    {
                        gameBoard.setFieldValue(rowRand, colRand, this.getRandomValue());
                        break;
                    }
                }
            }
        }

        public int getRandomValue()
        {
            if (random.Next(1, 11) == 1)
                return randomValue = 4;
            else
                return randomValue = 2;
        }
    }
}
