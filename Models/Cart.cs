using System.Drawing;

namespace GoldRush.Models
{
    public class Cart
    {
        public bool Full { get; set; } = true;

        public virtual Color GetColor()
        {
            return Full ? Color.Orange : Color.Red;
        }
    }
}
