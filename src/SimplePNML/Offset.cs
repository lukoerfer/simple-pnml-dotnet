using System.Collections.Generic;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Stores an offset in two dimensions
    /// </summary>
    [Equals]
    [XmlType]
    public class Offset : ICollectable, IDefaults
    {
        /// <summary>
        /// Gets or sets the offset in X direction
        /// </summary>
        [XmlAttribute("x")]
        public double X { get; set; }

        /// <summary>
        /// Gets or sets the offset in Y direction
        /// </summary>
        [XmlAttribute("y")]
        public double Y { get; set; }

        /// <summary>
        /// Creates an empty offset
        /// </summary>
        public Offset() { }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ICollectable> Collect()
        {
            yield return this;
        }

        public bool IsDefault() => X == 0.0 && Y == 0.0;
    }
}
