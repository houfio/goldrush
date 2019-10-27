using Pastel;
using System;
using System.Drawing;

namespace GoldRush.Models.Tracks
{
    public class WarehouseTrack : Track
    {
        private string _number;

        public WarehouseTrack(Game game, Direction output, string number) : base(game, output, output)
        {
            _number = number;
        }

        public override string GetSymbol()
        {
            return _number.Pastel(Color.White).PastelBg(Color.Red);
        }

        public override Cart Update(Predicate<Track> attemptUpdate)
        {
            // Add a cart at random
            if (_game.Random.Next(10) != 0)
            {
                return null;
            }

            var track = Next;

            // If next track is occupied or non-existent, don't add it
            if (track == null || track.Cart != null)
            {
                return null;
            }

            track.Cart = new Cart();

            // Mark the cart as updated
            return track.Cart;
        }
    }
}
