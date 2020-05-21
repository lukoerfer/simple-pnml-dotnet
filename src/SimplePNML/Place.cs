using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Represents a PNML place
    /// </summary>
    [Equals]
    [XmlType("place")]
    public class Place : IConnectable, ICollectable, INamed, INode, IToolExtendable
    {
        private string id;
        private Label name;
        private NodeGraphics graphics;
        private Label initialMarking;
        private List<ToolSpecific> toolSpecifics;

        [XmlElement("id")]
        public string Id
        {
            get => id ?? (id = Guid.NewGuid().ToString());
            set => id = value;
        }

        /// <summary>
        /// Gets or sets a label containing the name of the place
        /// </summary>
        [XmlElement("name")]
        public Label Name
        {
            get => name ?? (name = new Label());
            set => name = value;
        }

        /// <summary>
        /// Gets or sets how to visualize this place
        /// </summary>
        [XmlElement("graphics")]
        public NodeGraphics Graphics
        {
            get => graphics ?? (graphics = new NodeGraphics());
            set => graphics = value;
        }

        /// <summary>
        /// Gets or sets a label defining the initial marking of the place
        /// </summary>
        /// <remarks>This label should contain a positive integer</remarks>
        [XmlElement("initialMarking")]
        public Label InitialMarking
        {
            get => initialMarking ?? (initialMarking = new Label());
            set => initialMarking = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public IList<ToolSpecific> ToolSpecifics
        {
            get => toolSpecifics ?? (toolSpecifics = new List<ToolSpecific>());
            set => toolSpecifics = new List<ToolSpecific>(value);
        }

        /// <summary>
        /// Creates a new place
        /// </summary>
        public Place() { }

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
            return new Collector(this)
                .Include(Name)
                .Include(Graphics)
                .Include(InitialMarking)
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

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeInitialMarking() => !InitialMarking.IsDefault();

        #endregion
    }
}
