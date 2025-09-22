
using Microsoft.Xna.Framework.Input;

namespace DrawingLib.Input
{
    public class CustomKeyboard : ICustomKeyboard
    {

        private KeyboardState _current;
        private KeyboardState _previous;

        private static CustomKeyboard _instance;

        public static CustomKeyboard Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CustomKeyboard();
                }
                return _instance;
            }
        }


        public CustomKeyboard()
        {
            _current = Keyboard.GetState();
            _previous = _current;
        }

        public void Update()
        {
            _previous = _current;
            _current = Keyboard.GetState();
        }

        public bool IsKeyDown(Keys key)
        {
            return _current.IsKeyDown(key);
        }

        public bool IsKeyClicked(Keys key)
        {
            return _current.IsKeyDown(key) && _previous.IsKeyUp(key);
        }
    }
}