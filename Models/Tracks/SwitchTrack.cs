namespace GoldRush.Models.Tracks
{
    public class SwitchTrack : Track
    {
        private bool _switchOutput;

        public SwitchTrack(Map map, Direction input, Direction output, bool switchOutput) : base(map, input, output)
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
