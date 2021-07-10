using NUnit.Framework;
using Ecliptae;
using c = System.Console;
using Newtonsoft.Json;

namespace Ecliptae.NUnit
{
    public class ApiTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void VersionTest()
        {
            Assert.Pass();
        }
        [Test]
        public void SQLConfigTest()
        {
            var sqlConfig = new Lib.SQLConfig();
            c.WriteLine(JsonConvert.SerializeObject(sqlConfig));
            Assert.IsNotEmpty(JsonConvert.SerializeObject(sqlConfig));
        }
    }
}