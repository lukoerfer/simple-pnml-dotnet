using System.Collections.Generic;
using System.Linq;

namespace SimplePNML
{
    /// <summary>
    /// Encapsulates the functionality to recursively collect all child entities
    /// </summary>
    public interface ICollectable
    {
        IEnumerable<ICollectable> Collect();
    }
}
