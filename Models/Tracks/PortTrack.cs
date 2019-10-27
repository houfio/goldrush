using Pastel;
using System;
using System.Drawing;

namespace GoldRush.Models.Tracks
{
    public class PortTrack : Track
    {
        private int _capacity = 0;

        public PortTrack(Game game, Direction input, Direction output) : base(game, input, output)
        {
        }

        public override string GetSymbol()
        {
            var character = _capacity == 0 ? base.GetSymbol() : _capacity < 3 ? "▓" : _capacity < 6 ? "▒" : "░";

            return character.Pastel(GetColor()).PastelBg(Color.Blue);
        }

        public override Cart Update(Predicate<Track> attemptUpdate)
        {
            // When no capacity, refill at random
            if (_capacity == 0 && _game.Random.Next(5) == 0)
            {
                _capacity = 8;
            }

            return base.Update(attemptUpdate);
        }

        public override void OnEnter()
        {
            // When there's no capacity, don't empty the carts
            if (_capacity == 0)
            {
                return;
            }

            // Empty the cart
            Cart.Full = false;

            _game.Score++;

            // Increase the game difficulty at random
            if (_game.Random.Next(3) == 0)
            {
                _game.DecreaseInterval();
            }

            // When full, add 10 points
            if (--_capacity == 0)
            {
                _game.Score += 10;
            }
        }
    }
}
