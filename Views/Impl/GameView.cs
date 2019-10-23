using System.Text;
using GoldRush.Controllers.Impl;

namespace GoldRush.Views.Impl
{
    public class GameView : View<GameController>
    {
        public GameView(GameController controller) : base(controller)
        {
        }

        public override void Draw(StringBuilder builder)
        {
            builder.AppendLine("GameView");
        }
    }
}
