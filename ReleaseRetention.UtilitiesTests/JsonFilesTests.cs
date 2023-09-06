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
            string jsonFilePath = "E:/OctopusDeploy/ReleaseRetentionApp/ReleaseRetentionApp/Json";

            ListOfJsonData data = JsonFiles.Deserialise(jsonFilePath);

            if (data.Deployments == null && data.Releases == null && data.Projects == null && data.Environments == null)
            {
                Assert.IsTrue(false, $"Assertion failed json data didn't deserialise correctly");
            }
        }
    }
}