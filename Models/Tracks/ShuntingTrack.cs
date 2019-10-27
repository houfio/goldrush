using System.Drawing;

namespace GoldRush.Models.Tracks
{
    public class ShuntingTrack : Track
    {
        public ShuntingTrack(Game game, Direction input, Direction output) : base(game, input, output)
        {
        }

        public override Color GetColor()
        {
            return Cart == null ? Color.Green : Color.GreenYellow;
        }

        public override bool CanCrash()
        {
            // Carts don't crash on this track!
            return false;
        }
    }
}
