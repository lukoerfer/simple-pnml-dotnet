using System.Collections.Generic;
using System.Linq;

namespace SimplePNML
{
    internal class Collector
    {
        private IEnumerable<ICollectable> collectables;

        public Collector(ICollectable parent)
        {
            collectables = Enumerable.Repeat(parent, 1);
        }

        public Collector Include(ICollectable child)
        {
            collectables = collectables.Concat(child.Collect());
            return this;
        }

        public Collector Include<T>(IEnumerable<T> children) where T : ICollectable
        {
            collectables = collectables.Concat(children
                .Where(child => child != null)
                .SelectMany(child => child.Collect()));
            return this;
        }

        public IEnumerable<ICollectable> Collect()
        {
            return collectables;
        }
    }
}
