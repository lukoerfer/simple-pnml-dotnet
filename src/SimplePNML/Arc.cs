using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Describes a PNML arc
    /// </summary>
    [Equals]
    [XmlType("arc")]
    public class Arc : IIdentifiable, ICollectable, IEdge, IToolExtendable
    {
        private string id;
        private EdgeGraphics graphics;
        private Label inscription;
        private List<ToolSpecific> toolSpecifics;

        /// <summary>
        /// 
        /// </summary>
        [XmlAttribute("id")]
        public string Id
        {
            get => id ?? (id = Guid.NewGuid().ToString());
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
        public EdgeGraphics Graphics
        {
            get => graphics ?? (graphics = new EdgeGraphics());
            set => graphics = value;
        }

        /// <summary>
        /// Gets or sets a label describing the inscription of this arc
        /// </summary>
        [XmlElement("inscription")]
        public Label Inscription
        {
            get => inscription ?? (inscription = new Label());
            set => inscription = value;
        }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("toolspecific")]
        public IList<ToolSpecific> ToolSpecifics
        {
            get => toolSpecifics ?? (toolSpecifics = new List<ToolSpecific>());
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

        #region Internal serialization

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeGraphics() => Graphics.IsDefault();

        #endregion

    }
}
