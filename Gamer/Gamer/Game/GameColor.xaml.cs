using System;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gamer.Game
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameColor : ContentPage
    {
        Game game = new Game();
        MainPage level = new MainPage();
        Random random = new Random();
        Animation animation = new Animation();
        int color = 0;
        public GameColor()
        {
            InitializeComponent();
        }
        private async void StartGame()
        {
            await Task.Delay(1000);
            game.score = 0;
            for (int i = 0; i < 20; i++)
            {
                await RandomColor();
            }
            StartLabel.Text = game.score.ToString();
            GameOver.IsVisible = true;
        }
        private async Task RandomColor()
        {
            color = random.Next(1, 5);
            switch (color)
            {
                case 1: BackColor.BackgroundColor = Color.Yellow; break;
                case 2: BackColor.BackgroundColor = Color.Red; break;
                case 3: BackColor.BackgroundColor = Color.Blue; break;
                case 4: BackColor.BackgroundColor = Color.LimeGreen; break;
            }
            await Task.Delay(MainPage.Level.GetTime);
            color = 0;
            BackColor.BackgroundColor = Color.Transparent;
            await Task.Delay(1000);
        }
        private void ButtonFunc(int value)
        {
            if(color == value)
            {
                game.score++;
            }
            BackColor.BackgroundColor = Color.Transparent;
        }
        private void GameOver_Clicked(object sender, EventArgs e)
        {
            GameOver.IsVisible = false;
            StartGame();
        }
        private void YellowBtn(object sender, EventArgs e) => ButtonFunc(1);
        private void RedBtn(object sender, EventArgs e) => ButtonFunc(2);
        private void BlueBtn(object sender, EventArgs e) => ButtonFunc(3);
        private void GreenBtn(object sender, EventArgs e) => ButtonFunc(4);
    }
}