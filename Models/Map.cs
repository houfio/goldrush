using System.Collections.Generic;

namespace GoldRush.Models
{
    public class Map
    {
        private readonly Tile[,] _tiles = new Tile[12, 12];
        private readonly List<Entity> _entities = new List<Entity>();

        private void Initialize()
        {

        }
    }
}
