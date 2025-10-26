using DrawingLibrary.Graphics;
using DrawingLibrary.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace DrawingLibrary.Input
{
    public class CustomMouse : ICustomMouse
    {
        private MouseState _current;
        private MouseState _previous;

        private static CustomMouse _instance;

        // Singleton pattern to have one global mouse handler
        public static CustomMouse Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CustomMouse();
                }
                return _instance;
            }
        }

        // current mouse position on window
        public Point WindowPosition
        {
            get
            {
                return new Point(_current.X, _current.Y);
            }
        }

        public CustomMouse()
        {
            _current = Mouse.GetState();
            _previous = _current;
        }

        // button states
        public bool IsLeftButtonDown() => _current.LeftButton == ButtonState.Pressed;
        public bool IsLeftButtonUp() => _current.LeftButton == ButtonState.Released;

        // detects a left-click (pressed this frame)
        public bool IsLeftButtonClicked()
        {
            return _current.LeftButton == ButtonState.Pressed && _previous.LeftButton == ButtonState.Released;
        }

        public bool IsMiddleButtonDown() => _current.MiddleButton == ButtonState.Pressed;

        public bool IsMiddleButtonClicked()
        {
            return _current.MiddleButton == ButtonState.Pressed && _previous.MiddleButton == ButtonState.Released;
        }

        public bool IsRightButtonDown() => _current.RightButton == ButtonState.Pressed;

        public bool IsRightButtonClicked()
        {
            return _current.RightButton == ButtonState.Pressed && _previous.RightButton == ButtonState.Released;
        }

        // converts window coordinates to screen coordinates
        public Vector2? GetScreenPosition(IScreen screen)
        {
            if (screen == null)
            {
                throw new System.ArgumentNullException(nameof(screen));
            }

            Rectangle targetArea = screen.CalculateDestinationRectangle();

            int mx = _current.X;
            int my = _current.Y;

            // ignore if mouse outside the screen area
            if (!targetArea.Contains(mx, my))
            {
                return null;
            }

            // map position to the render target scale
            float offsetX = mx - targetArea.X;
            float offsetY = my - targetArea.Y;

            float scaleX = (float)screen.Width / targetArea.Width;
            float scaleY = (float)screen.Height / targetArea.Height;

            float gameResX = offsetX * scaleX;
            float gameResY = offsetY * scaleY;

            return new Vector2(gameResX, gameResY);
        }

        // update state every frame
        public void Update()
        {
            _previous = _current;
            _current = Mouse.GetState();
        }
    }
}
