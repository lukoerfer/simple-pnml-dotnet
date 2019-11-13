using System;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Encapsulates PNML elements that can be identified
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
            set => _id = string.IsNullOrWhiteSpace(value) ? Guid.NewGuid().ToString() : value;
        }
    }
}
