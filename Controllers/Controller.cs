using GoldRush.Views;

namespace GoldRush.Controllers
{
    public abstract class Controller
    {
        protected readonly Program _program;

        internal Controller(Program program)
        {
            _program = program;
        }

        public abstract void Update();
    }

    public abstract class Controller<T> : Controller where T : Controller<T>
    {
        protected Controller(Program program) : base(program)
        {
        }

        public abstract View<T> CreateView();
    }
}
