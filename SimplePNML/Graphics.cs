using System.Xml.Serialization;

namespace SimplePNML
{
    public class Graphics
    {
        [XmlElement("position")]
        public Coordinates Position { get; set; }

        [XmlElement("offset")]
        public Coordinates Offset { get; set; }

        public static Graphics Absolute(int x, int y)
        {
            return new Graphics() { Position = new Coordinates(x, y) };
        }

        public static Graphics Relative(int x, int y)
        {
            return new Graphics() { Offset = new Coordinates(x, y) };
        }

    }
}
