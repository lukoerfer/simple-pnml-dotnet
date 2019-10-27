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
        /// Creates an empty document in a fluent style
        /// </summary>
        /// <returns></returns>
        public static Document Create()
        {
            return new Document();
        }

        /// <summary>
        /// Reads a document from a stream in a fluent style
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static Document Read(Stream stream)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Document));
            return (Document)serializer.Deserialize(stream);
        }

        /// <summary>
        /// Reads a document from a string in a fluent style
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
        /// Reads a document from a file in a fluent style
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
        /// Reads a document from an URI in a fluent style
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static Document Read(Uri uri)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes a document to a stream in a fluent style
        /// </summary>
        /// <param name="document"></param>
        /// <param name="stream"></param>
        public static void Write(this Document document, Stream stream)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Document));
            serializer.Serialize(stream, document);
        }
        
        /// <summary>
        /// Writes a document to a string in a fluent style
        /// </summary>
        /// <param name="document"></param>
        /// <param name="content"></param>
        public static void Write(this Document document, out string content)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Document));
            using (TextWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, document);
                content = writer.ToString();
            }
        }

        /// <summary>
        /// Writes a document to a file in a fluent style
        /// </summary>
        /// <param name="document"></param>
        /// <param name="file"></param>
        public static void Write(this Document document, FileInfo file)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Document));
            using (Stream stream = file.OpenWrite())
            {
                serializer.Serialize(stream, document);
            }
        }

    }
}
