using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeLibrary;
using Fireworks;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("FireworksTests")]
[assembly: InternalsVisibleTo("FireworksSimulator")]

namespace Fireworks;
internal class Particle : IParticle
{
    private int _lifespan;
    private bool _done;

    public Vector Acceleration { get; private set; }
    public Vector Velocity { get; private set;  }
    public Vector Position { get; private set;  }
    public ICircle Circle { get; private set;  }
    public Colour Colour { get; private set;  }
    public bool Done => _done;


public Particle(float x, float y, Colour colour, int lifespan)
    {
        Position = new Vector(x, y);
        Colour = colour;
        _lifespan = lifespan;


        Circle = new Circle(x, y, 2f, colour);

        Acceleration = new Vector(0, 0);
        Velocity = new Vector(0, 0);
    }

    public void ApplyGravity()
    {
        Acceleration += new Vector(0, 0.1f);
    }

    public void ApplyVelocity(Vector velocity)
    {
        Velocity += velocity;
    }

    public void Update()
    {
        if (_done)
        {
            return;
        }

        Velocity += Acceleration;
        Position += Velocity;

        _lifespan--;

        if (_lifespan <= 0)
        {
            _done = true;
            return;
        }

        Acceleration = new Vector(0, 0);
        Circle = new Circle(Position.X, Position.Y, 2f, Colour);
    }
}
