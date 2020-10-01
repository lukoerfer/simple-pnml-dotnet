using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Represents an arc in a petri net
    /// </summary>
    [Equals(DoNotAddEqualityOperators = true)]
    [XmlType("arc")]
    public class Arc : IIdentifiable, ICollectable, IEdge, IToolExtendable
    {
        private string id;
        private List<ToolSpecific> toolSpecifics = new List<ToolSpecific>();

        /// <summary>
        /// 
        /// </summary>
        [XmlAttribute("id")]
        public string Id
        {
            get => id ??= Guid.NewGuid().ToString();
            set => id = value;
        }

        /// <summary>
        /// Gets or sets the identifier of the arc source
        /// </summary>
        [XmlAttribute("source")]
        public string Source { get; set; } = "";

        /// <summary>
        /// Gets or sets the identifier of the arc target
        /// </summary>
        [XmlAttribute("target")]
        public string Target { get; set; } = "";

        /// <summary>
        /// Gets or sets the arc graphics
        /// </summary>
        [XmlElement("graphics")]
        public EdgeGraphics Graphics { get; set; } = new EdgeGraphics();

        /// <summary>
        /// Gets or sets a label describing the inscription of this arc
        /// </summary>
        [XmlElement("inscription")]
        public Label Inscription { get; set; } = new Label();

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("toolspecific")]
        public List<ToolSpecific> ToolSpecifics
        {
            get => toolSpecifics;
            set => toolSpecifics = new List<ToolSpecific>(value);
        }


        /// <summary>
        /// Creates a new arc
        /// </summary>
        public Arc() { }

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
            return new Collector(this)
                .Include(Graphics)
                .Include(Inscription)
                .Include(ToolSpecifics)
                .Collect();
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeGraphics() => Graphics.IsDefault();

    }
}
