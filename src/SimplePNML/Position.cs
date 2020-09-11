using System.Collections.Generic;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Stores a position in two dimensions
    /// </summary>
    [Equals(DoNotAddEqualityOperators = true)]
    [XmlType]
    public class Position : ICollectable, IDefaultable
    {
        /// <summary>
        /// Gets or sets the position in X direction
        /// </summary>
        [XmlAttribute("x")]
        public double X { get; set; } = 0.0;

        /// <summary>
        /// Gets or sets the position in Y direction
        /// </summary>
        [XmlAttribute("y")]
        public double Y { get; set; } = 0.0;

        /// <summary>
        /// Creates an empty set of coordinates
        /// </summary>
        public Position() { }

        /// <summary>
        /// Creates a new set of coordinates
        /// </summary>
        /// <param name="x">The position in X direction</param>
        /// <param name="y">The position in Y direction</param>
        public Position(double x, double y)
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

        public bool IsDefault()
        {
            return X == 0.0
                && Y == 0.0;
        }
    }
}
