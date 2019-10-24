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
            var width = map.GetLength(0);
            var height = map.GetLength(1);

            builder.AppendLine($"score: {_controller.GetScore()}");
            builder.AppendLine($"time: {_controller.GetTime()}s");
            builder.AppendLine($"┌{new string('─', width)}┐");

            for (var y = 0; y < height; y++)
            {
                builder.Append("│");

                for (var x = 0; x < width; x++)
                {
                    builder.Append($"{map[x, y]}");
                }

                builder.AppendLine("│");
            }

            var underline = new StringBuilder(new string('─', width));
            var switches = _controller.GetSwitches();

            for (var i = 0; i < switches.Length; i++)
            {
                if (switches[i] != ' ')
                {
                    underline[i] = '┬';
                }
            }

            builder.AppendLine($"└{underline}┘");
            builder.AppendLine($" {switches} ");
        }
    }

    internal class SwitchInput : Input
    {
        public SwitchInput(int number, GameController controller) : base((number + 1).ToString()[0], () => { controller.ToggleSwitch(number); })
        {
        }
    }
}
