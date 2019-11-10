using System;
using System.Drawing;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Describes the graphics of a node element
    /// </summary>
    [Equals]
    [XmlType]
    public class NodeGraphics
    {
        /// <summary>
        /// Gets or sets the position
        /// </summary>
        [XmlElement("position")]
        public Coordinates Position { get; set; } = new Coordinates();

        /// <summary>
        /// Gets or sets the size
        /// </summary>
        [XmlElement("dimension")]
        public Dimension Size { get; set; }

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
        /// Creates a new graphical node
        /// </summary>
        public NodeGraphics() { }

        /// <summary>
        /// Creates a new graphical node
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="fill"></param>
        /// <param name="line"></param>
        public NodeGraphics(int x, int y, Fill fill = null, Line line = null)
        {
            Position = new Coordinates(x, y);
            Fill = fill;
            Line = line;
        }

        /// <summary>
        /// Creates a new graphical node
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="fill"></param>
        /// <param name="line"></param>
        public NodeGraphics(int x, int y, int width, int height, Fill fill = null, Line line = null)
        {
            Position = new Coordinates(x, y);
            Size = new Dimension(width, height);
        }

        /// <summary>
        /// Sets the position of the node
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>A reference to itself</returns>
        public NodeGraphics AtPosition(int x, int y)
        {
            Position = new Coordinates(x, y);
            return this;
        }

        /// <summary>
        /// Sets the size of the node
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns>A reference to itself</returns>
        public NodeGraphics OfSize(int width, int height)
        {
            Size = new Dimension(width, height);
            return this;
        }

        /// <summary>
        /// Sets the fill of the node
        /// </summary>
        /// <param name="fill">A fill description</param>
        /// <returns>A reference to itself</returns>
        public NodeGraphics WithFill(Fill fill)
        {
            Fill = fill;
            return this;
        }

        /// <summary>
        /// Sets the fill of the node
        /// </summary>
        /// <param name="color">A fill color</param>
        /// <param name="gradientColor">An optional gradient color</param>
        /// <param name="gradientRotation">An optional gradient rotation</param>
        /// <returns>A reference to itself</returns>
        public NodeGraphics WithFill(Color color, Color? gradientColor = null, GradientRotation? gradientRotation = null)
        {
            Fill = new Fill(color, gradientColor, gradientRotation);
            return this;
        }

        /// <summary>
        /// Sets the fill of the node to an image
        /// </summary>
        /// <param name="image">A fill image</param>
        /// <returns>A reference to itself</returns>
        public NodeGraphics WithFill(Uri image)
        {
            Fill = new Fill(image);
            return this;
        }

        /// <summary>
        /// Sets the line of the node
        /// </summary>
        /// <param name="line">A line description</param>
        /// <returns>A reference to itself</returns>
        public NodeGraphics WithLine(Line line)
        {
            Line = line;
            return this;
        }

        /// <summary>
        /// Sets the line of the node
        /// </summary>
        /// <param name="color">A line color</param>
        /// <param name="width">An optional line width</param>
        /// <param name="shape">An optional line shape</param>
        /// <param name="style">An optional line style</param>
        /// <returns>A reference to itself</returns>
        public NodeGraphics WithLine(Color color, double? width = null, LineShape? shape = null, LineStyle? style = null)
        {
            Line = new Line(color, width, shape, style);
            return this;
        }

    }
}
