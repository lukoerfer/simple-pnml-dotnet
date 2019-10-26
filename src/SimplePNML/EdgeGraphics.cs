using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// 
    /// </summary>
    [Equals]
    [XmlType]
    public class EdgeGraphics
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("position")]
        public List<Coordinates> Position { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("line")]
        public Line Line { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EdgeGraphics() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="positions"></param>
        public EdgeGraphics(params Coordinates[] positions)
        {
            Position = positions.ToList();
        }
    }
}
