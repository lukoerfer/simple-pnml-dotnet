using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Describes the graphics of an annotation element
    /// </summary>
    [Equals]
    [XmlType]
    public class Annotation
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("offset")]
        public Coordinates Offset { get; set; } = new Coordinates();

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("fill")]
        public Fill Fill { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("line")]
        public Line Line { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("font")]
        public Font Font { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Annotation() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Annotation(int x, int y, Fill fill = null, Line line = null, Font font = null)
        {
            Offset = new Coordinates(x, y);
            Fill = fill;
            Line = line;
            Font = font;
        }

    }
}
