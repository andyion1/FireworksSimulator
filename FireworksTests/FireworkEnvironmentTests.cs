using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fireworks;
using ShapeLibrary;

namespace FireworksTests
{
    [TestClass]
    public sealed class FireworkEnvironmentTests
    {
        private int DefaultWidth = 800;
        private int DefaultHeight = 600;
        private Colour DefaultColour = new Colour(255, 128, 0);

        private IExplosionPattern CreateDefaultPattern()
        {
            return new ExplosionPattern(-8f, 2.5f, 6.5f);
        }
    }
}
