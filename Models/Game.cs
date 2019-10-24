using System;

namespace GoldRush.Models
{
    public class Game
    {
        public Map Map { get; private set; }

        private int _update;
        private int _difficulty = 10;

        public void Initialize()
        {
            var map = new Map();

            map.Initialize();

            _update = 0;
            Map = map;
        }

        public void Update()
        {
            if (Map == null || _update++ % _difficulty != 0)
            {
                return;
            }

            Map.Update();
            _difficulty = Math.Max(_difficulty - 1, 10);
        }
    }
}
