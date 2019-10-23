namespace GoldRush.Models
{
    public enum Direction
    {
        North,
        East,
        South,
        West
    }

    public static class DirectionExtension
    {
        public static (int x, int y) Offset(this Direction direction, (int x, int y) position)
        {
            switch (direction)
            {
                case Direction.North:
                    return (position.x - 1, position.y);
                case Direction.East:
                    return (position.x, position.y + 1);
                case Direction.South:
                    return (position.x + 1, position.y);
                case Direction.West:
                    return (position.x, position.y - 1);
            }

            return position;
        }
    }
}
