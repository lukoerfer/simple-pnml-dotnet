using System;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Represents a PNML place
    /// </summary>
    [Equals]
    [XmlType("place")]
    public class Place : IConnectable
    {
        /// <summary>
        /// Gets or sets the identifier of this place
        /// </summary>
        /// <remarks>The identifier should be unique inside the net, not only regarding places but all identifiable elements.</remarks>
        [XmlAttribute("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets a label containing the name
        /// </summary>
        [XmlElement("name")]
        public Label Name { get; set; }

        /// <summary>
        /// Gets or sets information on how to visualize this place
        /// </summary>
        [XmlElement("graphics")]
        public Node Graphic { get; set; }

        /// <summary>
        /// Gets or sets the initial marking of this place
        /// </summary>
        /// <remarks>This label should contain a positive integer</remarks>
        [XmlElement("initialMarking")]
        public Label InitialMarking { get; set; }

        /// <summary>
        /// Creates a new place
        /// </summary>
        public Place() : this(null, null, null) { }

        /// <summary>
        /// Creates a new place
        /// </summary>
        /// <param name="name"></param>
        /// <param name="graphics"></param>
        public Place(Label name, Node graphics = null) : this(null, name, graphics) { }

        /// <summary>
        /// Creates a new place
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="graphics"></param>
        public Place(string id, Label name = null, Node graphics = null)
        {
            Id = string.IsNullOrWhiteSpace(id) ? Guid.NewGuid().ToString() : id;
            Name = name;
            Graphic = graphics;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Place WithName(string name)
        {
            Name = new Label(name);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Place WithName(Label name)
        {
            Name = name;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="graphics"></param>
        /// <returns></returns>
        public Place WithGraphic(Node graphics)
        {
            Graphic = graphics;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="initialMarking"></param>
        /// <returns></returns>
        public Place WithInitialMarking(Label initialMarking)
        {
            InitialMarking = initialMarking;
            return this;
        }
    }
}
