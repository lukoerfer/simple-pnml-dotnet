using System;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Base of all elements in place/transition nets that can be identified
    /// </summary>
    public abstract class Identifiable
    {
        private string _id;

        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        [XmlAttribute("id")]
        public string Id
        {
            get => _id;
            set => _id = value ?? Guid.NewGuid().ToString();
        }
    }
}
