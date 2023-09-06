using FluentAssertions;
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

            data.Deployments.Should().NotBeNull($"Assertion failed as Deployments json didn't deserialise correctly");
            data.Releases.Should().NotBeNull($"Assertion failed as Releases json didn't deserialise correctly");
            data.Projects.Should().NotBeNull($"Assertion failed as Projects json didn't deserialise correctly");
            data.Environments.Should().NotBeNull($"Assertion failed as Environments json didn't deserialise correctly");
        }
    }
}