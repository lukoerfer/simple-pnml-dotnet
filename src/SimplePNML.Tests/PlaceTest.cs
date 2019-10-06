using NUnit.Framework;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class PlaceTest
    {
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
