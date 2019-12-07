using System.Collections.Generic;
using System.Linq;

namespace SimplePNML
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICollectable
    {
        IEnumerable<ICollectable> Collect();
    }
}
