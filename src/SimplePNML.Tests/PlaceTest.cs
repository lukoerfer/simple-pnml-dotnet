using System.IO;
using System.Xml.Serialization;

using AutoFixture.NUnit3;
using NUnit.Framework;

namespace SimplePNML.Tests
{
    public class PlaceTest
    {
        [Test, AutoData]
        public void EqualsAfterSerialization(Place input)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Place));
            MemoryStream stream = new MemoryStream();
            serializer.Serialize(stream, input);
            stream.Position = 0;
            Place output = (Place) serializer.Deserialize(stream);
            Assert.IsTrue(input.Equals(output));
        }

        [TestCase(null), TestCase(""), TestCase("   "), TestCase("test")]
        public void CreateGivesValidId(string id)
        {
            Place place = Place.Create(id);
            Assert.NotNull(place.Id);
            Assert.IsNotEmpty(place.Id);
            Assert.IsFalse(string.IsNullOrWhiteSpace(place.Id));
        }
    }
}
