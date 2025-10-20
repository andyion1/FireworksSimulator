using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fireworks
{
    internal class FireworkEnvironment
    {
        private readonly List<IFirework> _fireworks;

        public FireworkEnvironment()
        {
            _fireworks = new List<IFirework>();
        }
    }
}
