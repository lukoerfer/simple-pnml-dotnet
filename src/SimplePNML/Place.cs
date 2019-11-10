using System;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Represents a PNML place
    /// </summary>
    [Equals]
    [XmlType("place")]
    public class Place : IConnectable, INodeElement
    {
        /// <summary>
        /// Gets or sets the identifier of this place
        /// </summary>
        /// <remarks>The identifier should be unique inside the net, not only regarding places but all identifiable elements.</remarks>
        [XmlAttribute("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets a label containing the name of the place
        /// </summary>
        [XmlElement("name")]
        public Label Name { get; set; }

        /// <summary>
        /// Gets or sets how to visualize this place
        /// </summary>
        [XmlElement("graphics")]
        public NodeGraphics Graphic { get; set; }

        /// <summary>
        /// Gets or sets a label defining the initial marking of the place
        /// </summary>
        /// <remarks>This label should contain a positive integer</remarks>
        [XmlElement("initialMarking")]
        public Label InitialMarkingLabel { get; set; }

        /// <summary>
        /// Gets or sets the initial marking of the place
        /// </summary>
        /// <remarks>The initial marking should be a </remarks>
        [XmlIgnore]
        [IgnoreDuringEquals]
        public int InitialMarking
        {
            get => int.Parse(InitialMarkingLabel?.Text ?? "0");
            set => throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a new place
        /// </summary>
        public Place() : this(null, null, null) { }

        /// <summary>
        /// Creates a new place
        /// </summary>
        /// <param name="name"></param>
        /// <param name="graphics"></param>
        public Place(Label name, NodeGraphics graphics = null) : this(null, name, graphics) { }

        /// <summary>
        /// Creates a new place
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="graphics"></param>
        public Place(string id, Label name = null, NodeGraphics graphics = null)
        {
            Id = string.IsNullOrWhiteSpace(id) ? Guid.NewGuid().ToString() : id;
            Name = name;
            Graphic = graphics;
        }

        /// <summary>
        /// Sets the name of the place
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Place WithName(string name)
        {
            Name = new Label(name);
            return this;
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
        /// Sets how to visualize the place
        /// </summary>
        /// <param name="graphics"></param>
        /// <returns>A reference to itself</returns>
        public Place WithGraphic(NodeGraphics graphics)
        {
            Graphic = graphics;
            return this;
        }

        /// <summary>
        /// Sets the initial marking of the place
        /// </summary>
        /// <param name="initialMarking"></param>
        /// <returns>A reference to itself</returns>
        public Place WithInitialMarking(int initialMarking)
        {
            InitialMarking = initialMarking;
            return this;
        }

        /// <summary>
        /// Sets the initial marking of the place
        /// </summary>
        /// <param name="initialMarking"></param>
        /// <returns>A reference to itself</returns>
        public Place WithInitialMarking(Label initialMarking)
        {
            InitialMarkingLabel = initialMarking;
            return this;
        }
    }
}
