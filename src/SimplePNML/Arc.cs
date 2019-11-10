using System;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Describes a PNML arc
    /// </summary>
    [Equals]
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
        /// 
        /// </summary>
        [XmlElement("graphics")]
        public EdgeGraphic Graphics { get; set; }

        /// <summary>
        /// Gets or sets a label describing the inscription of this arc
        /// </summary>
        [XmlElement("inscription")]
        public Label InscriptionLabel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlIgnore]
        [IgnoreDuringEquals]
        public int Inscription
        {
            get => int.Parse(InscriptionLabel?.Text ?? "0");
            set => InscriptionLabel = new Label(value.ToString());
        }

        /// <summary>
        /// Creates a new arc
        /// </summary>
        public Arc() : this(null, null, null, null) { }

        /// <summary>
        /// Creates a new arc
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="graphics"></param>
        public Arc(IConnectable source, IConnectable target, EdgeGraphic graphics = null) : this(null, null, null, null) { }

        /// <summary>
        /// Creates a new arc
        /// </summary>
        /// <param name="id"></param>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="graphics"></param>
        public Arc(string id, IConnectable source = null, IConnectable target = null, EdgeGraphic graphics = null)
        {
            Id = string.IsNullOrWhiteSpace(id) ? Guid.NewGuid().ToString() : id;
            Source = source?.Id;
            Target = target?.Id;
            Graphics = graphics;
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

        /// <summary>
        /// Sets the source of this arc
        /// </summary>
        /// <param name="source"></param>
        /// <returns>A reference to itself</returns>
        public Arc WithSource(IConnectable source)
        {
            SetSource(source);
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
        public Arc WithTarget(IConnectable target)
        {
            SetTarget(target);
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
        /// Sets the inscription of this arc
        /// </summary>
        /// <param name="inscription"></param>
        /// <returns>A reference to itself</returns>
        public Arc WithInscription(int inscription)
        {
            InscriptionLabel = new Label(inscription.ToString());
            return this;
        }

        /// <summary>
        /// Sets the inscription of this arc
        /// </summary>
        /// <param name="inscription"></param>
        /// <returns>A reference to itself</returns>
        public Arc WithInscription(Label inscription)
        {
            InscriptionLabel = inscription;
            return this;
        }

    }
}
