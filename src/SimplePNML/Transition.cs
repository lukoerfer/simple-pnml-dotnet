using System;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Represents a PNML transition
    /// </summary>
    [Equals]
    [XmlType("transition")]
    public class Transition : Connectable, INodeElement
    {
        /// <summary>
        /// Gets or sets a label containing the name
        /// </summary>
        [XmlElement("name")]
        public Label Name { get; set; }

        /// <summary>
        /// Gets or sets the transition graphics
        /// </summary>
        [XmlElement("graphics")]
        public Node Graphics { get; set; }

        /// <summary>
        /// Creates a new transition with a generated ID
        /// </summary>
        public Transition() : this(null) { }

        /// <summary>
        /// Creates a new transition with a given ID
        /// </summary>
        /// <param name="id"></param>
        public Transition(string id)
        {
            Id = id;
        }

        /// <summary>
        /// Sets the name of the transition
        /// </summary>
        /// <param name="name"></param>
        /// <returns>A reference to itself</returns>
        public Transition WithName(Label name)
        {
            Name = name;
            return this;
        }

        /// <summary>
        /// Sets the graphics of the transition
        /// </summary>
        /// <param name="graphic"></param>
        /// <returns>A reference to itself</returns>
        public Transition WithGraphics(Node graphics)
        {
            Graphics = graphics;
            return this;
        }

        /// <summary>
        /// Sets the graphics of the transition
        /// </summary>
        /// <param name="x">The position in X direction</param>
        /// <param name="y">The position in Y direction</param>
        /// <param name="fill">An optional fill description</param>
        /// <param name="line">An optional line description</param>
        /// <returns>A reference to itself</returns>
        public Transition WithGraphics(double x, double y, Fill fill = null, Line line = null)
        {
            Graphics = new Node(x, y, fill, line);
            return this;
        }

        /// <summary>
        /// Sets the graphics of the transition
        /// </summary>
        /// <param name="x">The position in X direction</param>
        /// <param name="y">The position in Y direction</param>
        /// <param name="width">The length in X direction</param>
        /// <param name="height">The length in Y direction</param>
        /// <param name="fill">An optional fill description</param>
        /// <param name="line">An optional line description</param>
        /// <returns>A reference to itself</returns>
        public Transition WithGraphics(double x, double y, double width, double height, Fill fill = null, Line line = null)
        {
            Graphics = new Node(x, y, width, height, fill, line);
            return this;
        }
    }
}
