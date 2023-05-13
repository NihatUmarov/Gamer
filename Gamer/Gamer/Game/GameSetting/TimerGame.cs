using System;
using System.Threading;
using Xamarin.Forms;

namespace Gamer.Game.GameSetting
{
    public class TimerGame
    {
        private int count;
        private bool isRunning;
        private Label label;
        private Func<bool> timerCallback;
        CancellationTokenSource cts = new CancellationTokenSource();

        public TimerGame(Label label)
        {
            this.label = label;
            count = 4;
            isRunning = false;
        }

        public void Start()
        {
            count = 4;
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
            count = 100;
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
