using System;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Represents a PNML place
    /// </summary>
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
        /// Gets or sets information on how to visualize this place
        /// </summary>
        [XmlElement("graphics")]
        public Graphics Graphics { get; set; }

        /// <summary>
        /// Gets or sets a label containing the name of this place
        /// </summary>
        [XmlElement("name")]
        public Label Name { get; set; }

        /// <summary>
        /// Gets or sets the initial marking of this place
        /// </summary>
        /// <remarks>This label should contain a positive integer</remarks>
        [XmlElement("initialMarking")]
        public Label InitialMarking { get; set; }

        /// <summary>
        /// Creates a new PNML place
        /// </summary>
        /// <param name="id">An identifier, should be unique, defaults to a random GUID</param>
        /// <param name="graphics">Visualization information, may be null</param>
        /// <param name="name">A name, may be null</param>
        /// <param name="initialMarking">An initial marking, may be null</param>
        /// <returns>A new place</returns>
        public static Place Create(string id = null, Graphics graphics = null, Label name = null, Label initialMarking = null)
        {
            id = string.IsNullOrWhiteSpace(id) ? Guid.NewGuid().ToString() : id;
            return new Place()
            {
                Id = id,
                Graphics = graphics,
                Name = name,
                InitialMarking = initialMarking
            };
        }

    }
}
