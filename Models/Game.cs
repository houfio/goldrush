using System;

namespace GoldRush.Models
{
    public class Game
    {
        public Map Map { get; private set; }
        public int Score { get; set; }
        public int Interval { get; private set; }
        public int Tick { get; private set; }
        public Random Random { get; } = new Random();

        public void Initialize()
        {
            var map = new Map();

            map.Initialize(this);

            Score = 0;
            Tick = 0;
            Interval = 25;
            Map = map;
        }

        public void Update()
        {
            if (Map == null || ++Tick != Interval)
            {
                return;
            }

            Map.Update();
            Tick = 0;
        }

        public void DecreaseInterval()
        {
            Interval = Math.Max(Interval - 1, 1);
        }
    }
}
