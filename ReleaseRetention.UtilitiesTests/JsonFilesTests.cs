using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReleaseRetention.Entities;

namespace ReleaseRetention.Utilities.Tests
{
    [TestClass()]
    public class JsonFilesTests
    {
        [TestMethod()]
        public void DeserialiseTest()
        {
            Assert.AreEqual(typeof(ListOfJsonData), JsonFiles.Deserialise(URL.JSON_FilePath).GetType());
        }
    }
}