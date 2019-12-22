using System;
using System.Collections.Generic;
using System.Text;

namespace SimplePNML
{
    /// <summary>
    /// Marks the elements that have a graphical line
    /// </summary>
    public interface ILined
    {
        Line Line { get; set; }
    }
}
