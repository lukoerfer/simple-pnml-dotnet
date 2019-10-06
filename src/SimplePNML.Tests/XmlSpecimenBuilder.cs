using System;
using System.Reflection;
using AutoFixture.Kernel;

namespace SimplePNML.Tests
{
    class XmlSpecimenBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            PropertyInfo property = request as PropertyInfo;
            if (property != null && property.Name.StartsWith("Xml"))
            {
                return new OmitSpecimen();
            }
            return new NoSpecimen();
        }
    }
}
