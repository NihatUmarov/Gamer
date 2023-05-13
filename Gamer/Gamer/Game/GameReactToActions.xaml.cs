using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Gamer.Game.GameSetting;

namespace Gamer.Game
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameReactToActions : ContentPage
    {
        Random random = new Random();
        int[] randomNum = new int[10];
        int[] randomBtn = {1,2,3,4};
        Game game = new Game();
        private TimerGame timer;
        private bool Over = true;
        Animation animation = new Animation();
 
        public GameReactToActions()
        {
            InitializeComponent();
            timer = new TimerGame(TimeLabel);
            switch (MainPage.Level.GetCount)
            {
                case 2: BtnGame3.IsVisible = false; BtnGame4.IsVisible = false; break;
                case 3: BtnGame4.IsVisible = false; break;
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        private async void StartGame()
        {
            Over = true;
            game.score = 0;
            BorderColorWhite();
            RandomBtn();
            GetSubsequence();
            StartLabel.IsVisible = false; 
            GameOver.IsVisible = false;
            timer.Start();
            await Task.Delay(4450);
            if (Over && TimeLabel.Text == "0")
            {
                StartLabel.Text = "Вы проиграли";
                StartLabel.IsVisible = true;
                GameOver.IsVisible = true;
                timer.Stop();
            }
       
        }
        private void RandomBtn()
        {
            for (int i = 0; i < randomBtn.Length; i++)
            {
                int j = random.Next(i, randomBtn.Length);
                int temp = randomBtn[i];
                randomBtn[i] = randomBtn[j];
                randomBtn[j] = temp;
            }

            BtnGame1.Source = GetButtonImage(randomBtn[0]);
            BtnGame2.Source = GetButtonImage(randomBtn[1]);
            BtnGame3.Source = GetButtonImage(randomBtn[2]);
            BtnGame4.Source = GetButtonImage(randomBtn[3]);
        }
        
        private string GetButtonImage(int value)
        {
            switch (value)
            {
                case 1: return "Circle";
                case 2: return "Square";
                case 3: return "Triangle";
                case 4: return "Star";
            }
            return "";
        }

        private void BorderColorWhite()
        {
            Btn0.BorderColor = Color.Transparent;
            Btn1.BorderColor = Color.Transparent;
            Btn2.BorderColor = Color.Transparent;
            Btn3.BorderColor = Color.Transparent;
            Btn4.BorderColor = Color.Transparent;
            Btn5.BorderColor = Color.Transparent;
            Btn6.BorderColor = Color.Transparent;
            Btn7.BorderColor = Color.Transparent;
            Btn8.BorderColor = Color.Transparent;
            Btn9.BorderColor = Color.Transparent;
        }
        private void GetSubsequence()
        {
            int[] arr = { randomBtn[0], randomBtn[1], randomBtn[2], randomBtn[3] };

            for (int i = 0; i < 10; i++)
            {
                randomNum[i] = arr[random.Next(MainPage.Level.GetCount)];
            }

            Btn0.Source = GetButtonImage(randomNum[0]);
            Btn1.Source = GetButtonImage(randomNum[1]);
            Btn2.Source = GetButtonImage(randomNum[2]);
            Btn3.Source = GetButtonImage(randomNum[3]);
            Btn4.Source = GetButtonImage(randomNum[4]);
            Btn5.Source = GetButtonImage(randomNum[5]);
            Btn6.Source = GetButtonImage(randomNum[6]);
            Btn7.Source = GetButtonImage(randomNum[7]);
            Btn8.Source = GetButtonImage(randomNum[8]);
            Btn9.Source = GetButtonImage(randomNum[9]);
        }
        private void BorderGreen()
        {
            switch (game.score)
            {
                case 0: Btn0.BorderColor = Color.GreenYellow; animation.IAnimationUpDown(Btn0); break;
                case 1: Btn1.BorderColor = Color.GreenYellow; animation.IAnimationUpDown(Btn1); break;
                case 2: Btn2.BorderColor = Color.GreenYellow; animation.IAnimationUpDown(Btn2); break;
                case 3: Btn3.BorderColor = Color.GreenYellow; animation.IAnimationUpDown(Btn3); break;
                case 4: Btn4.BorderColor = Color.GreenYellow; animation.IAnimationUpDown(Btn4); break;
                case 5: Btn5.BorderColor = Color.GreenYellow; animation.IAnimationUpDown(Btn5); break;
                case 6: Btn6.BorderColor = Color.GreenYellow; animation.IAnimationUpDown(Btn6); break;
                case 7: Btn7.BorderColor = Color.GreenYellow; animation.IAnimationUpDown(Btn7); break;
                case 8: Btn8.BorderColor = Color.GreenYellow; animation.IAnimationUpDown(Btn8); break;
                case 9: Btn9.BorderColor = Color.GreenYellow; animation.IAnimationUpDown(Btn9); break;
            }
        }
        private void BtnFunction(int value)
        {
            if (randomNum[game.score] == value)
            {
                BorderGreen();
                game.score++;
                if (game.score == 10)
                {
                    Over = false;
                    StartLabel.Text = "Вы победили";
                    StartLabel.IsVisible = true; 
                    GameOver.IsVisible = true;
                }
            }
            else
            {
                StartLabel.Text = "Вы проиграли";
                StartLabel.IsVisible = true; 
                GameOver.IsVisible = true;
            }
        }
        private void GameOver_Clicked(object sender, EventArgs e)
        {
            StartGame();
        }
        private void BtnGame1_Clicked(object sender, EventArgs e) => BtnFunction(randomBtn[0]);
        private void BtnGame2_Clicked(object sender, EventArgs e) => BtnFunction(randomBtn[1]);
        private void BtnGame3_Clicked(object sender, EventArgs e) => BtnFunction(randomBtn[2]);
        private void BtnGame4_Clicked(object sender, EventArgs e) => BtnFunction(randomBtn[3]);
    }
}