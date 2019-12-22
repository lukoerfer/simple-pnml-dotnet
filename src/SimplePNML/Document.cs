using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Container for PNML nets
    /// </summary>
    [Equals]
    [XmlRoot("pnml", Namespace = PNML_NAMESPACE)]
    public class Document : ICollectable
    {
        /// <summary>
        /// Defines the XML namespace of the Petri Net Markup Language
        /// </summary>
        public const string PNML_NAMESPACE = "http://www.pnml.org/version-2009/grammar/pnml";

        /// <summary>
        /// Gets or sets the document namespaces
        /// </summary>
        /// <remarks>Defaults to a set with the PNML namespace as default namespace</remarks>
        [IgnoreDuringEquals]
        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces Namespaces { get; set; } = new XmlSerializerNamespaces();

        /// <summary>
        /// Gets or sets the nets in the document
        /// </summary>
        [NotNull]
        [XmlElement("net")]
        public List<Net> Nets { get; set; } = new List<Net>();

        /// <summary>
        /// Creates a new PNML document
        /// </summary>
        public Document()
        {
            Namespaces.Add(string.Empty, PNML_NAMESPACE);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ICollectable> Collect()
        {
            return Collector.Create(this)
                .Collect(Nets)
                .Build();
        }
    }
}
