using System.Drawing;

namespace GoldRush.Models.Tracks
{
    public class ShuntingTrack : Track
    {
        public ShuntingTrack(Map map, Direction input, Direction output) : base(map, input, output)
        {
        }

        public override Color GetColor()
        {
            return Cart == null ? Color.Green : Color.GreenYellow;
        }

        public override bool CanCrash()
        {
            return false;
        }
    }
}
