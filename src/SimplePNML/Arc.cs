using System.Collections.Generic;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Describes a PNML arc
    /// </summary>
    [Equals]
    [XmlType("arc")]
    public class Arc : Identifiable, ICollectable, IEdge, IToolExtendable
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
        public EdgeGraphics Graphics { get; set; }

        /// <summary>
        /// Gets or sets a label describing the inscription of this arc
        /// </summary>
        [XmlElement("inscription")]
        public Label Inscription { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<ToolSpecific> ToolSpecificData { get; set; } = new List<ToolSpecific>();

        /// <summary>
        /// Creates a new arc
        /// </summary>
        public Arc() : base() { }

        /// <summary>
        /// Creates a new arc
        /// </summary>
        /// <param name="id"></param>
        public Arc(string id) : base(id) { }

        /// <summary>
        /// Collects all child elements of this arc recursively
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ICollectable> Collect()
        {
            return new Collector(this)
                .Include(Graphics)
                .Include(Inscription)
                .Include(ToolSpecificData)
                .Collect();
        }

        #region Internal serialization



        #endregion

    }
}
