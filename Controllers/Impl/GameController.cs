﻿using GoldRush.Views;
using GoldRush.Views.Impl;
using System.Text;

namespace GoldRush.Controllers.Impl
{
    public class GameController : Controller<GameController>
    {
        public GameController(Program program) : base(program)
        {
        }

        public override void Update()
        {
            // Go to game over view when carts collided
            if (_program.Game.Over)
            {
                _program.OpenController<OverController>();
            }
        }

        public override View<GameController> CreateView()
        {
            return new GameView(this);
        }

        public string GetScore()
        {
            return _program.Game.Score.ToString();
        }

        public string GetTime()
        {
            var left = _program.Game.Interval - _program.Game.Tick;

            return (left / 10f).ToString("0.0");
        }

        public string[,] GetMap()
        {
            var map = _program.Game.Map;
            var drawn = new string[map.Width, map.Height];

            map.Each((x, y, track) =>
            {
                drawn[x, y] = track == null ? " " : track.GetSymbol();
            });

            return drawn;
        }

        public string GetActions()
        {
            var map = _program.Game.Map;
            var switches = new StringBuilder($"{new string(' ', map.Width)}");
            var count = 0;

            map.Each((x, y, track) =>
            {
                if (track != null && track.HasAction())
                {
                    switches[x] = $"{++count}"[0];
                }
            });

            return switches.ToString();
        }

        public void PerformAction(int number)
        {
            var map = _program.Game.Map;
            var current = 0;

            map.Each((x, y, track) =>
            {
                if (track == null || !track.HasAction() || current++ != number)
                {
                    return;
                }

                track.PerformAction();
            });
        }
    }
}
