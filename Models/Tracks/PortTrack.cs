using Pastel;
using System.Drawing;

namespace GoldRush.Models.Tracks
{
    public class PortTrack : Track
    {
        private int _capacity = 0;

        public PortTrack(Game game, Direction input, Direction output) : base(game, input, output)
        {
        }

        public override string Draw()
        {
            var character = _capacity == 0 ? base.Draw() : _capacity < 3 ? "▓" : _capacity < 6 ? "▒" : "░";

            return character.Pastel(GetColor()).PastelBg(Color.Blue);
        }

        public override Cart Update()
        {
            if (_capacity == 0 && _game.Random.Next(5) == 0)
            {
                _capacity = 8;
            }

            return base.Update();
        }

        public override void OnEnter()
        {
            if (_capacity == 0)
            {
                return;
            }

            Cart.Full = false;

            _game.Score++;

            if (_game.Random.Next(3) == 0)
            {
                _game.DecreaseInterval();
            }

            if (--_capacity == 0)
            {
                _game.Score += 10;
            }
        }
    }
}
