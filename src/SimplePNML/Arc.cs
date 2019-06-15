using System;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Describes a PNML arc
    /// </summary>
    [XmlType("arc")]
    public class Arc : IIdentifiable
    {
        /// <summary>
        /// Gets or sets the identifier of this arc
        /// </summary>
        [XmlAttribute("id")]
        public string Id { get; set; }

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
        /// Gets or sets a label describing the inscription of this arc
        /// </summary>
        [XmlElement("inscription")]
        public Label Inscription { get; set; }

        /// <summary>
        /// Creates a new PNML arc
        /// </summary>
        /// <param name="id"></param>
        /// <param name="source">Any connectable PNML element</param>
        /// <param name="target">Any connectable PNML element</param>
        /// <param name="inscription"></param>
        /// <returns>A new PNML arc</returns>
        public static Arc Create(string id = null, IConnectable source = null, IConnectable target = null, Label inscription = null)
        {
            id = string.IsNullOrWhiteSpace(id) ? Guid.NewGuid().ToString() : id;
            return new Arc()
            {
                Id = id,
                Source = source?.Id,
                Target = target?.Id,
                Inscription = inscription
            };
        }

        /// <summary>
        /// Sets the source of this arc
        /// </summary>
        /// <param name="source">Any connectable PNML element</param>
        public void SetSource(IConnectable source)
        {
            Source = source?.Id;
        }

        /// <summary>
        /// Sets the target of this arc
        /// </summary>
        /// <param name="target">Any connectable PNML element</param>
        public void SetTarget(IConnectable target)
        {
            Target = target?.Id;
        }

        /// <summary>
        /// Sets both source and target of this arc
        /// </summary>
        /// <param name="source">Any connectable PNML element</param>
        /// <param name="target">Any connectable PNML element</param>
        public void Connect(IConnectable source, IConnectable target)
        {
            Source = source?.Id;
            Target = target?.Id;
        }

    }
}
