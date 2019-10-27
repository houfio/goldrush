using GoldRush.Models.Tracks;
using System;
using System.Collections.Generic;

namespace GoldRush.Models
{
    public class Map
    {
        public int Width => _tracks.GetLength(0);
        public int Height => _tracks.GetLength(1);

        private readonly Track[,] _tracks = new Track[14, 8];

        public void Initialize(Game game)
        {
            _tracks[1, 0] = new DestroyTrack(game, Direction.East, Direction.West);
            _tracks[2, 0] = new Track(game, Direction.East, Direction.West);
            _tracks[3, 0] = new Track(game, Direction.East, Direction.West);
            _tracks[4, 0] = new Track(game, Direction.East, Direction.West);
            _tracks[5, 0] = new Track(game, Direction.East, Direction.West);
            _tracks[6, 0] = new Track(game, Direction.East, Direction.West);
            _tracks[7, 0] = new Track(game, Direction.East, Direction.West);
            _tracks[8, 0] = new Track(game, Direction.East, Direction.West);
            _tracks[9, 0] = new Track(game, Direction.East, Direction.West);
            _tracks[10, 0] = new PortTrack(game, Direction.East, Direction.West);
            _tracks[11, 0] = new Track(game, Direction.East, Direction.West);
            _tracks[12, 0] = new Track(game, Direction.South, Direction.West);
            _tracks[12, 1] = new Track(game, Direction.South, Direction.North);
            _tracks[12, 2] = new Track(game, Direction.South, Direction.North);
            _tracks[12, 3] = new Track(game, Direction.West, Direction.North);
            _tracks[11, 3] = new Track(game, Direction.West, Direction.East);
            _tracks[10, 3] = new SwitchTrack(game, Direction.North, Direction.East, false);
            _tracks[10, 2] = new Track(game, Direction.West, Direction.South);
            _tracks[9, 2] = new Track(game, Direction.West, Direction.East);
            _tracks[8, 2] = new Track(game, Direction.West, Direction.East);
            _tracks[7, 2] = new Track(game, Direction.West, Direction.East);
            _tracks[6, 2] = new Track(game, Direction.South, Direction.East);
            _tracks[6, 3] = new SwitchTrack(game, Direction.West, Direction.North, true);
            _tracks[5, 3] = new Track(game, Direction.West, Direction.East);
            _tracks[4, 3] = new SwitchTrack(game, Direction.North, Direction.East, false);
            _tracks[4, 2] = new Track(game, Direction.West, Direction.South);
            _tracks[3, 2] = new Track(game, Direction.West, Direction.East);
            _tracks[2, 2] = new Track(game, Direction.West, Direction.East);
            _tracks[1, 2] = new WarehouseTrack(game, Direction.East, "A");
            _tracks[4, 4] = new Track(game, Direction.West, Direction.North);
            _tracks[3, 4] = new Track(game, Direction.West, Direction.East);
            _tracks[2, 4] = new Track(game, Direction.West, Direction.East);
            _tracks[1, 4] = new WarehouseTrack(game, Direction.East, "B");
            _tracks[10, 4] = new Track(game, Direction.West, Direction.North);
            _tracks[9, 4] = new Track(game, Direction.South, Direction.East);
            _tracks[9, 5] = new SwitchTrack(game, Direction.West, Direction.North, true);
            _tracks[8, 5] = new Track(game, Direction.West, Direction.East);
            _tracks[7, 5] = new SwitchTrack(game, Direction.North, Direction.East, false);
            _tracks[7, 4] = new Track(game, Direction.West, Direction.South);
            _tracks[6, 4] = new Track(game, Direction.North, Direction.East);
            _tracks[7, 6] = new Track(game, Direction.West, Direction.North);
            _tracks[6, 6] = new Track(game, Direction.West, Direction.East);
            _tracks[5, 6] = new Track(game, Direction.West, Direction.East);
            _tracks[4, 6] = new Track(game, Direction.West, Direction.East);
            _tracks[3, 6] = new Track(game, Direction.West, Direction.East);
            _tracks[2, 6] = new Track(game, Direction.West, Direction.East);
            _tracks[1, 6] = new WarehouseTrack(game, Direction.East, "C");
            _tracks[9, 6] = new Track(game, Direction.North, Direction.East);
            _tracks[10, 6] = new Track(game, Direction.West, Direction.East);
            _tracks[11, 6] = new Track(game, Direction.West, Direction.East);
            _tracks[12, 6] = new Track(game, Direction.West, Direction.South);
            _tracks[12, 7] = new Track(game, Direction.North, Direction.West);
            _tracks[11, 7] = new Track(game, Direction.East, Direction.West);
            _tracks[10, 7] = new Track(game, Direction.East, Direction.West);
            _tracks[9, 7] = new ShuntingTrack(game, Direction.East, Direction.West);
            _tracks[8, 7] = new ShuntingTrack(game, Direction.East, Direction.West);
            _tracks[7, 7] = new ShuntingTrack(game, Direction.East, Direction.West);
            _tracks[6, 7] = new ShuntingTrack(game, Direction.East, Direction.West);
            _tracks[5, 7] = new ShuntingTrack(game, Direction.East, Direction.West);
            _tracks[4, 7] = new ShuntingTrack(game, Direction.East, Direction.West);
            _tracks[3, 7] = new ShuntingTrack(game, Direction.East, Direction.West);
            _tracks[2, 7] = new ShuntingTrack(game, Direction.East, Direction.West);
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
            bool attemptUpdate(Track track)
            {
                if (track == null || (track.Cart != null && updated.Contains(track.Cart)))
                {
                    return false;
                }

                var cart = track.Update(attemptUpdate);

                if (cart != null)
                {
                    updated.Add(cart);

                    return true;
                }

                return false;
            }

            Each((x, y, track) =>
            {
                attemptUpdate(track);
            });
        }
    }
}
