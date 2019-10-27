using Pastel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace GoldRush.Models
{
    public class Track
    {
        public (int x, int y) Position => _game.Map.GetPosition(this);
        public Direction Input { get; protected set; }
        public Direction Output { get; protected set; }
        public Cart Cart { get; internal set; }

        protected readonly Game _game;
        private readonly Dictionary<(Direction, Direction), string> _symbols = new Dictionary<(Direction, Direction), string>
        {
            { (Direction.West, Direction.East), "─" },
            { (Direction.South, Direction.North), "│" },
            { (Direction.West, Direction.South), "┐" },
            { (Direction.West, Direction.North), "┘" },
            { (Direction.South, Direction.East), "┌" },
            { (Direction.North, Direction.East), "└" }
        };

        public Track(Game game, Direction input, Direction output)
        {
            _game = game;

            Input = input;
            Output = output;
        }

        public virtual string GetSymbol()
        {
            var symbol = _symbols.Keys.Where((key) => (key.Item1 == Input && key.Item2 == Output) || (key.Item1 == Output && key.Item2 == Input)).First();

            return _symbols[symbol].Pastel(GetColor());
        }

        public virtual Color GetColor()
        {
            return Cart == null ? Color.White : Cart.GetColor();
        }

        public virtual bool HasAction()
        {
            return false;
        }

        public virtual void PerformAction()
        {
        }

        public virtual Cart Update(Predicate<Track> attemptUpdate)
        {
            if (Cart == null)
            {
                return null;
            }

            var next = Output.Offset(Position);
            var track = _game.Map.GetTrack(next);

            if (track == null || track.Input != Output.Opposite())
            {
                return null;
            }

            if (track.Cart != null && !attemptUpdate(track))
            {
                if (CanCrash())
                {
                    _game.GameOver();
                }

                return null;
            }

            track.Cart = Cart;
            track.OnEnter();

            Cart = null;

            return track.Cart;
        }

        public virtual bool CanCrash()
        {
            return true;
        }

        public virtual void OnEnter()
        {
        }
    }
}
