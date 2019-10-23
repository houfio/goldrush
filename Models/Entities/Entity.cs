namespace GoldRush.Models
{
    public abstract class Entity
    {
        public (int x, int y) Position { get; private set; }

        protected Entity(int x, int y)
        {
            Position = (x, y);
        }
    }
}
