using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gamer.Game
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SequenceNumbers : ContentPage
    {
        Game game = new Game();
        MainPage level = new MainPage();
        Random random = new Random();
        Animation animation = new Animation();
        public int count = 0;
        public int[] randomNums = new int[10];
        public SequenceNumbers()
        {
            InitializeComponent();
        }
        private async void StartGame()
        {
            EmptyArray();
            await Task.Delay(1000);
            game.score = 0;
            for (int i = 0; i < 10; i++)
            {
                count = 0;
                await RandomNum();
            }
            StartLabel.Text = game.score.ToString();
            GameOver.IsVisible = true;
        }
        private async Task RandomNum()
        {
            do
            {
                randomNums[0] = random.Next(1, 6);
                randomNums[1] = random.Next(1, 6);
                randomNums[2] = random.Next(1, 6);
            }
            while (randomNums[0] == randomNums[1] || randomNums[0] == randomNums[2] || randomNums[1] == randomNums[2]);
            Check1.Text = randomNums[0].ToString();
            Check2.Text = randomNums[1].ToString();
            Check3.Text = randomNums[2].ToString();
            await Task.Delay(MainPage.Level.GetTime);
            EmptyArray();
            await Task.Delay(1000);
        }
        private void SignUpDown()
        {
            switch (count)
            {
                case 0: animation.AnimationUpDown(Check1);break;
                case 1: animation.AnimationUpDown(Check2); break;
                case 2: animation.AnimationUpDown(Check3); break;
            }
        }
        private void ButtonFunctions(int value)
        {
            if (value == randomNums[count])
            {
                SignUpDown();
                count++;
            }
            if (count >= 3)
            {
                game.score++;
                count = 0;
                EmptyArray();
            }
        }
        
        private void EmptyArray()
        {
            Check1.Text = "";
            Check2.Text = "";
            Check3.Text = "";
            randomNums[0] = 0;
            randomNums[1] = 0;
            randomNums[2] = 0;
        }
        private void GameOver_Clicked(object sender, EventArgs e)
        {
            StartGame();
            GameOver.IsVisible = false;
        }
        private void Btn1_Clicked(object sender, EventArgs e) => ButtonFunctions(1);
        private void Btn2_Clicked(object sender, EventArgs e) => ButtonFunctions(2);
        private void Btn3_Clicked(object sender, EventArgs e) => ButtonFunctions(3);
        private void Btn4_Clicked(object sender, EventArgs e) => ButtonFunctions(4);
        private void Btn5_Clicked(object sender, EventArgs e) => ButtonFunctions(5);
    }
}