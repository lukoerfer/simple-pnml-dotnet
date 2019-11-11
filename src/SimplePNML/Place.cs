using System;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Represents a PNML place
    /// </summary>
    [Equals]
    [XmlType("place")]
    public class Place : Connectable, INodeElement
    {
        /// <summary>
        /// Gets or sets a label containing the name of the place
        /// </summary>
        [XmlElement("name")]
        public Label Name { get; set; }

        /// <summary>
        /// Gets or sets how to visualize this place
        /// </summary>
        [XmlElement("graphics")]
        public Node Graphics { get; set; }

        /// <summary>
        /// Gets or sets a label defining the initial marking of the place
        /// </summary>
        /// <remarks>This label should contain a positive integer</remarks>
        [XmlElement("initialMarking")]
        public Label InitialMarking { get; set; }

        /// <summary>
        /// Creates a new place
        /// </summary>
        public Place() : this(null) { }

        /// <summary>
        /// Creates a new place
        /// </summary>
        /// <param name="id"></param>
        public Place(string id)
        {
            Id = id;
        }

        /// <summary>
        /// Sets the name of the place
        /// </summary>
        /// <param name="name"></param>
        /// <returns>A reference to itself</returns>
        public Place WithName(Label name)
        {
            Name = name;
            return this;
        }

        /// <summary>
        /// Defines how to visualize the place
        /// </summary>
        /// <param name="graphics"></param>
        /// <returns>A reference to itself</returns>
        public Place WithGraphics(Node graphics)
        {
            Graphics = graphics;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="fill"></param>
        /// <param name="line"></param>
        /// <returns></returns>
        public Place WithGraphics(double x, double y, Fill fill = null, Line line = null)
        {
            Graphics = new Node(x, y, fill, line);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="fill"></param>
        /// <param name="line"></param>
        /// <returns></returns>
        public Place WithGraphics(double x, double y, double width, double height, Fill fill = null, Line line = null)
        {
            Graphics = new Node(x, y, width, height, fill, line);
            return this;
        }

        /// <summary>
        /// Sets the initial marking of the place
        /// </summary>
        /// <param name="initialMarking"></param>
        /// <returns>A reference to itself</returns>
        public Place WithInitialMarking(Label initialMarking)
        {
            InitialMarking = initialMarking;
            return this;
        }
    }
}
