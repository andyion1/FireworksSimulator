using DrawingLibrary.Graphics;
using DrawingLibrary.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace DrawingLibrary.Input
{

    public class CustomMouse
    {
        private MouseState _current;
        private MouseState _previous;

        private static CustomMouse _instance;

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

        public bool IsLeftButtonDown()
        {
            return _current.LeftButton == ButtonState.Pressed;
        }

        public bool IsLeftButtonUp()
        {
            return _current.LeftButton == ButtonState.Released;
        }

        public bool IsLeftButtonClicked()
        {
            return _current.LeftButton == ButtonState.Pressed && _previous.LeftButton == ButtonState.Released;
        }

        public bool IsMiddleButtonDown()
        {
            return _current.MiddleButton == ButtonState.Pressed;
        }

        public bool IsMiddleButtonClicked()
        {
            return _current.MiddleButton == ButtonState.Pressed && _previous.MiddleButton == ButtonState.Released;
        }

        public bool IsRightButtonDown()
        {
            return _current.RightButton == ButtonState.Pressed;
        }

        public bool IsRightButtonClicked()
        {
            return _current.RightButton == ButtonState.Pressed && _previous.RightButton == ButtonState.Released;
        }

        public Vector2? GetScreenPosition(IScreen screen)
        {
            if (screen == null)
            {
                throw new System.ArgumentNullException(nameof(screen));
            }

            Rectangle targetArea = screen.CalculateDestinationRectangle();

            int mx = _current.X;
            int my = _current.Y;

            if (!targetArea.Contains(mx, my))
            {
                return null;
            }

            float offsetX = mx - targetArea.X;
            float offsetY = my - targetArea.Y;

            float scaleX = (float)screen.Width / targetArea.Width;
            float scaleY = (float)screen.Height / targetArea.Height;

            float gameResX = offsetX * scaleX;
            float gameResY = offsetY * scaleY;

            return new Vector2(gameResX, gameResY);
        }


        public void Update()
        {
            _previous = _current;
            _current = Mouse.GetState();
        }
    }
}
