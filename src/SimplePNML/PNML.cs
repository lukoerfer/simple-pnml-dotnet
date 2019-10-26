using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Provides utility functions to work with PNML documents in a fluent style
    /// </summary>
    public static class PNML
    {
        public static Document Create()
        {
            return new Document();
        }

        public static Document Read(string content)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Document));
            using (StringReader reader = new StringReader(content))
            {
                return (Document) serializer.Deserialize(reader);
            }
        }

        public static Document Read(Stream stream)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Document));
            return (Document) serializer.Deserialize(stream);
        }

        public static Document Read(FileInfo file)
        {
            // TODO: Implementation
            throw new NotImplementedException();
        }

        public static Document Read(Uri uri)
        {
            // TODO: Implementation
            throw new NotImplementedException();
        }

        public static string Write(this Document document)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Document));
            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, document);
                return writer.ToString();
            }
        }

        public static void Write(this Document document, Stream stream)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Document));
            serializer.Serialize(stream, document);
        }

        public static void Write(this Document document, FileInfo file)
        {
            throw new NotImplementedException();
        }

    }
}
