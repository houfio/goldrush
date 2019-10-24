namespace GoldRush.Models.Tracks
{
    public class SwitchTrack : Track
    {
        private bool _switchOutput;

        public SwitchTrack(Game game, Direction input, Direction output, bool switchOutput) : base(game, input, output)
        {
            _switchOutput = switchOutput;
        }

        public override bool HasAction()
        {
            return true;
        }

        public override void PerformAction()
        {
            if (Cart != null)
            {
                return;
            }

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
