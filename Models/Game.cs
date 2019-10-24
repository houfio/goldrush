using System;

namespace GoldRush.Models
{
    public class Game
    {
        public bool Over { get; private set; }
        public Map Map { get; private set; }
        public int Score { get; set; }
        public int Interval { get; private set; }
        public int Tick { get; private set; }
        public Random Random { get; } = new Random();

        public void Initialize()
        {
            var map = new Map();

            map.Initialize(this);

            Over = false;
            Map = map;
            Score = 0;
            Interval = 25;
            Tick = 0;
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

        public void GameOver()
        {
            Over = true;
        }
    }
}
