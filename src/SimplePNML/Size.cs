using System.Collections.Generic;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Describes dimension information (size) of a graphical element
    /// </summary>
    [Equals]
    [XmlType]
    public class Size : ICollectable, IDefaults
    {
        /// <summary>
        /// Gets or sets the length in X direction
        /// </summary>
        [XmlAttribute("x")]
        public double Width { get; set; }

        /// <summary>
        /// Gets or sets the length in Y direction
        /// </summary>
        [XmlAttribute("y")]
        public double Height { get; set; }

        /// <summary>
        /// Creates an empty dimension information
        /// </summary>
        public Size() { }

        /// <summary>
        /// Creates a new dimension information
        /// </summary>
        /// <param name="width">The length in X direction</param>
        /// <param name="height">The length in Y direction</param>
        public Size(double width, double height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ICollectable> Collect()
        {
            yield return this;
        }

        public bool IsDefault() => Width == 0.0 && Height == 0.0;
    }
}
