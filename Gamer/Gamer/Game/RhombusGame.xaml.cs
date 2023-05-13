using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gamer.Game
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RhombusGame : ContentPage
    {
        Game game = new Game();
        Random random = new Random();
        Animation animation = new Animation();  
        public RhombusGame()
        {
            InitializeComponent();
        }

        private async void StartGame()
        {
            game.score = 0;
            for (int i = 0; i < 20; i++)
            {
                await GetSign();
            }
            StartLabel.Text = game.score.ToString();
            GameOver.IsVisible = true;
        }
        private async Task GetSign()
        {
            int num1 = random.Next(1, 6);
            int num2 = random.Next(1, 6);
            await Task.Delay(2000);
            GreenSign(num1, num2);
            await Task.Delay(MainPage.Level.GetTime);
            if(Sign1.BackgroundColor == Color.White && Sign2.BackgroundColor == Color.White && Sign3.BackgroundColor == Color.White && Sign4.BackgroundColor == Color.White)
            {
                game.score++;
            }
            WhitheSign();
        }
        private void WhitheSign()
        {
            Sign1.BackgroundColor = Color.White;
            Sign2.BackgroundColor = Color.White;
            Sign3.BackgroundColor = Color.White;
            Sign4.BackgroundColor = Color.White;
            Sign5.BackgroundColor = Color.White;
        }
        private void GreenSign(int value1,int value2)
        {
            switch(value1)
            {
                case 1: Sign1.BackgroundColor = Color.GreenYellow; break;
                case 2: Sign2.BackgroundColor = Color.GreenYellow; break;
                case 3: Sign3.BackgroundColor = Color.GreenYellow; break;
                case 4: Sign4.BackgroundColor = Color.GreenYellow; break;
                case 5: Sign5.BackgroundColor = Color.GreenYellow; break;
            }
            switch (value2)
            {
                case 1: Sign1.BackgroundColor = Color.GreenYellow; break;
                case 2: Sign2.BackgroundColor = Color.GreenYellow; break;
                case 3: Sign3.BackgroundColor = Color.GreenYellow; break;
                case 4: Sign4.BackgroundColor = Color.GreenYellow; break;
                case 5: Sign5.BackgroundColor = Color.GreenYellow; break;
            }
        }
        private void Btn1_Clicked(object sender, EventArgs e)
        {
            Sign1.BackgroundColor = Color.White;
            animation.AnimationUpDown(Btn1);
        }

        private void Btn2_Clicked(object sender, EventArgs e)
        {
            Sign2.BackgroundColor = Color.White;
            animation.AnimationUpDown(Btn2);
        }

        private void Btn3_Clicked(object sender, EventArgs e)
        {
            Sign3.BackgroundColor = Color.White;
            animation.AnimationUpDown(Btn3);
        }

        private void Btn4_Clicked(object sender, EventArgs e)
        {
            Sign4.BackgroundColor = Color.White;
            animation.AnimationUpDown(Btn4);
        }

        private void Btn5_Clicked(object sender, EventArgs e)
        {
            Sign5.BackgroundColor = Color.White;
            animation.AnimationUpDown(Btn5);
        }

        private void GameOver_Clicked(object sender, EventArgs e)
        {
            StartGame();
            GameOver.IsVisible = false;
        }
    }
}