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

        public void AddFirework(IFirework f)
        {
            if (f == null)
                throw new ArgumentNullException(nameof(f));

            f.Launch();
            _fireworks.Add(f);
        }

        public void Update()
        {
            for (int i = _fireworks.Count - 1; i >= 0; i--)
            {
                _fireworks[i].Update();

                if (_fireworks[i].Exploded && _fireworks[i].Particles.Count == 0)
                {
                    _fireworks.RemoveAt(i);
                }
            }
        }
        public void Clear()
        {
            if (_fireworks.Count > 50)
            {
                _fireworks.Clear();
            }
        }
    }
}
