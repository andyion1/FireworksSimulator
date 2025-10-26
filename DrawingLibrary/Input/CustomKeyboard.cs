using Microsoft.Xna.Framework.Input;
using DrawingLibrary.Graphics;
using DrawingLibrary.Input;

namespace DrawingLibrary.Input
{
    public class CustomKeyboard : ICustomKeyboard
    {
        private KeyboardState _current;
        private KeyboardState _previous;

        private static CustomKeyboard _instance;

        // Singleton instance so we only ever use one keyboard object
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

        // must be called once per frame to refresh state
        public void Update()
        {
            _previous = _current;
            _current = Keyboard.GetState();
        }

        // check if a key is being held down
        public bool IsKeyDown(Keys key)
        {
            return _current.IsKeyDown(key);
        }

        // check if a key was pressed once (not held)
        public bool IsKeyClicked(Keys key)
        {
            return _current.IsKeyDown(key) && _previous.IsKeyUp(key);
        }
    }
}
