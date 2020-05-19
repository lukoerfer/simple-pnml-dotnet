using System;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Base of all elements in place/transition nets that can be identified
    /// </summary>
    public abstract class Identifiable
    {
        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        [XmlAttribute("id")]
        public string Id { get; set; }

        protected Identifiable()
        {
            Id = Guid.NewGuid().ToString();
        }

        protected Identifiable(string id)
        {
            Id = id;
        }
    }
}
