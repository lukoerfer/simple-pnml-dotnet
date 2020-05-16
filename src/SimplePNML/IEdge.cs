using System;
using System.Collections.Generic;
using System.Text;

namespace SimplePNML
{
    /// <summary>
    /// Marks the elements that have their graphics described by an edge
    /// </summary>
    public interface IEdge
    {
        EdgeGraphics Graphics { get; set; }
    }
}
