using Pastel;
using System.Drawing;

namespace GoldRush.Models.Tracks
{
    public class PortTrack : Track
    {
        public PortTrack(Game game, Direction input, Direction output) : base(game, input, output)
        {
        }

        public override string Draw()
        {
            return "░".Pastel(GetColor()).PastelBg(Color.Blue);
        }

        public override void OnEnter()
        {
            Cart.Full = false;
            _game.DecreaseInterval();
        }
    }
}
