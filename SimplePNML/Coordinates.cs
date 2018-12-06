using System.Xml.Serialization;

namespace SimplePNML
{
    public class Coordinates
    {
        [XmlAttribute("x")]
        public int X { get; set; }

        [XmlAttribute("y")]
        public int Y { get; set; }

        public Coordinates() { }

        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Coordinates Create(int x, int y)
        {
            return new Coordinates(x, y);
        }
    }
}
