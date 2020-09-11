using NUnit.Framework;
using System.IO;

namespace SimplePNML.Tests.Resources
{
    public static class Resource
    {
        public static StreamReader Read(string file)
        {
            return new StreamReader(Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", file));
        }

    }
}
