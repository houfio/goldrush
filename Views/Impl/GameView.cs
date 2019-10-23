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
            var map = _controller.GetMap();

            for (var y = 0; y < map.GetLength(1); y++)
            {
                for (var x = 0; x < map.GetLength(0); x++)
                {
                    builder.Append(map[x, y]);
                }

                builder.AppendLine();
            }
        }
    }
}
