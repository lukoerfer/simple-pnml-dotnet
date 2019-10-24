using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Container for PNML nets
    /// </summary>
    [XmlRoot("pnml", Namespace = PNML_NAMESPACE)]
    [Equals]
    public class Document
    {
        public const string PNML_NAMESPACE = "http://www.pnml.org/version-2009/grammar/pnml";

        /// <summary>
        /// 
        /// </summary>
        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces Namespaces { get; set; } = new XmlSerializerNamespaces();

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("net")]
        public List<Net> Nets { get; set; } = new List<Net>();

        /// <summary>
        /// 
        /// </summary>
        public Document()
        {
            Namespaces.Add(string.Empty, PNML_NAMESPACE);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nets"></param>
        public Document(params Net[] nets) : this()
        {
            Nets = nets.ToList();
        }

        /// <summary>
        /// Adds nets to this PNML container
        /// </summary>
        /// <param name="nets">Any number of nets</param>
        /// <returns>A reference to this container</returns>
        public Document WithNets(params Net[] nets)
        {
            Nets.AddRange(nets);
            return this;
        }

    }
}
