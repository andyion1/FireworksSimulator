using System;
using System.Collections.Generic;
using DrawingLibrary.Graphics;
using DrawingLibrary.Input;
using Fireworks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShapeLibrary;

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

        private List<Particle> _particles;
        private Random _random;

        private FireworkEnvironment _env;
        private Texture2D _fadeTexture;

        public FireworksSimulator()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _shapesList = new List<IShape>();
            _renderTarget = new RenderTarget2D(GraphicsDevice, 800, 600, false, SurfaceFormat.Color,
                                                DepthFormat.None, 0, RenderTargetUsage.PreserveContents);

            _screen = new Screen(_renderTarget);
            _shapes = new ShapesRenderer(GraphicsDevice);
            _sprites = new SpritesRenderer(GraphicsDevice);

            _particles = new List<Particle>();
            _random = new Random();


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
                    float x = position.Value.X;
                    float y = position.Value.Y;

                    float vx = (float)(_random.NextDouble() * 20 - 10);
                    float vy = (float)(_random.NextDouble() * 20 - 10);

                    Colour colour = new Colour(255, 128, 0); // orange
                    int lifespan = 60;

                    Particle particle = new Particle(x, y, colour, lifespan);
                    particle.ApplyVelocity(new Vector(vx, vy));

                    _particles.Add(particle);
                }
            }

            foreach (Particle particle in _particles)
            {
                particle.ApplyGravity();
                particle.Update();
            }

            // remove expired ones
            _particles.RemoveAll(p => p.Done);


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

            foreach (Particle particle in _particles)
            {
                _shapes.DrawShape(particle.Circle, 2f);
            }

            _shapes.End();
            _screen.UnSet();

            _screen.Present(_sprites);
        }

    }
}
