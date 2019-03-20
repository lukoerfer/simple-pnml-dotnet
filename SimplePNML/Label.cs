using System.Xml.Serialization;

namespace SimplePNML
{
    public class Label
    {
        [XmlElement("text")]
        public string Text { get; set; }

        [XmlElement("graphics")]
        public Graphics Graphics { get; set; }

        public static Label Absolute(int x, int y, string text)
        {
            return new Label()
            {
                Text = text,
                Graphics = Graphics.Absolute(x, y)
            };
        }

        public static Label Relative(int x, int y, string text)
        {
            return new Label()
            {
                Text = text,
                Graphics = Graphics.Relative(x, y)
            };
        }

    }
}
