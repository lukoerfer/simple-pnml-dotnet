using AutoFixture.NUnit3;
using NUnit.Framework;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class PlaceTest
    {
        [TestCase(null), TestCase(""), TestCase("   "), TestCase("test")]
        public void DefaultsToValidId(string id)
        {
            Place place = new Place(id);
            Assert.NotNull(place.Id);
            Assert.IsNotEmpty(place.Id);
            Assert.IsFalse(string.IsNullOrWhiteSpace(place.Id));
        }
        
        
    }
}
