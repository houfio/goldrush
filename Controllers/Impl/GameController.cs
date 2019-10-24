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

        public string GetTime()
        {
            var left = _program.Game.Interval - _program.Game.Tick;

            return (left / 10f).ToString("0.0");
        }

        public string[,] GetMap()
        {
            var map = _program.Game.Map;
            var drawn = new string[map.Width, map.Height];

            map.Each((x, y, track) =>
            {
                drawn[x, y] = track == null ? " " : track.Draw();
            });

            return drawn;
        }

        public void ToggleSwitch(int number)
        {
            var map = _program.Game.Map;
            var current = 0;

            map.Each((x, y, track) =>
            {
                if (track == null || !track.HasAction() || current++ != number)
                {
                    return;
                }

                track.PerformAction();
            });
        }
    }
}
