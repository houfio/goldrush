using Pastel;
using System.Drawing;

namespace GoldRush.Models.Tracks
{
    public class WarehouseTrack : Track
    {
        private string _number;

        public WarehouseTrack(Game game, string number) : base(game, Direction.East, Direction.East)
        {
            _number = number;
        }

        public override string Draw()
        {
            return _number.Pastel(Color.White).PastelBg(Color.Red);
        }

        public override Cart Update()
        {
            if (_game.Map.Random.Next(40 - _game.Interval) != 0)
            {
                return null;
            }

            var position = Output.Offset(Position);
            var track = _game.Map.GetTrack(position);

            if (track == null || (track.Cart != null && track.CanCrash()))
            {
                // game over

                return null;
            }

            track.Cart = new Cart();

            return track.Cart;
        }
    }
}
