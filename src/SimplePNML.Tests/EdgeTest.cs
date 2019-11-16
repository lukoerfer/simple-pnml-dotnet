using NUnit.Framework;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class EdgeTest
    {
        [Test]
        public void CanCreateEdgeFromTuples()
        {
            Edge edge = new Edge((1.0, 2.0), (3.0, 4.0));
            Assert.AreEqual(2, edge.Positions.Count);
        }

        [Test]
        public void CanCreateEdgeFromTuplesFluently()
        {
            Edge edge = new Edge().WithPositions((1.0, 2.0), (3.0, 4.0));
            Assert.AreEqual(2, edge.Positions.Count);
        }
    }
}
