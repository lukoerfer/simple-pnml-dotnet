using System;
using System.Collections.Generic;
using System.Text;

namespace SimplePNML
{
    /// <summary>
    /// Marks elements that are graphically represented by an edge
    /// </summary>
    public interface IEdge
    {
        EdgeGraphics Graphics { get; set; }
    }
}
