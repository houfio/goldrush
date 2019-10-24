using System.Drawing;

namespace GoldRush.Models.Tracks
{
    public class PortTrack : Track
    {
        public PortTrack(Game game, Direction input, Direction output) : base(game, input, output)
        {
        }

        public override Color GetColor()
        {
            return Cart == null ? Color.Blue : Cart.GetColor();
        }

        public override void OnEnter()
        {
            Cart.Full = false;
        }
    }
}
