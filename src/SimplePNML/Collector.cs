using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimplePNML
{
    internal class Collector
    {
        private IEnumerable<ICollectable> collectables;

        private Collector(ICollectable current)
        {
            collectables = Enumerable.Repeat(current, 1);
        }

        public static Collector Create(ICollectable current)
        {
            return new Collector(current);
        }

        public Collector Collect(ICollectable child)
        {
            if (child != null)
            {
                collectables = collectables.Concat(child.Collect());
            }
            return this;
        }

        public Collector Collect<T>(IEnumerable<T> children) where T : ICollectable
        {
            if (children != null)
            {
                collectables = collectables.Concat(children
                    .Where(child => child != null)
                    .SelectMany(child => child.Collect()));
            }
            return this;
        }

        public IEnumerable<ICollectable> Build()
        {
            return collectables;
        }
    }
}
