using GoldRush.Views;
using GoldRush.Views.Impl;

namespace GoldRush.Controllers.Impl
{
    public class StartController : Controller<StartController>
    {
        public int Tick { get; private set; }

        public StartController(Program program) : base(program)
        {
        }

        public override void Update()
        {
            Tick = (Tick + 5) % 100;
        }

        public override View<StartController> CreateView()
        {
            return new StartView(this);
        }

        public void Start()
        {
            _program.Game.Initialize();
            _program.OpenController<GameController>();
        }
    }
}
