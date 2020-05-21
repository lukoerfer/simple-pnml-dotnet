using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Represents a PNML net
    /// </summary>
    [Equals]
    [XmlType("net")]
    public class Net : IIdentifiable, ICollectable
    {
        /// <summary>
        /// Defines the PNML grammar for place-transitions nets
        /// </summary>
        public const string PLACE_TRANSITION_NET_TYPE = "http://www.pnml.org/version-2009/grammar/ptnet";

        private string id;
        private string type;
        private Label name;
        private List<Page> pages;

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
        /// Gets or sets the type of this net
        /// </summary>
        [XmlAttribute("type")]
        public string Type
        {
            get => type ?? (type = PLACE_TRANSITION_NET_TYPE);
            set => type = value;
        }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("name")]
        public Label Name
        {
            get => name ?? (name = new Label());
            set => name = value;
        }

        /// <summary>
        /// Gets a collection containing the pages of this net
        /// </summary>
        [XmlElement("page")]
        public IList<Page> Pages
        {
            get => pages ?? (pages = new List<Page>());
            set => pages = new List<Page>(value);
        }

        /// <summary>
        /// Creates a new net
        /// </summary>
        public Net() { }

        /// <summary>
        /// Creates a new net
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        public Net(string id)
        {
            Id = id;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        public Net(string id, string type)
        {
            Id = id;
            Type = type;
        }

        /// <summary>
        /// Collects all child elements of this net recursively 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ICollectable> Collect()
        {
            return new Collector(this)
                .Include(Name)
                .Include(Pages)
                .Collect();
        }

        #region Internal serialization

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeName() => !Name.IsDefault();

        #endregion

    }
}
