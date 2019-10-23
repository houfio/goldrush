using System;

namespace GoldRush.Views
{
    public class Input
    {
        public char Character { get; }
        public Action Action { get; }

        public Input(char character, Action action)
        {
            Character = character;
            Action = action;
        }
    }
}
