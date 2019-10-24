using GoldRush.Controllers.Impl;
using Pastel;
using System.Drawing;
using System.Text;

namespace GoldRush.Views.Impl
{
    public class StartView : View<StartController>
    {
        private readonly string[] _header = {
            @"  /$$$$$$            /$$       /$$ /$$$$$$$                      /$$      ",
            @" /$$__  $$          | $$      | $$| $$__  $$                    | $$      ",
            @"| $$  \__/  /$$$$$$ | $$  /$$$$$$$| $$  \ $$ /$$   /$$  /$$$$$$$| $$$$$$$ ",
            @"| $$ /$$$$ /$$__  $$| $$ /$$__  $$| $$$$$$$/| $$  | $$ /$$_____/| $$__  $$",
            @"| $$|_  $$| $$  \ $$| $$| $$  | $$| $$__  $$| $$  | $$|  $$$$$$ | $$  \ $$",
            @"| $$  \ $$| $$  | $$| $$| $$  | $$| $$  \ $$| $$  | $$ \____  $$| $$  | $$",
            @"|  $$$$$$/|  $$$$$$/| $$|  $$$$$$$| $$  | $$|  $$$$$$/ /$$$$$$$/| $$  | $$",
            @" \______/  \______/ |__/ \_______/|__/  |__/ \______/ |_______/ |__/  |__/"
        };

        public StartView(StartController controller) : base(controller, new Input('s', controller.Start))
        {
        }

        public override void Draw(StringBuilder builder)
        {
            for (var i = 0; i < _header.Length; i++)
            {
                var line = _header[i];
                var length = line.Length;

                for (var j = 0; j < length; j++)
                {
                    var character = line[j].ToString();
                    var current = length - j;
                    var update = _controller.Tick - i;
                    var color = current == update || current == update + 1 || current == update + 2;

                    builder.Append(character.Pastel(color ? Color.LightYellow : Color.Gold));
                }

                builder.Append("\n");
            }

            builder.AppendLine("press s to start");
        }
    }
}
