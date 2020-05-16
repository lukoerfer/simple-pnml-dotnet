using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Describes a graphical line element
    /// </summary>
    [Equals]
    [XmlType]
    public class Line : ICollectable, IDefaults
    {
        /// <summary>
        /// Gets or sets the color
        /// </summary>
        [XmlAttribute("color")]
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets the width
        /// </summary>
        [XmlAttribute("width")]
        public double Width { get; set; }

        /// <summary>
        /// Gets or sets the shape
        /// </summary>
        [XmlAttribute("shape")]
        public LineShape Shape { get; set; }

        /// <summary>
        /// Gets or sets the style
        /// </summary>
        [XmlAttribute("style")]
        public LineStyle Style { get; set; }

        

        /// <summary>
        /// Creates a new line
        /// </summary>
        public Line() { }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ICollectable> Collect()
        {
            yield return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsDefault() => Shape.IsDefault();
    }
}
