using Pastel;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace GoldRush.Models
{
    public class Track
    {
        public (int x, int y) Position => _map.GetPosition(this);
        public Direction Input { get; protected set; }
        public Direction Output { get; protected set; }
        public Cart Cart { get; protected set; }

        private readonly Map _map;
        private readonly Dictionary<(Direction, Direction), string> _symbols = new Dictionary<(Direction, Direction), string>
        {
            { (Direction.West, Direction.East), "─" },
            { (Direction.South, Direction.North), "│" },
            { (Direction.West, Direction.South), "┐" },
            { (Direction.West, Direction.North), "┘" },
            { (Direction.South, Direction.East), "┌" },
            { (Direction.North, Direction.East), "└" }
        };

        public Track(Map map, Direction input, Direction output)
        {
            _map = map;

            Input = input;
            Output = output;
        }

        public virtual string Draw()
        {
            var symbol = _symbols.Keys.Where((key) => (key.Item1 == Input && key.Item2 == Output) || (key.Item1 == Output && key.Item2 == Input)).First();

            return _symbols[symbol].Pastel(GetColor());
        }

        public virtual Color GetColor()
        {
            return Cart == null ? Color.White : Color.Red;
        }

        public virtual bool HasAction()
        {
            return false;
        }

        public virtual void PerformAction()
        {
        }

        public virtual void Update()
        {
            if (Cart == null)
            {
                return;
            }

            var next = Output.Offset(Position);
            var track = _map.GetTrack(next);

            if (track.Input != Output.Opposite())
            {
                return;
            }

            if (track.Cart != null)
            {
                if (!CanCrash())
                {
                    return;
                }

                // gane over
            }

            track.Cart = Cart;
            Cart = null;
        }

        public virtual bool CanCrash()
        {
            return true;
        }
    }
}
