using System;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Describes a PNML arc
    /// </summary>
    [Equals]
    [XmlType("arc")]
    public class Arc : Identifiable
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
        /// Sets both the source and the target of this arc
        /// </summary>
        /// <param name="source">Any connectable PNML element</param>
        /// <param name="target">Any connectable PNML element</param>
        public void Connect(Connectable source, Connectable target)
        {
            Source = source?.Id;
            Target = target?.Id;
        }

        /// <summary>
        /// Sets the source of this arc
        /// </summary>
        /// <param name="source"></param>
        /// <returns>A reference to itself</returns>
        public Arc WithSource(Connectable source)
        {
            Source = source?.Id;
            return this;
        }

        /// <summary>
        /// Sets the source of this arc
        /// </summary>
        /// <param name="source">The identifier of a connectable element</param>
        /// <returns>A reference to itself</returns>
        public Arc WithSource(string source)
        {
            Source = source;
            return this;
        }

        /// <summary>
        /// Sets the target of this arc
        /// </summary>
        /// <param name="target"></param>
        /// <returns>A reference to itself</returns>
        public Arc WithTarget(Connectable target)
        {
            Target = target?.Id;
            return this;
        }

        /// <summary>
        /// Sets the target of this arc
        /// </summary>
        /// <param name="target"></param>
        /// <returns>A reference to itself</returns>
        public Arc WithTarget(string target)
        {
            Target = target;
            return this;
        }

        /// <summary>
        /// Sets both the source and the target of this arc
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns>A reference to itself</returns>
        public Arc Connecting(Connectable source, Connectable target)
        {
            Source = source?.Id;
            Target = target?.Id;
            return this;
        }

        /// <summary>
        /// Sets the inscription of this arc
        /// </summary>
        /// <param name="inscription"></param>
        /// <returns>A reference to itself</returns>
        public Arc WithInscription(Label inscription)
        {
            Inscription = inscription;
            return this;
        }

    }
}
