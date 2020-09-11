using System.Collections.Generic;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Stores an offset in two dimensions
    /// </summary>
    [Equals(DoNotAddEqualityOperators = true)]
    [XmlType]
    public class Offset : ICollectable, IDefaultable
    {
        /// <summary>
        /// Gets or sets the offset in X direction
        /// </summary>
        [XmlAttribute("x")]
        public double X { get; set; } = 0.0;

        /// <summary>
        /// Gets or sets the offset in Y direction
        /// </summary>
        [XmlAttribute("y")]
        public double Y { get; set; } = 0.0;

        /// <summary>
        /// Creates an empty offset
        /// </summary>
        public Offset() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Offset(double x, double y)
        {
            X = x;
            Y = y;
        }

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
