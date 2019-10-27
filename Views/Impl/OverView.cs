using System.Text;
using GoldRush.Controllers.Impl;

namespace GoldRush.Views.Impl
{
    public class OverView : View<OverController>
    {
        public OverView(OverController controller) : base(controller, new Input('s', controller.Restart), new Input('e', controller.Stop))
        {
        }

        public override void Draw(StringBuilder builder)
        {
            builder.AppendLine("game over");
            builder.AppendLine("---");
            builder.AppendLine("press s to try again or e to exit");
        }
    }
}
