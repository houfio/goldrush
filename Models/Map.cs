using GoldRush.Models.Tracks;
using System;
using System.Collections.Generic;

namespace GoldRush.Models
{
    public class Map
    {
        public int Width => _tracks.GetLength(0);
        public int Height => _tracks.GetLength(1);
        public Random Random { get; } = new Random();

        private readonly Track[,] _tracks = new Track[13, 11];

        public void Initialize(Game game)
        {
            _tracks[0, 2] = new DestroyTrack(game, Direction.East, Direction.West);
            _tracks[1, 2] = new Track(game, Direction.East, Direction.West);
            _tracks[2, 2] = new Track(game, Direction.East, Direction.West);
            _tracks[3, 2] = new Track(game, Direction.East, Direction.West);
            _tracks[4, 2] = new Track(game, Direction.East, Direction.West);
            _tracks[5, 2] = new Track(game, Direction.East, Direction.West);
            _tracks[6, 2] = new Track(game, Direction.East, Direction.West);
            _tracks[7, 2] = new Track(game, Direction.East, Direction.West);
            _tracks[8, 2] = new Track(game, Direction.East, Direction.West);
            _tracks[9, 2] = new PortTrack(game, Direction.East, Direction.West);
            _tracks[10, 2] = new Track(game, Direction.East, Direction.West);
            _tracks[11, 2] = new Track(game, Direction.South, Direction.West);
            _tracks[11, 3] = new Track(game, Direction.South, Direction.North);
            _tracks[11, 4] = new Track(game, Direction.South, Direction.North);
            _tracks[11, 5] = new Track(game, Direction.West, Direction.North);
            _tracks[10, 5] = new Track(game, Direction.West, Direction.East);
            _tracks[9, 5] = new SwitchTrack(game, Direction.North, Direction.East, false);
            _tracks[9, 4] = new Track(game, Direction.West, Direction.South);
            _tracks[8, 4] = new Track(game, Direction.West, Direction.East);
            _tracks[7, 4] = new Track(game, Direction.West, Direction.East);
            _tracks[6, 4] = new Track(game, Direction.West, Direction.East);
            _tracks[5, 4] = new Track(game, Direction.South, Direction.East);
            _tracks[5, 5] = new SwitchTrack(game, Direction.West, Direction.North, true);
            _tracks[4, 5] = new Track(game, Direction.West, Direction.East);
            _tracks[3, 5] = new SwitchTrack(game, Direction.North, Direction.East, false);
            _tracks[3, 4] = new Track(game, Direction.West, Direction.South);
            _tracks[2, 4] = new Track(game, Direction.West, Direction.East);
            _tracks[1, 4] = new Track(game, Direction.West, Direction.East);
            _tracks[0, 4] = new WarehouseTrack(game, "A");
            _tracks[3, 6] = new Track(game, Direction.West, Direction.North);
            _tracks[2, 6] = new Track(game, Direction.West, Direction.East);
            _tracks[1, 6] = new Track(game, Direction.West, Direction.East);
            _tracks[0, 6] = new WarehouseTrack(game, "B");
            _tracks[9, 6] = new Track(game, Direction.West, Direction.North);
            _tracks[8, 6] = new Track(game, Direction.South, Direction.East);
            _tracks[8, 7] = new SwitchTrack(game, Direction.West, Direction.North, true);
            _tracks[7, 7] = new Track(game, Direction.West, Direction.East);
            _tracks[6, 7] = new SwitchTrack(game, Direction.North, Direction.East, false);
            _tracks[6, 6] = new Track(game, Direction.West, Direction.South);
            _tracks[5, 6] = new Track(game, Direction.North, Direction.East);
            _tracks[6, 8] = new Track(game, Direction.West, Direction.North);
            _tracks[5, 8] = new Track(game, Direction.West, Direction.East);
            _tracks[4, 8] = new Track(game, Direction.West, Direction.East);
            _tracks[3, 8] = new Track(game, Direction.West, Direction.East);
            _tracks[2, 8] = new Track(game, Direction.West, Direction.East);
            _tracks[1, 8] = new Track(game, Direction.West, Direction.East);
            _tracks[0, 8] = new WarehouseTrack(game, "C");
            _tracks[8, 8] = new Track(game, Direction.North, Direction.East);
            _tracks[9, 8] = new Track(game, Direction.West, Direction.East);
            _tracks[10, 8] = new Track(game, Direction.West, Direction.East);
            _tracks[11, 8] = new Track(game, Direction.West, Direction.South);
            _tracks[11, 9] = new Track(game, Direction.North, Direction.West);
            _tracks[10, 9] = new Track(game, Direction.East, Direction.West);
            _tracks[9, 9] = new Track(game, Direction.East, Direction.West);
            _tracks[8, 9] = new ShuntingTrack(game, Direction.East, Direction.West);
            _tracks[7, 9] = new ShuntingTrack(game, Direction.East, Direction.West);
            _tracks[6, 9] = new ShuntingTrack(game, Direction.East, Direction.West);
            _tracks[5, 9] = new ShuntingTrack(game, Direction.East, Direction.West);
            _tracks[4, 9] = new ShuntingTrack(game, Direction.East, Direction.West);
            _tracks[3, 9] = new ShuntingTrack(game, Direction.East, Direction.West);
            _tracks[2, 9] = new ShuntingTrack(game, Direction.East, Direction.West);
            _tracks[1, 9] = new ShuntingTrack(game, Direction.East, Direction.West);
        }

        public (int x, int y) GetPosition(Track track)
        {
            var position = (0, 0);

            Each((x, y, t) =>
            {
                if (track == t)
                {
                    position = (x, y);
                }
            });

            return position;
        }

        public Track GetTrack((int x, int y) position)
        {
            if (position.x < 0 || position.x >= Width || position.y < 0 || position.y >= Height)
            {
                return null;
            }

            return _tracks[position.x, position.y];
        }

        public void Each(Action<int, int, Track> action)
        {
            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    action(x, y, _tracks[x, y]);
                }
            }
        }

        public void Update()
        {
            var updated = new List<Cart>();

            Each((x, y, track) =>
            {
                if (track == null || (track.Cart != null && updated.Contains(track.Cart)))
                {
                    return;
                }

                var cart = track.Update();

                if (cart != null)
                {
                    updated.Add(cart);
                }
            });
        }
    }
}
