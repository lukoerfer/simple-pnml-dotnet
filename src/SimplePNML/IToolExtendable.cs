using System.Collections.Generic;

namespace SimplePNML
{
    /// <summary>
    /// Marks elements that can be extended with tool-specific elements
    /// </summary>
    public interface IToolExtendable
    {
        /// <summary>
        /// 
        /// </summary>
        List<ToolSpecific> ToolSpecifics { get; set; }
    }
}
