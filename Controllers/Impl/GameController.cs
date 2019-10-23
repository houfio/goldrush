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
    }
}
