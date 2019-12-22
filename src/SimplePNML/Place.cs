using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Represents a PNML place
    /// </summary>
    [Equals]
    [XmlType("place")]
    public class Place : Connectable, ICollectable, INamed, INodeElement
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

        public IEnumerable<ICollectable> Collect()
        {
            return Collector.Create(this)
                .Collect(Name)
                .Collect(Graphics)
                .Collect(InitialMarking)
                .Build();
        }
    }
}
