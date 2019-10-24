using System;
using System.Text;
using GoldRush.Controllers.Impl;

namespace GoldRush.Views.Impl
{
    public class GameView : View<GameController>
    {
        public GameView(GameController controller) : base(controller, new SwitchInput(0, controller), new SwitchInput(1, controller), new SwitchInput(2, controller), new SwitchInput(3, controller), new SwitchInput(4, controller))
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

    internal class SwitchInput : Input
    {
        public SwitchInput(int number, GameController controller) : base((number + 1).ToString()[0], () => { controller.ToggleSwitch(number); })
        {
        }
    }
}
