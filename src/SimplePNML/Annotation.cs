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
        /// <param name="x">The offset in X direction</param>
        /// <param name="y">The offset in Y direction</param>
        /// <param name="fill">An optional fill</param>
        /// <param name="line">An optional line</param>
        /// <param name="font">An optional font</param>
        public Annotation(double x, double y, Fill fill = null, Line line = null, Font font = null)
        {
            Offset = new Coordinates(x, y);
            Fill = fill;
            Line = line;
            Font = font;
        }

        /// <summary>
        /// Sets the offset of the annotation graphic
        /// </summary>
        /// <param name="x">The offset in X direction</param>
        /// <param name="y">The offset in Y direction</param>
        /// <returns>A reference to itself</returns>
        public Annotation WithOffset(double x, double y)
        {
            Offset = new Coordinates(x, y);
            return this;
        }

        /// <summary>
        /// Sets the fill of the annotation graphic
        /// </summary>
        /// <param name="fill">The fill description</param>
        /// <returns>A reference to itself</returns>
        public Annotation WithFill(Fill fill)
        {
            Fill = fill;
            return this;
        }

        /// <summary>
        /// Sets the fill of the annotation graphic
        /// </summary>
        /// <param name="color">The fill color</param>
        /// <param name="gradientColor">An optional gradient color</param>
        /// <param name="gradientRotation">An optional gradient rotation</param>
        /// <returns>A reference to itself</returns>
        public Annotation WithFill(Color color, Color? gradientColor = null, GradientRotation? gradientRotation = null)
        {
            Fill = new Fill(color, gradientColor, gradientRotation);
            return this;
        }

        /// <summary>
        /// Sets the fill of the annotation graphic to an image
        /// </summary>
        /// <param name="image">The URI that points to the image</param>
        /// <returns>A reference to itself</returns>
        public Annotation WithFill(Uri image)
        {
            Fill = new Fill(image);
            return this;
        }

        /// <summary>
        /// Sets the line of the annotation graphic
        /// </summary>
        /// <param name="line">The line description</param>
        /// <returns>A reference to itself</returns>
        public Annotation WithLine(Line line)
        {
            Line = line;
            return this;
        }

        /// <summary>
        /// Sets the line of the annotation graphic
        /// </summary>
        /// <param name="color">The line color</param>
        /// <param name="width">An optional line width</param>
        /// <param name="shape">An optional line shape</param>
        /// <param name="style">An optional line style</param>
        /// <returns>A reference to itself</returns>
        public Annotation WithLine(Color color, double? width = null, LineShape? shape = null, LineStyle? style = null)
        {
            Line = new Line(color, width, shape, style);
            return this;
        }

        /// <summary>
        /// Sets the font of the annotation graphic
        /// </summary>
        /// <param name="font">The desired font</param>
        /// <returns>A reference to itself</returns>
        public Annotation WithFont(Font font)
        {
            Font = font;
            return this;
        }

    }
}
