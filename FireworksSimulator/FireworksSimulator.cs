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

            Window.AllowUserResizing = true;
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            _shapesList = new List<IShape>();
            _renderTarget = new RenderTarget2D(GraphicsDevice, 800, 600, false, SurfaceFormat.Color,
                                                DepthFormat.None, 0, RenderTargetUsage.PreserveContents);

            _screen = new Screen(_renderTarget);
            _shapes = new ShapesRenderer(GraphicsDevice);
            _sprites = new SpritesRenderer(GraphicsDevice);

            _env = new FireworkEnvironment();

            _particles = new List<Particle>();
            _random = new Random();


            base.Initialize();

            GraphicsDevice.SetRenderTarget(_renderTarget);
            GraphicsDevice.Clear(new Color(20, 20, 20));
            GraphicsDevice.SetRenderTarget(null);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _fadeTexture = new Texture2D(GraphicsDevice, 1, 1);
            _fadeTexture.SetData(new[] { Color.White });

        }

        protected override void Update(GameTime gameTime)
        {
            ICustomMouse mouse = CustomMouse.Instance;
            mouse.Update();

            ICustomKeyboard keyboard = CustomKeyboard.Instance;
            keyboard.Update();


            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            if (keyboard.IsKeyClicked(Keys.Space))
            {
                Random rnd = _random;
                if (rnd == null)
                    rnd = new Random();
                _random = rnd;

                Colour colour = new Colour(
                    (byte)rnd.Next(32, 256),
                    (byte)rnd.Next(32, 256),
                    (byte)rnd.Next(32, 256)
                );

                ExplosionPattern pattern = new ExplosionPattern(-8f, 2.5f, 6.5f);

                Firework fw = new Firework(_screen.Width, _screen.Height, colour, pattern);
                _env.AddFirework(fw);

                _env.Clear();
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

            _env.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _screen.Set();
         
            _shapes.Begin();

            foreach (IShape shape in _shapesList)
            {
                _shapes.DrawShape(shape, 2.5f);
            }

            foreach (Particle particle in _particles)
            {
                _shapes.DrawShape(particle.Circle, 2f);
            }

            foreach (IFirework fw in _env.Fireworks)
            {
                if (!fw.Exploded)
                {
                    _shapes.DrawShape(fw.Launcher.Circle, 2f);
                }
                else
                {
                    foreach (IParticle p in fw.Particles)
                    {
                        _shapes.DrawShape(p.Circle, 2f);
                    }
                }
            }


            _shapes.End();

            _sprites.Begin(true);
            _sprites.Draw(_fadeTexture, new Rectangle(0, 0, _screen.Width, _screen.Height), Color.Black * 0.1f);
            _sprites.End();


            _screen.UnSet();

            _screen.Present(_sprites);
        }

    }
}
