using System;
using System.Collections.Generic;

namespace Fireworks
{
    internal class FireworkEnvironment
    {
        private readonly List<IFirework> _fireworks;

        public FireworkEnvironment()
        {
            _fireworks = new List<IFirework>();
        }

        public List<IFirework> Fireworks => _fireworks;

        // add and launch a new firework into the environment
        public void AddFirework(IFirework f)
        {
            if (f == null)
                throw new ArgumentNullException(nameof(f));

            f.Launch();
            _fireworks.Add(f);
        }

        // update all fireworks each frame
        public void Update()
        {
            for (int i = _fireworks.Count - 1; i >= 0; i--)
            {
                _fireworks[i].Update();

                // remove finished fireworks
                if (_fireworks[i].Exploded && _fireworks[i].Particles.Count == 0)
                {
                    _fireworks.RemoveAt(i);
                }
            }
        }

        // clears environment if it gets too crowded
        public void Clear()
        {
            if (_fireworks.Count > 50)
            {
                _fireworks.Clear();
            }
        }
    }
}
