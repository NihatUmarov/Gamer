using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gamer.Game
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BallGame : ContentPage
    {
        Random random = new Random();
        Game game = new Game();
        public BallGame()
        {
            InitializeComponent();
            Ball.Pressed += BallClick;
        }
        private async void StartGame()
        {
            game.score = 0;
            for (int i = 0; i < 20; i++)
            {
                await VisibleBall();
            }
            StartLabel.Text = $"Счет: {game.score}";
            StartLabel.IsVisible = true;
            GameOver1.IsVisible = true;
            GameOver2.IsVisible = true;
            GameOver3.IsVisible = true;
        }
        private async Task VisibleBall()
        {
            Grid.SetColumn(Ball, random.Next(0, 7));
            Ball.TranslationY = random.Next(1, 280);
            await Task.Delay(2000);
            Ball.IsVisible = true;
            await Task.Delay(MainPage.Level.GetTime);
            Ball.IsVisible = false;
        }

        private void BallClick(object sender, EventArgs e)
        {
            game.score++;
            Ball.IsVisible = false;
        }

        private void GameOver_Clicked(object sender, EventArgs e)
        {
            StartLabel.IsVisible = false;
            GameOver1.IsVisible = false;
            GameOver2.IsVisible = false;
            GameOver3.IsVisible = false;
            StartGame();
        }
    }
}