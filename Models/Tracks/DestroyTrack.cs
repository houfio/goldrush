using System;

namespace GoldRush.Models.Tracks
{
    public class DestroyTrack : Track
    {
        public DestroyTrack(Game game, Direction input, Direction output) : base(game, input, output)
        {
        }

        public override Cart Update(Predicate<Track> attemptUpdate)
        {
            Cart = null;

            return null;
        }
    }
}
