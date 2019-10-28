using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// 
    /// </summary>
    public enum GradientRotation
    {
        [XmlEnum("vertical")]
        Vertical,
        [XmlEnum("horizontal")]
        Horizontal,
        [XmlEnum("diagonal")]
        Diagonal
    }
}
