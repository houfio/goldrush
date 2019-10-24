using System.Drawing;

namespace GoldRush.Models
{
    public class Cart
    {
        public bool Full { get; private set; } = true;

        public virtual Color GetColor()
        {
            return Full ? Color.Orange : Color.Yellow;
        }
    }
}
