using System;
using System.IO;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Provides utility functions to work with PNML documents in a fluent style
    /// </summary>
    public static class PNML
    {
        /// <summary>
        /// Creates an empty PNML document
        /// </summary>
        /// <returns>A new PNML document</returns>
        public static Document Create()
        {
            return new Document();
        }

        /// <summary>
        /// Reads a PNML document from a stream
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static Document Read(Stream stream)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Document));
            return (Document)serializer.Deserialize(stream);
        }

        /// <summary>
        /// Reads a PNML document from a string
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static Document Read(string content)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Document));
            using (StringReader reader = new StringReader(content))
            {
                return (Document) serializer.Deserialize(reader);
            }
        }

        /// <summary>
        /// Reads a PNML document from a file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static Document Read(FileInfo file)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Document));
            using (Stream stream = file.OpenRead())
            {
                return (Document) serializer.Deserialize(stream);
            }
        }

        /// <summary>
        /// Reads a PNML document from an URI
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static Document Read(Uri uri)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes a PNML document to a stream
        /// </summary>
        /// <param name="document"></param>
        /// <param name="stream"></param>
        /// <returns>A reference to the document</returns>
        public static Document Write(this Document document, Stream stream)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Document));
            serializer.Serialize(stream, document);
            return document;
        }
        
        /// <summary>
        /// Writes a PNML document to a string
        /// </summary>
        /// <param name="document"></param>
        /// <param name="content"></param>
        /// <returns>A reference to the document</returns>
        public static Document Write(this Document document, out string content)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Document));
            using (TextWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, document);
                content = writer.ToString();
            }
            return document;
        }

        /// <summary>
        /// Writes a PNML document to a file
        /// </summary>
        /// <param name="document"></param>
        /// <param name="file"></param>
        /// <returns>A reference to the document</returns>
        public static Document Write(this Document document, FileInfo file)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Document));
            using (Stream stream = file.OpenWrite())
            {
                serializer.Serialize(stream, document);
            }
            return document;
        }

    }
}
