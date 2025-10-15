using ShapeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fireworks
{
    internal class Firework : IFirework
    {
        private static Random _rng = new Random();

        private IExplosionPattern _pattern;
        private int _width;
        private int _height;

        public bool Exploded { get; private set; }
        public IParticle Launcher { get; private set; }
        public List<IParticle> Particles { get; private set; }


        public Firework(int width, int height, Colour colour, IExplosionPattern pattern)
        {
            if (pattern == null)
            {
                throw new ArgumentNullException("Explosion pattern cannot be null.");
            }

            _width = width;
            _height = height;
            _pattern = pattern;

            float x = _rng.Next(0, width);
            float y = height;
            int lifespan = _rng.Next(40, 80);

            Launcher = ParticleFactory.Create(x, y, colour, lifespan);
        }

        public Firework(int width, int height, float x, float y, Colour colour, int lifespan, IExplosionPattern pattern)
        {
            if (pattern == null)
            {
                throw new ArgumentNullException("Explosion pattern cannot be null.");
            }

            _width = width;
            _height = height;
            _pattern = pattern;

            Launcher = ParticleFactory.Create(x, y, colour, lifespan);
        }

        public void Launch()
        {
            Exploded = false;
            Particles.Clear();
        }

        public void Update()
        {
            if (!Exploded)
            {
                Launcher.Update();

                if (Launcher.Done)
                {
                    Exploded = true;
                    Particles = new List<IParticle>(_pattern.NumberOfParticles);

                    for (int i = 0; i < _pattern.NumberOfParticles; i++)
                    {
                        double angle = _rng.NextDouble() * Math.PI * 2;
                        Vector dir = new Vector((float)Math.Cos(angle), (float)Math.Sin(angle));
                        Vector vel = Launcher.Velocity + (_pattern.ExplosionVelocity * dir);
                        int life = _rng.Next(30, 60);

                        var p = ParticleFactory.Create(
                            Launcher.Position.X,
                            Launcher.Position.Y,
                            Launcher.Colour,
                            life
                        );

                        p.ApplyVelocity(vel);
                        Particles.Add(p);
                    }
                }

                return;
            }

            for (int i = Particles.Count - 1; i >= 0; i--)
            {
                Particles[i].Update();
                if (Particles[i].Done)
                    Particles.RemoveAt(i);
            }
        }





    }
}
