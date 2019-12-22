using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Describes a PNML arc
    /// </summary>
    [Equals]
    [XmlType("arc")]
    public class Arc : Identifiable, ICollectable, IEdgeElement
    {
        /// <summary>
        /// Gets or sets the identifier of the arc source
        /// </summary>
        [XmlAttribute("source")]
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the arc target
        /// </summary>
        [XmlAttribute("target")]
        public string Target { get; set; }

        /// <summary>
        /// Gets or sets the arc graphics
        /// </summary>
        [XmlElement("graphics")]
        public Edge Graphics { get; set; }

        /// <summary>
        /// Gets or sets a label describing the inscription of this arc
        /// </summary>
        [XmlElement("inscription")]
        public Label Inscription { get; set; }

        /// <summary>
        /// Creates a new arc
        /// </summary>
        public Arc() : this(null) { }

        /// <summary>
        /// Creates a new arc
        /// </summary>
        /// <param name="id"></param>
        public Arc(string id)
        {
            Id = id;
        }

        /// <summary>
        /// Collects all child elements of this arc recursively
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ICollectable> Collect()
        {
            return Collector.Create(this)
                .Collect(Graphics)
                .Collect(Inscription)
                .Build();
        }
    }
}
