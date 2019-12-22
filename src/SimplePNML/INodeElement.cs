using System;
using System.Collections.Generic;
using System.Text;

namespace SimplePNML
{
    /// <summary>
    /// Marks the elements that have their graphics described by a node
    /// </summary>
    public interface INodeElement
    {
        Node Graphics { get; set; }
    }
}
