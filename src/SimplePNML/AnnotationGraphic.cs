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
    public class AnnotationGraphic
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
        public AnnotationGraphic() { }

        /// <summary>
        /// Creates a new graphical annotation
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="fill"></param>
        /// <param name="line"></param>
        /// <param name="font"></param>
        public AnnotationGraphic(int x, int y, Fill fill = null, Line line = null, Font font = null)
        {
            Offset = new Coordinates(x, y);
            Fill = fill;
            Line = line;
            Font = font;
        }

        /// <summary>
        /// Sets the offset of the annotation graphic
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>A reference to itself</returns>
        public AnnotationGraphic WithOffset(int x, int y)
        {
            Offset = new Coordinates(x, y);
            return this;
        }

        /// <summary>
        /// Sets the fill of the annotation graphic
        /// </summary>
        /// <param name="fill">The fill description</param>
        /// <returns>A reference to itself</returns>
        public AnnotationGraphic WithFill(Fill fill)
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
        public AnnotationGraphic WithFill(Color color, Color? gradientColor = null, GradientRotation? gradientRotation = null)
        {
            Fill = new Fill(color, gradientColor, gradientRotation);
            return this;
        }

        /// <summary>
        /// Sets the fill of the annotation graphic to an image
        /// </summary>
        /// <param name="image">The URI that points to the image</param>
        /// <returns>A reference to itself</returns>
        public AnnotationGraphic WithFill(Uri image)
        {
            Fill = new Fill(image);
            return this;
        }

        /// <summary>
        /// Sets the line of the annotation graphic
        /// </summary>
        /// <param name="line">The line description</param>
        /// <returns>A reference to itself</returns>
        public AnnotationGraphic WithLine(Line line)
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
        public AnnotationGraphic WithLine(Color color, double? width = null, LineShape? shape = null, LineStyle? style = null)
        {
            Line = new Line(color, width, shape, style);
            return this;
        }

        /// <summary>
        /// Sets the font of the annotation graphic
        /// </summary>
        /// <param name="font">The desired font</param>
        /// <returns>A reference to itself</returns>
        public AnnotationGraphic WithFont(Font font)
        {
            Font = font;
            return this;
        }

    }
}
