using System.Collections.Generic;
using System.Linq;

namespace SimplePNML
{
    /// <summary>
    /// Encapsulates the functionality to recursively collect child elements
    /// </summary>
    public interface ICollectable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<ICollectable> Collect();
    }
}
