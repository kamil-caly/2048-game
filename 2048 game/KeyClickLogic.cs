using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048_game
{
    public class KeyClickLogic
    {
        public bool MoveLogic(char key, GameBoard gameBoard)
        {
            GameBoard prevGameBoard = gameBoard.Copy();

            this.shiftLogic(key, gameBoard);
            this.mergeLogic(key, gameBoard);
            this.shiftLogic(key, gameBoard);

            if (gameBoard.Compare(prevGameBoard))
            {
                return false;
            }

            return true;
        }

        public void shiftLogic(char key, GameBoard gameBoard)
        {
            switch (key)
            {
                case 'd':
                    this.shiftRightLogic(gameBoard);
                    break;
                case 'a':
                    this.shiftLeftLogic(gameBoard);
                    break;
                case 's':
                    this.shiftDownLogic(gameBoard);
                    break;
                case 'w':
                    this.shiftUpLogic(gameBoard);
                    break;
                default:
                    break;
            }
        }

        public void mergeLogic(char key, GameBoard gameBoard)
        {
            switch (key)
            {
                case 'd':
                    this.rightMerge(gameBoard);
                    break;
                case 'a':
                    this.leftMerge(gameBoard);
                    break;
                case 's':
                    this.downMerge(gameBoard);
                    break;
                case 'w':
                    this.upMerge(gameBoard);
                    break;
                default:
                    break;
            }
        }

        //  0 0 0 0
        //  0 2 0 0
        //  0 2 0 2
        //  2 2 2 2
        public void shiftRightLogic(GameBoard gameBoard)
        {
            for (int r = 0; r < gameBoard.getRows(); r++)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (gameBoard.getFieldValue(r, 3) == 0)
                    {
                        gameBoard.setFieldValue(r, 3, gameBoard.getFieldValue(r, 2));
                        gameBoard.setFieldValue(r, 2, 0);
                    }

                    if (gameBoard.getFieldValue(r, 2) == 0)
                    {
                        gameBoard.setFieldValue(r, 2, gameBoard.getFieldValue(r, 1));
                        gameBoard.setFieldValue(r, 1, 0);
                    }

                    if (gameBoard.getFieldValue(r, 1) == 0)
                    {
                        gameBoard.setFieldValue(r, 1, gameBoard.getFieldValue(r, 0));
                        gameBoard.setFieldValue(r, 0, 0);
                    }
                }  
            }
        }

        public void shiftLeftLogic(GameBoard gameBoard)
        {
            for (int r = 0; r < gameBoard.getRows(); r++)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (gameBoard.getFieldValue(r, 0) == 0)
                    {
                        gameBoard.setFieldValue(r, 0, gameBoard.getFieldValue(r, 1));
                        gameBoard.setFieldValue(r, 1, 0);
                    }

                    if (gameBoard.getFieldValue(r, 1) == 0)
                    {
                        gameBoard.setFieldValue(r, 1, gameBoard.getFieldValue(r, 2));
                        gameBoard.setFieldValue(r, 2, 0);
                    }

                    if (gameBoard.getFieldValue(r, 2) == 0)
                    {
                        gameBoard.setFieldValue(r, 2, gameBoard.getFieldValue(r, 3));
                        gameBoard.setFieldValue(r, 3, 0);
                    }
                }
            }
        }

        public void shiftDownLogic(GameBoard gameBoard)
        {
            for (int c = 0; c < gameBoard.getColumns(); c++)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (gameBoard.getFieldValue(3, c) == 0)
                    {
                        gameBoard.setFieldValue(3, c, gameBoard.getFieldValue(2, c));
                        gameBoard.setFieldValue(2, c, 0);
                    }

                    if (gameBoard.getFieldValue(2, c) == 0)
                    {
                        gameBoard.setFieldValue(2, c, gameBoard.getFieldValue(1, c));
                        gameBoard.setFieldValue(1, c, 0);
                    }

                    if (gameBoard.getFieldValue(1, c) == 0)
                    {
                        gameBoard.setFieldValue(1, c, gameBoard.getFieldValue(0, c));
                        gameBoard.setFieldValue(0, c, 0);
                    }
                }
            }
        }

        public void shiftUpLogic(GameBoard gameBoard)
        {
            for (int c = 0; c < gameBoard.getColumns(); c++)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (gameBoard.getFieldValue(0, c) == 0)
                    {
                        gameBoard.setFieldValue(0, c, gameBoard.getFieldValue(1, c));
                        gameBoard.setFieldValue(1, c, 0);
                    }

                    if (gameBoard.getFieldValue(1, c) == 0)
                    {
                        gameBoard.setFieldValue(1, c, gameBoard.getFieldValue(2, c));
                        gameBoard.setFieldValue(2, c, 0);
                    }

                    if (gameBoard.getFieldValue(2, c) == 0)
                    {
                        gameBoard.setFieldValue(2, c, gameBoard.getFieldValue(3, c));
                        gameBoard.setFieldValue(3, c, 0);
                    }
                }
            }
        }

        // 0 0 1 1
        public void rightMerge(GameBoard gameBoard)
        {
            for (int r = 0; r < gameBoard.getRows(); r++)
            {
                // 2 4 4 4
                if(gameBoard.getFieldValue(r, 2) == gameBoard.getFieldValue(r, 3))
                {
                    gameBoard.setFieldValue(r, 2, 0);
                    gameBoard.setFieldValue(r, 3, gameBoard.getFieldValue(r, 3) * 2);
                    GamePoints.updatePoints(gameBoard.getFieldValue(r, 3));

                    // 4 4 8 2
                    if (gameBoard.getFieldValue(r, 0) == gameBoard.getFieldValue(r, 1))
                    {
                        gameBoard.setFieldValue(r, 0, 0);
                        gameBoard.setFieldValue(r, 1, gameBoard.getFieldValue(r, 1) * 2);
                        GamePoints.updatePoints(gameBoard.getFieldValue(r, 1));
                    }
                }

                // 2 4 4 8
                else if (gameBoard.getFieldValue(r, 1) == gameBoard.getFieldValue(r, 2))
                {
                    gameBoard.setFieldValue(r, 1, 0);
                    gameBoard.setFieldValue(r, 2, gameBoard.getFieldValue(r, 2) * 2);
                    GamePoints.updatePoints(gameBoard.getFieldValue(r, 2));
                }

                // 4 4 0 2
                else if (gameBoard.getFieldValue(r, 0) == gameBoard.getFieldValue(r, 1))
                {
                    gameBoard.setFieldValue(r, 0, 0);
                    gameBoard.setFieldValue(r, 1, gameBoard.getFieldValue(r, 1) * 2);
                    GamePoints.updatePoints(gameBoard.getFieldValue(r, 1));
                }
            }
        }

        public void leftMerge(GameBoard gameBoard)
        {
            for (int r = 0; r < gameBoard.getRows(); r++)
            {
                // 4 4 4 2
                if (gameBoard.getFieldValue(r, 0) == gameBoard.getFieldValue(r, 1))
                {
                    gameBoard.setFieldValue(r, 1, 0);
                    gameBoard.setFieldValue(r, 0, gameBoard.getFieldValue(r, 0) * 2);
                    GamePoints.updatePoints(gameBoard.getFieldValue(r, 0));

                    // 4 4 4 4
                    if (gameBoard.getFieldValue(r, 2) == gameBoard.getFieldValue(r, 3))
                    {
                        gameBoard.setFieldValue(r, 3, 0);
                        gameBoard.setFieldValue(r, 2, gameBoard.getFieldValue(r, 2) * 2);
                        GamePoints.updatePoints(gameBoard.getFieldValue(r, 2));
                    }
                }

                // 2 4 4 8
                else if (gameBoard.getFieldValue(r, 1) == gameBoard.getFieldValue(r, 2))
                {
                    gameBoard.setFieldValue(r, 2, 0);
                    gameBoard.setFieldValue(r, 1, gameBoard.getFieldValue(r, 1) * 2);
                    GamePoints.updatePoints(gameBoard.getFieldValue(r, 1));
                }

                // 2 8 4 4
                else if (gameBoard.getFieldValue(r, 2) == gameBoard.getFieldValue(r, 3))
                {
                    gameBoard.setFieldValue(r, 3, 0);
                    gameBoard.setFieldValue(r, 2, gameBoard.getFieldValue(r, 2) * 2);
                    GamePoints.updatePoints(gameBoard.getFieldValue(r, 2));
                }
            }
        }

        public void downMerge(GameBoard gameBoard)
        {
            for (int c = 0; c < gameBoard.getRows(); c++)
            {
                // 2
                // 4
                // 8
                // 8
                if (gameBoard.getFieldValue(2, c) == gameBoard.getFieldValue(3, c))
                {
                    gameBoard.setFieldValue(2, c, 0);
                    gameBoard.setFieldValue(3, c, gameBoard.getFieldValue(3, c) * 2);
                    GamePoints.updatePoints(gameBoard.getFieldValue(3, c));

                    // 4
                    // 4
                    // 8
                    // 2
                    if (gameBoard.getFieldValue(0, c) == gameBoard.getFieldValue(1, c))
                    {
                        gameBoard.setFieldValue(0, c, 0);
                        gameBoard.setFieldValue(1, c, gameBoard.getFieldValue(1, c) * 2);
                        GamePoints.updatePoints(gameBoard.getFieldValue(1, c));
                    }
                }

                // 2
                // 4
                // 4
                // 8
                else if (gameBoard.getFieldValue(1, c) == gameBoard.getFieldValue(2, c))
                {
                    gameBoard.setFieldValue(1, c, 0);
                    gameBoard.setFieldValue(2, c, gameBoard.getFieldValue(2, c) * 2);
                    GamePoints.updatePoints(gameBoard.getFieldValue(2, c));
                }

                // 4
                // 4
                // 8
                // 4
                else if (gameBoard.getFieldValue(0, c) == gameBoard.getFieldValue(1, c))
                {
                    gameBoard.setFieldValue(0, c, 0);
                    gameBoard.setFieldValue(1, c, gameBoard.getFieldValue(1, c) * 2);
                    GamePoints.updatePoints(gameBoard.getFieldValue(1, c));
                }
            }
        }

        public void upMerge(GameBoard gameBoard)
        {
            for (int c = 0; c < gameBoard.getRows(); c++)
            {
                // 4
                // 4
                // 2
                // 8
                if (gameBoard.getFieldValue(0, c) == gameBoard.getFieldValue(1, c))
                {
                    gameBoard.setFieldValue(1, c, 0);
                    gameBoard.setFieldValue(0, c, gameBoard.getFieldValue(0, c) * 2);
                    GamePoints.updatePoints(gameBoard.getFieldValue(0, c));

                    // 2
                    // 0
                    // 4
                    // 4
                    if (gameBoard.getFieldValue(3, c) == gameBoard.getFieldValue(2, c))
                    {
                        gameBoard.setFieldValue(3, c, 0);
                        gameBoard.setFieldValue(2, c, gameBoard.getFieldValue(2, c) * 2);
                        GamePoints.updatePoints(gameBoard.getFieldValue(2, c));
                    }
                }

                // 2
                // 4
                // 4
                // 8
                else if (gameBoard.getFieldValue(1, c) == gameBoard.getFieldValue(2, c))
                {
                    gameBoard.setFieldValue(2, c, 0);
                    gameBoard.setFieldValue(1, c, gameBoard.getFieldValue(1, c) * 2);
                    GamePoints.updatePoints(gameBoard.getFieldValue(1, c));
                }

                // 8
                // 2
                // 4
                // 4
                else if (gameBoard.getFieldValue(2, c) == gameBoard.getFieldValue(3, c))
                {
                    gameBoard.setFieldValue(3, c, 0);
                    gameBoard.setFieldValue(2, c, gameBoard.getFieldValue(2, c) * 2);
                    GamePoints.updatePoints(gameBoard.getFieldValue(2, c));
                }
            }
        }

    } //class
}
