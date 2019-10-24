using System;

namespace GoldRush.Models
{
    public class Game
    {
        public Map Map { get; private set; }
        public int Difficulty { get; private set; }

        private int _update;

        public void Initialize()
        {
            var map = new Map();

            map.Initialize(this);

            _update = Difficulty = 40;
            Map = map;
        }

        public void Update()
        {
            if (Map == null || _update++ % Difficulty != 0)
            {
                return;
            }

            Map.Update();
        }

        public void IncreaseDifficulty()
        {
            Difficulty = Math.Max(Difficulty - 2, 5);
        }
    }
}
