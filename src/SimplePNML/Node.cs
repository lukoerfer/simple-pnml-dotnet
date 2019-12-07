using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Describes the graphics of a node element
    /// </summary>
    [Equals]
    [XmlType]
    public class Node : ICollectable, IFilled, ILined
    {
        /// <summary>
        /// Gets or sets the position
        /// </summary>
        [NotNull]
        [XmlElement("position")]
        public Position Position { get; set; } = new Position();

        /// <summary>
        /// Gets or sets the size
        /// </summary>
        [XmlElement("dimension")]
        public Size Size { get; set; }

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
        public Node() { }

        /// <summary>
        /// Creates a new graphical node
        /// </summary>
        /// <param name="x">The position in X direction</param>
        /// <param name="y">The position in Y direction</param>
        /// <param name="fill">An optional fill descriptioon</param>
        /// <param name="line">An optional line description</param>
        public Node(double x, double y, Fill fill = null, Line line = null)
        {
            Position = new Position(x, y);
            Fill = fill;
            Line = line;
        }

        /// <summary>
        /// Creates a new graphical node
        /// </summary>
        /// <param name="x">The position in X direction</param>
        /// <param name="y">The position in Y direction</param>
        /// <param name="width">The length in X direction</param>
        /// <param name="height">The length in Y direction</param>
        /// <param name="fill">An optional fill description</param>
        /// <param name="line">An optional line description</param>
        public Node(double x, double y, double width, double height, Fill fill = null, Line line = null)
        {
            Position = new Position(x, y);
            Size = new Size(width, height);
            Fill = fill;
            Line = line;
        }

        /// <summary>
        /// Sets the position of the node
        /// </summary>
        /// <param name="x">The position in X direction</param>
        /// <param name="y">The position in Y direction</param>
        /// <returns>A reference to itself</returns>
        public Node AtPosition(int x, int y)
        {
            Position = new Position(x, y);
            return this;
        }

        /// <summary>
        /// Sets the size of the node
        /// </summary>
        /// <param name="width">The length in X direction</param>
        /// <param name="height">The length in Y direction</param>
        /// <returns>A reference to itself</returns>
        public Node OfSize(int width, int height)
        {
            Size = new Size(width, height);
            return this;
        }

        /// <summary>
        /// Sets the fill of the node
        /// </summary>
        /// <param name="fill">A fill description</param>
        /// <returns>A reference to itself</returns>
        public Node WithFill(Fill fill)
        {
            Fill = fill;
            return this;
        }

        /// <summary>
        /// Sets the fill of the node
        /// </summary>
        /// <param name="color">The fill color</param>
        /// <param name="gradientColor">An optional gradient color</param>
        /// <param name="gradientRotation">An optional gradient rotation</param>
        /// <returns>A reference to itself</returns>
        public Node WithFill(Color color, Color? gradientColor = null, GradientRotation? gradientRotation = null)
        {
            Fill = new Fill(color, gradientColor, gradientRotation);
            return this;
        }

        /// <summary>
        /// Sets the fill of the node to an image
        /// </summary>
        /// <param name="image">The fill image</param>
        /// <returns>A reference to itself</returns>
        public Node WithFill(Uri image)
        {
            Fill = new Fill(image);
            return this;
        }

        /// <summary>
        /// Sets the line of the node
        /// </summary>
        /// <param name="line">A line description</param>
        /// <returns>A reference to itself</returns>
        public Node WithLine(Line line)
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
        public Node WithLine(Color color, double? width = null, LineShape? shape = null, LineStyle? style = null)
        {
            Line = new Line(color, width, shape, style);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ICollectable> Collect()
        {
            return Collector.Create(this)
                .Collect(Position)
                .Collect(Size)
                .Collect(Fill)
                .Collect(Line)
                .Build();
        }
    }
}
