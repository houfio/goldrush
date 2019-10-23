using GoldRush.Views;
using GoldRush.Views.Impl;

namespace GoldRush.Controllers.Impl
{
    public class GameController : Controller<GameController>
    {
        public GameController(Program program) : base(program)
        {
        }

        public override void Update()
        {
        }

        public override View<GameController> CreateView()
        {
            return new GameView(this);
        }

        public string[,] GetMap()
        {
            var map = _program.Game.Map;
            var drawn = new string[map.Width, map.Height];

            for (var x = 0; x < map.Width; x++)
            {
                for (var y = 0; y < map.Height; y++)
                {
                    var track = map.GetTrack((x, y));

                    drawn[x, y] = track == null ? " " : track.Draw();
                }
            }

            return drawn;
        }
    }
}
