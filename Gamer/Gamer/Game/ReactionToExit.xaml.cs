using Gamer.Game.GameSetting;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gamer.Game
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReactionToExit : ContentPage
    {
        Random random = new Random();
        bool fire = false;
        private RandomTime timer;
        public ReactionToExit()
        {
            InitializeComponent();
            FireButton.Pressed += FireClicked;
            timer = new RandomTime(TimeLabel);
        }
        public async void StartGame()
        {
            timer.Start();
            while (TimeLabel.Text != "0")
            {
                await Task.Delay(1000);
            }
            await Enemy.TranslateTo(100, 0, 200);
            StartLabel.Text = "Вы проиграли";
            fire = true;
            await Task.Delay(MainPage.Level.GetCount);
            timer.Stop();
            GameOver.IsVisible = true;
            
        }
        private void FireClicked(object sender, System.EventArgs e)
        {
            if(fire == true)
            {
                StartLabel.Text = "Вы победили";
                timer.Stop();
            }
            else
            {
                timer.Stop();
                StartLabel.Text = "Вы проиграли";
                GameOver.IsVisible = true;
            }
        }
        private async void GameOver_Clicked(object sender, EventArgs e)
        {
            await Task.Delay(250);
            timer.Stop();
            fire = false;
            StartGame();
            await Enemy.TranslateTo(-100, 0, 0);
            GameOver.IsVisible = false;
        }
    }
}