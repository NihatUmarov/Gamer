using Gamer.Game;
using Gamer.Game.GameSetting;
using System;
using Xamarin.Forms;

namespace Gamer
{
    public partial class MainPage : ContentPage
    {
        GameLevel gameLevel = new GameLevel();
        public static GameLevel Level { get; set; } = new GameLevel { };
        public MainPage()
        {
            InitializeComponent();
        }

        private void GameBall_Clicked(object sender, System.EventArgs e)
        {
            GameSel("Попади в шарик", 1, 1);
        }
        private void Rhombus_Clicked(object sender, EventArgs e)
        {
            GameSel("Оперативное реагирование", 1, 0);
        }
        private void ReactionToExit(object sender, System.EventArgs e)
        {
            GameSel("Реакция на последовательность", 1, 2);
        }
        private void GameRect_Clicked(object sender, System.EventArgs e)
        {
            GameSel("Реакция на выход", 2, 1);
        }

        private void SequenceNumbers(object sender, EventArgs e)
        {
            GameSel("Последовательность чисел", 2, 0);
        }
        private void GameColor_Clicked(object sender, EventArgs e)
        {
            GameSel("Реакция на цвета", 2, 2);
        }
        private void GameSel(string str,int row, int column)
        {
            GameSelect.Text = str;
            LevelCheck.IsVisible = true;
            Grid.SetRow(LevelCheck, row);
            Grid.SetColumn(LevelCheck, column);
        }
        private async void Hight_Clicked(object sender, System.EventArgs e)
        {
            if (GameSelect.Text == "Попади в шарик")
            {
                Level.GetTime = 350; Level.GetCount = 4;

                await Navigation.PushAsync(new BallGame());
            }
            else if (GameSelect.Text == "Оперативное реагирование")
            {
                Level.GetTime = 430; Level.GetCount = 4;
                await Navigation.PushAsync(new RhombusGame());
            }
            else if (GameSelect.Text == "Реакция на последовательность")
            {
                Level.GetTime = 10000; Level.GetCount = 4;
                await Navigation.PushAsync(new GameReactToActions());
            }
            else if (GameSelect.Text == "Последовательность чисел")
            {
                Level.GetTime = 1200; Level.GetCount = 140;
                await Navigation.PushAsync(new SequenceNumbers());
            }
            else if (GameSelect.Text == "Реакция на выход")
            {
                Level.GetTime = 15; Level.GetCount = 140;
                await Navigation.PushAsync(new ReactionToExit());
            }
            else if (GameSelect.Text == "Реакция на цвета")
            {
                Level.GetTime = 500; Level.GetCount = 140;
                await Navigation.PushAsync(new GameColor());
            }
        }
        private async void Medium_Clicked(object sender, System.EventArgs e)
        {
            if (GameSelect.Text == "Попади в шарик")
            {
                Level.GetTime = 450; Level.GetCount = 3;
                await Navigation.PushAsync(new BallGame());
            }
            else if (GameSelect.Text == "Оперативное реагирование")
            {
                Level.GetTime = 510; Level.GetCount = 4;
                await Navigation.PushAsync(new RhombusGame());
            }
            else if (GameSelect.Text == "Реакция на последовательность")
            {
                Level.GetTime = 10000; Level.GetCount = 3;
                await Navigation.PushAsync(new GameReactToActions());
            }
            else if (GameSelect.Text == "Последовательность чисел")
            {
                Level.GetTime = 1600; Level.GetCount = 140;
                await Navigation.PushAsync(new SequenceNumbers());
            }
            else if (GameSelect.Text == "Реакция на выход")
            {
                Level.GetTime = 12; Level.GetCount = 180;
                await Navigation.PushAsync(new ReactionToExit());
            }
            else if (GameSelect.Text == "Реакция на цвета")
            {
                Level.GetTime = 700; Level.GetCount = 140;
                await Navigation.PushAsync(new GameColor());
            }
        }
        private async void Easy_Clicked(object sender, System.EventArgs e)
        { 
            if (GameSelect.Text == "Попади в шарик")
            {
                Level.GetTime = 600; Level.GetCount = 2;
                await Navigation.PushAsync(new BallGame());
            }
            else if (GameSelect.Text == "Оперативное реагирование")
            {
                Level.GetTime = 600; Level.GetCount = 4;
                await Navigation.PushAsync(new RhombusGame());
            }
            else if (GameSelect.Text == "Реакция на последовательность")
            {
                Level.GetTime = 10000; Level.GetCount = 2;
                await Navigation.PushAsync(new GameReactToActions());
            }
            else if (GameSelect.Text == "Последовательность чисел")
            {
                Level.GetTime = 2000; Level.GetCount = 140;
                await Navigation.PushAsync(new SequenceNumbers());
            }
            else if (GameSelect.Text == "Реакция на выход")
            {
                Level.GetTime = 10; Level.GetCount = 250;
                await Navigation.PushAsync(new ReactionToExit());
            }
            else if (GameSelect.Text == "Реакция на цвета")
            {
                Level.GetTime = 1000; Level.GetCount = 140;
                await Navigation.PushAsync(new GameColor());
            }
        }
    }
}
