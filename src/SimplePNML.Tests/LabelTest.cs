using NUnit.Framework;

namespace SimplePNML.Tests
{
    [TestFixture]
    public class LabelTest
    {
        private Label label;

        [SetUp]
        public void Setup()
        {
            label = new Label();
        }

        [Test]
        public void IsDefault_NewInstance_True()
        {
            var isDefault = label.IsDefault();

            Assert.IsTrue(isDefault);
        }

        [Test]
        public void IsDefault_TextNotEmpty_False()
        {
            label.Text = "Lorem ipsum";

            var isDefault = label.IsDefault();

            Assert.IsFalse(isDefault);
        }


    }
}
