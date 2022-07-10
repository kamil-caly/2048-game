using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace _2048_game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ImageSource[] blocks = new ImageSource[]
        {
            new BitmapImage(new Uri("img/empty.png", UriKind.Relative)),
            new BitmapImage(new Uri("img/2.png", UriKind.Relative)),
            new BitmapImage(new Uri("img/4.png", UriKind.Relative)),
            new BitmapImage(new Uri("img/8.png", UriKind.Relative)),
            new BitmapImage(new Uri("img/16.png", UriKind.Relative)),
            new BitmapImage(new Uri("img/32.png", UriKind.Relative)),
            new BitmapImage(new Uri("img/64.png", UriKind.Relative)),
            new BitmapImage(new Uri("img/128.png", UriKind.Relative)),
            new BitmapImage(new Uri("img/256.png", UriKind.Relative)),
            new BitmapImage(new Uri("img/512.png", UriKind.Relative)),
            new BitmapImage(new Uri("img/1024.png", UriKind.Relative)),
            new BitmapImage(new Uri("img/2048.png", UriKind.Relative))
        };

        private Image [,] xmlImgSource;

        public GameBoard gameBoard;
        public RandomNumberLogic randomNumberLogic;
        public KeyClickLogic keyLogic;
        public GameOver gameOver;
        private bool userInput = true;

        public MainWindow()
        {
            InitializeComponent();

            xmlImgSource = new Image[,]
            {
                { img1, img2, img3, img4 },
                { img5, img6, img7, img8 },
                { img9, img10, img11, img12 },
                { img13, img14, img15, img16 }
            };

            randomNumberLogic = new RandomNumberLogic();
            gameBoard = new GameBoard();
            keyLogic = new KeyClickLogic();
            gameOver = new GameOver();
        }

        //////////// setting board to view //////////////
        private void setBoardToView()
        {
            for (int r = 0; r < gameBoard.getRows(); r++)
            {
                for (int c = 0; c < gameBoard.getColumns(); c++)
                {
                    switch (gameBoard.getFieldValue(r,c))
                    {
                        case 0:
                            xmlImgSource[r, c].Source = blocks[0];
                            break;
                        case 2:
                            xmlImgSource[r, c].Source = blocks[1];
                            break;
                        case 4:
                            xmlImgSource[r, c].Source = blocks[2];
                            break;
                        case 8:
                            xmlImgSource[r, c].Source = blocks[3];
                            break;
                        case 16:
                            xmlImgSource[r, c].Source = blocks[4];
                            break;
                        case 32:
                            xmlImgSource[r, c].Source = blocks[5];
                            break;
                        case 64:
                            xmlImgSource[r, c].Source = blocks[6];
                            break;
                        case 128:
                            xmlImgSource[r, c].Source = blocks[7];
                            break;
                        case 256:
                            xmlImgSource[r, c].Source = blocks[8];
                            break;
                        case 512:
                            xmlImgSource[r, c].Source = blocks[9];
                            break;
                        case 1024:
                            xmlImgSource[r, c].Source = blocks[10];
                            break;
                        case 2048:
                            xmlImgSource[r, c].Source = blocks[11];
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void DoesEndGame()
        {
            if(gameOver.IsGameOver(gameBoard))
            {
                this.GameOverMenu.Visibility = Visibility.Visible;
                this.FinalTextScore.Text = "Final Score: " + this.ScoreText.Text;
            }
        }

        /*private async void myDelay()
        {
            await Task.Delay(500);
            randomNumberLogic.setRandomValueAfterMove(gameBoard);
            this.setBoardToView();
            this.ScoreText.Text = "Score: " + GamePoints.getPoints().ToString();
        }*/

        private void restartGame()
        {
            GamePoints.resetPoints();
            this.ScoreText.Text = "Score: 0";
            gameBoard = new GameBoard();
            randomNumberLogic.setStartGameValueToBoard(gameBoard);
            this.setBoardToView();
        }
        private async void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(userInput)
            {
                switch (e.Key)
                {
                    case Key.D:
                        keyLogic.MoveLogic('d', gameBoard);
                        break;
                    case Key.A:
                        keyLogic.MoveLogic('a', gameBoard);
                        break;
                    case Key.S:
                        keyLogic.MoveLogic('s', gameBoard); ;
                        break;
                    case Key.W:
                        keyLogic.MoveLogic('w', gameBoard);
                        break;

                    default:
                        break;
                }

                userInput = false;
                this.setBoardToView();

                this.ScoreText.Text = "Score: " + GamePoints.getPoints().ToString();
                var splitHightScore = HighScoreText.Text.Split(" ");
                if (GamePoints.getPoints() > Convert.ToInt32(splitHightScore[1]))
                {
                    this.HighScoreText.Text = "HightScore: " + GamePoints.getPoints().ToString();
                }

                await Task.Delay(200);
                randomNumberLogic.setRandomValueAfterMove(gameBoard);
                this.setBoardToView();
                userInput = true;
            }

            DoesEndGame();
        }

        private void PlayAgain_Click(object sender, RoutedEventArgs e)
        {
            this.restartGame();
            this.GameOverMenu.Visibility = Visibility.Hidden;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            randomNumberLogic.setStartGameValueToBoard(gameBoard);
            this.setBoardToView();
        }
    }
}
