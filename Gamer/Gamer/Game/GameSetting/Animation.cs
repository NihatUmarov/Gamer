using Xamarin.Forms;

namespace Gamer.Game
{
    public class Animation
    {
        public async void AnimationUpDown(Button button)
        {
            await button.TranslateTo(0, -20, 100);
            await button.TranslateTo(0, 0, 100);
        }
        public async void IAnimationUpDown(ImageButton button)
        {
            await button.TranslateTo(0, -20, 100);
            await button.TranslateTo(0, 0, 100);
        }
    }
}
