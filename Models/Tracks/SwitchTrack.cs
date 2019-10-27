using Pastel;
using System.Drawing;

namespace GoldRush.Models.Tracks
{
    public class SwitchTrack : Track
    {
        private bool _switchOutput;

        public SwitchTrack(Game game, Direction input, Direction output, bool switchOutput) : base(game, input, output)
        {
            _switchOutput = switchOutput;
        }

        public override string GetSymbol() => base.GetSymbol().PastelBg(Color.Gray);

        public override bool HasAction()
        {
            // This track has a special action!
            return true;
        }

        public override void PerformAction()
        {
            // Can't switch when a cart is on the track
            if (Cart != null)
            {
                return;
            }

            // Switch the correct direction
            if (_switchOutput)
            {
                Output = Output.Opposite();
            }
            else
            {
                Input = Input.Opposite();
            }
        }
    }
}
