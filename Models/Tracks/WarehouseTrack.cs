using Pastel;
using System;
using System.Drawing;

namespace GoldRush.Models.Tracks
{
    public class WarehouseTrack : Track
    {
        private readonly Random _random = new Random();
        private string _number;

        public WarehouseTrack(Map map, string number) : base(map, Direction.East, Direction.East)
        {
            _number = number;
        }

        public override string Draw()
        {
            return _number.Pastel(Color.White).PastelBg(Color.Red);
        }

        public override Cart Update()
        {
            if (_random.Next(8) != 0)
            {
                return null;
            }

            var position = Output.Offset(Position);
            var track = _map.GetTrack(position);

            if (track == null || (track.Cart != null && track.CanCrash()))
            {
                // game over

                return null;
            }

            track.Cart = new Cart();

            return null;
        }
    }
}
