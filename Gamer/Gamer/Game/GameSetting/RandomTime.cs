using System;
using System.Threading;
using Xamarin.Forms;

namespace Gamer.Game.GameSetting
{
    public class RandomTime
    {
        private int count;
        private bool isRunning;
        private Label label;
        private Func<bool> timerCallback;
        Random random = new Random();
        CancellationTokenSource cts = new CancellationTokenSource();

        public RandomTime(Label label)
        {
            this.label = label;
            count = random.Next(7, MainPage.Level.GetTime);
            isRunning = false;
        }

        public void Start()
        {
            if (!isRunning)
            {
                isRunning = true;
                timerCallback = OnTimerTick;
                Device.StartTimer(TimeSpan.FromSeconds(1), timerCallback);
            }
        }

        public void Stop()
        {
            isRunning = false;
            cts?.Cancel();
            count = random.Next(7, MainPage.Level.GetTime);
            label.Text = $"{count}";
        }
        private bool OnTimerTick()
        {
            if (count == 0)
            {
                label.Text = "0";
                isRunning = false;
                return false;
            }

            count--;
            label.Text = $"{count}";

            if (count == 0)
            {
                isRunning = false;
            }

            return isRunning;
        }
    }
}
