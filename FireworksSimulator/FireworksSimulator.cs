using DrawingLibrary.Graphics;
using DrawingLibrary.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShapeLibrary;
using System.Collections.Generic;

namespace FireworksSimulator
{
    public class FireworksSimulator : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private RenderTarget2D _renderTarget;
        private IScreen _screen;
        private IShapesRenderer _shapes;
        private ISpritesRenderer _sprites;
        private List<IShape> _shapesList;

        public FireworksSimulator()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _shapesList = new List<IShape>();
            _renderTarget = new RenderTarget2D(GraphicsDevice, 800, 600);
            _screen = new Screen(_renderTarget);
            _shapes = new ShapesRenderer(GraphicsDevice);
            _sprites = new SpritesRenderer(GraphicsDevice);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            ICustomMouse mouse = CustomMouse.Instance;
            mouse.Update();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            if (mouse.IsLeftButtonClicked())
            {
                Vector2? position = mouse.GetScreenPosition(_screen);
                if (position.HasValue)
                {
                    _shapesList.Add(
                        ShapesFactory.CreateCircle(position.Value.X, position.Value.Y, 25f,
                        new Colour(255, 128, 0))); // orange
                }
            }

            if (mouse.IsRightButtonClicked())
            {
                Vector2? position = mouse.GetScreenPosition(_screen);
                if (position.HasValue)
                {
                    _shapesList.Add(
                        ShapesFactory.CreateRectangle(position.Value.X, position.Value.Y, 64f, 40f,
                        new Colour(0, 128, 255))); // blue
                }
            }

            if (mouse.IsMiddleButtonClicked())
            {
                _shapesList.Clear();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _screen.Set();

            GraphicsDevice.Clear(Color.CornflowerBlue);

            _shapes.Begin();
            foreach (IShape shape in _shapesList)
            {
                _shapes.DrawShape(shape, 2.5f);
            }
            _shapes.End();
            _screen.UnSet();

            _screen.Present(_sprites);
        }
    }
}
