using GoldRush.Views;
using GoldRush.Views.Impl;

namespace GoldRush.Controllers.Impl
{
    public class OverController : Controller<OverController>
    {
        public OverController(Program program) : base(program)
        {
        }

        public override void Update()
        {
        }

        public override View<OverController> CreateView()
        {
            return new OverView(this);
        }

        public void Restart()
        {
            _program.Game.Initialize();
            _program.OpenController<GameController>();
        }
    }
}
