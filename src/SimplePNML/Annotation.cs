using System;
using System.Drawing;
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
        /// Gets or sets the offset
        /// </summary>
        [XmlElement("offset")]
        public Coordinates Offset { get; set; } = new Coordinates();

        /// <summary>
        /// Gets or sets the fill
        /// </summary>
        [XmlElement("fill")]
        public Fill Fill { get; set; }

        /// <summary>
        /// Gets or sets the line
        /// </summary>
        [XmlElement("line")]
        public Line Line { get; set; }

        /// <summary>
        /// Gets or sets the font
        /// </summary>
        [XmlElement("font")]
        public Font Font { get; set; }

        /// <summary>
        /// Creates a new graphical annotation
        /// </summary>
        public Annotation() { }

        /// <summary>
        /// Creates a new graphical annotation
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="fill"></param>
        /// <param name="line"></param>
        /// <param name="font"></param>
        public Annotation(int x, int y, Fill fill = null, Line line = null, Font font = null)
        {
            Offset = new Coordinates(x, y);
            Fill = fill;
            Line = line;
            Font = font;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Annotation WithOffset(int x, int y)
        {
            Offset = new Coordinates(x, y);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fill"></param>
        /// <returns></returns>
        public Annotation WithFill(Fill fill)
        {
            Fill = fill;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="color"></param>
        /// <param name="gradientColor"></param>
        /// <param name="gradientRotation"></param>
        /// <returns></returns>
        public Annotation WithFill(Color color, Color? gradientColor = null, GradientRotation? gradientRotation = null)
        {
            Fill = new Fill(color, gradientColor, gradientRotation);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public Annotation WithFill(Uri image)
        {
            Fill = new Fill(image);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public Annotation WithLine(Line line)
        {
            Line = line;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="color"></param>
        /// <param name="width"></param>
        /// <param name="shape"></param>
        /// <param name="style"></param>
        /// <returns></returns>
        public Annotation WithLine(Color color, double? width = null, LineShape? shape = null, LineStyle? style = null)
        {
            Line = new Line(color, width, shape, style);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="font"></param>
        /// <returns></returns>
        public Annotation WithFont(Font font)
        {
            Font = font;
            return this;
        }

    }
}
