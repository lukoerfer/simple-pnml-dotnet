using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Represents a PNML page
    /// </summary>
    [Equals]
    [XmlType("page")]
    public class Page : IIdentifiable, ICollectable, INamed, INode, IToolExtendable
    {
        private string id;
        private Label name;
        private NodeGraphics graphics;
        private List<Page> pages;
        private List<Place> places;
        private List<Transition> transitions;
        private List<Arc> arcs;
        private List<ToolSpecific> toolSpecifics;

        [XmlElement("id")]
        public string Id
        {
            get => id ?? (id = Guid.NewGuid().ToString());
            set => id = value;
        }

        /// <summary>
        /// Gets or sets a label containing the name
        /// </summary>
        [XmlElement("name")]
        public Label Name
        {
            get => name ?? (name = new Label());
            set => name = value;
        }

        /// <summary>
        /// Gets or sets how to visualize the page
        /// </summary>
        [XmlElement("graphics")]
        public NodeGraphics Graphics
        {
            get => graphics ?? (graphics = new NodeGraphics());
            set => graphics = value;
        }

        /// <summary>
        /// Gets or sets the sub-pages of this page
        /// </summary>
        [XmlElement("page")]
        public IList<Page> Pages
        {
            get => pages ?? (pages = new List<Page>());
            set => pages = new List<Page>(value);
        }

        /// <summary>
        /// Gets or sets the places on this page
        /// </summary>
        [XmlElement("place")]
        public IList<Place> Places
        {
            get => places ?? (places = new List<Place>());
            set => places = new List<Place>(value);
        }

        /// <summary>
        /// Gets or sets the transitions on this page
        /// </summary>
        [XmlElement("transition")]
        public IList<Transition> Transitions
        {
            get => transitions ?? (transitions = new List<Transition>());
            set => transitions = new List<Transition>(value);
        }

        /// <summary>
        /// Gets or sets the arcs on this page
        /// </summary>
        [XmlElement("arc")]
        public IList<Arc> Arcs
        {
            get => arcs ?? (arcs = new List<Arc>());
            set => arcs = new List<Arc>(value);
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
