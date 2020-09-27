using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Represents a PNML transition
    /// </summary>
    [Equals(DoNotAddEqualityOperators = true)]
    [XmlType("transition")]
    public class Transition : IConnectable, ICollectable, INamed, INode, IToolExtendable
    {
        private List<ToolSpecific> toolSpecifics = new List<ToolSpecific>();

        [XmlAttribute("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name 
        /// </summary>
        [XmlElement("name")]
        public Label Name { get; set; } = new Label();

        /// <summary>
        /// Gets or sets the graphics
        /// </summary>
        [XmlElement("graphics")]
        public NodeGraphics Graphics { get; set; } = new NodeGraphics();

        /// <summary>
        /// 
        /// </summary>
        public List<ToolSpecific> ToolSpecifics
        {
            get => toolSpecifics;
            set => toolSpecifics = new List<ToolSpecific>(value);
        }

        /// <summary>
        /// Creates a new transition with a generated ID
        /// </summary>
        public Transition() { }

        /// <summary>
        /// Creates a new transition
        /// </summary>
        /// <param name="id"></param>
        public Transition(string id)
        {
            Id = id;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ICollectable> Collect()
        {
            return new Collector(this)
                .Include(Name)
                .Include(Graphics)
                .Include(ToolSpecifics)
                .Collect();
        }

        #region Internal serialization

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeName() => !Name.IsDefault();

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeGraphics() => !Graphics.IsDefault();

        #endregion
    }
}
