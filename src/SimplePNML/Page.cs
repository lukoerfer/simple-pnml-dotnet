using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Represents a PNML page
    /// </summary>
    [Equals(DoNotAddEqualityOperators = true)]
    [XmlType("page")]
    public class Page : IIdentifiable, ICollectable, INamed, INode, IToolExtendable
    {
        private string id;
        private List<Page> pages = new List<Page>();
        private List<Place> places = new List<Place>();
        private List<Transition> transitions = new List<Transition>();
        private List<Arc> arcs = new List<Arc>();
        private List<ToolSpecific> toolSpecifics = new List<ToolSpecific>();

        [XmlElement("id")]
        public string Id
        {
            get => id ??= Guid.NewGuid().ToString();
            set => id = value;
        }

        /// <summary>
        /// Gets or sets a label containing the name
        /// </summary>
        [XmlElement("name")]
        public Label Name { get; set; } = new Label();

        /// <summary>
        /// Gets or sets how to visualize the page
        /// </summary>
        [XmlElement("graphics")]
        public NodeGraphics Graphics { get; set; } = new NodeGraphics();

        /// <summary>
        /// Gets or sets the sub-pages of this page
        /// </summary>
        [XmlElement("page")]
        public List<Page> Pages
        {
            get => pages;
            set => pages = new List<Page>(value);
        }

        /// <summary>
        /// Gets or sets the places on this page
        /// </summary>
        [XmlElement("place")]
        public List<Place> Places
        {
            get => places;
            set => places = new List<Place>(value);
        }

        /// <summary>
        /// Gets or sets the transitions on this page
        /// </summary>
        [XmlElement("transition")]
        public List<Transition> Transitions
        {
            get => transitions;
            set => transitions = new List<Transition>(value);
        }

        /// <summary>
        /// Gets or sets the arcs on this page
        /// </summary>
        [XmlElement("arc")]
        public List<Arc> Arcs
        {
            get => arcs;
            set => arcs = new List<Arc>(value);
        }

        /// <summary>
        /// 
        /// </summary>
        public List<ToolSpecific> ToolSpecifics
        {
            get => toolSpecifics;
            set => toolSpecifics = new List<ToolSpecific>(value);
        }

        /// <summary>
        /// Creates a new page
        /// </summary>
        public Page() { }

        /// <summary>
        /// Creates a new page
        /// </summary>
        /// <param name="id"></param>
        public Page(string id)
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
                .Include(Pages)
                .Include(Places)
                .Include(Transitions)
                .Include(Arcs)
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
