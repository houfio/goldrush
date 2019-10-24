using Pastel;
using System.Drawing;

namespace GoldRush.Models.Tracks
{
    public class WarehouseTrack : Track
    {
        private string _number;

        public WarehouseTrack(Map map, string number) : base(map, Direction.East, Direction.East)
        {
            _number = number;
        }

        public override string Draw()
        {
            return _number.Pastel(Color.White).PastelBg(Color.Red);
        }
    }
}
