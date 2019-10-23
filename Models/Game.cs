namespace GoldRush.Models
{
    public class Game
    {
        public Map Map { get; private set; }

        public void Initialize()
        {
            var map = new Map();

            map.Initialize();

            Map = map;
        }
    }
}
