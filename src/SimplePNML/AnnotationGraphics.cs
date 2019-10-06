using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// 
    /// </summary>
    [XmlType]
    [Equals]
    public class AnnotationGraphics
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
        public AnnotationGraphics() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public AnnotationGraphics(int x, int y)
        {
            Offset = new Coordinates(x, y);
        }
    }
}
