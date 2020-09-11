using System.Collections.Generic;

namespace SimplePNML
{
    /// <summary>
    /// Marks elements whose sub-elements can be collected
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
