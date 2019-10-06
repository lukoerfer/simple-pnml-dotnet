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
    [XmlRoot("pnml")]
    [Equals]
    public class Document
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("net")]
        public List<Net> Nets { get; set; } = new List<Net>();

        /// <summary>
        /// 
        /// </summary>
        public Document() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nets"></param>
        public Document(params Net[] nets)
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
