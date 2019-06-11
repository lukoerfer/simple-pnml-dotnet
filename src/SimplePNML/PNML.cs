using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Container for PNML nets
    /// </summary>
    [XmlRoot("pnml")]
    public class PNML
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("net")]
        public List<Net> Nets { get; set; } = new List<Net>();

        /// <summary>
        /// Creates an empty container for PNML nets
        /// </summary>
        /// <returns></returns>
        public static PNML Create()
        {
            return new PNML();
        }

        /// <summary>
        /// Adds nets to this PNML container
        /// </summary>
        /// <param name="nets">Any number of nets</param>
        /// <returns>A reference to this container</returns>
        public PNML WithNets(params Net[] nets)
        {
            Nets.AddRange(nets);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        public void Write(Stream target)
        {
            BuildSerializer().Serialize(target, this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        public void Write(TextWriter target)
        {
            BuildSerializer().Serialize(target, this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        public void Write(FileInfo target)
        {
            Write(target.OpenWrite());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Write()
        {
            using (TextWriter writer = new StringWriter())
            {
                BuildSerializer().Serialize(writer, this);
                return writer.ToString();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static PNML Read(Stream source)
        {
            return (PNML) BuildSerializer().Deserialize(source);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static PNML Read(TextReader source)
        {
            return (PNML) BuildSerializer().Deserialize(source);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static PNML Read(FileInfo source)
        {
            return Read(source.OpenRead());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static PNML Read(string source)
        {
            using (TextReader reader = new StringReader(source))
            {
                return (PNML)BuildSerializer().Deserialize(reader);
            }
        }

        protected static XmlSerializer BuildSerializer()
        {
            return new XmlSerializer(typeof(PNML), "http://www.pnml.org/version-2009/grammar/pnml");
        }

        protected static XmlSerializerNamespaces BuildNamespaces()
        {
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, "http://www.pnml.org/version-2009/grammar/pnml");
            return namespaces;
        }

    }
}
