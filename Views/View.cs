using GoldRush.Controllers;
using System.Text;

namespace GoldRush.Views
{
    public abstract class View
    {
        private readonly Input[] _inputs;

        public Input[] Inputs => (Input[]) _inputs.Clone();

        internal View(Input[] inputs)
        {
            _inputs = inputs;
        }

        public abstract void Draw(StringBuilder builder);
    }

    public abstract class View<T> : View where T : Controller<T>
    {
        protected readonly T _controller;

        protected View(T controller, params Input[] inputs) : base(inputs)
        {
            _controller = controller;
        }
    }
}
