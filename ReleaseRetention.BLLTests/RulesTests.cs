using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReleaseRetention.Entities;
using ReleaseRetention.Utilities;
using System.Globalization;

namespace ReleaseRetention.BLL.Tests
{
    [TestClass()]
    public class RulesTests
    {
        [TestMethod()]
        public void ApplyReleaseRetentionTestInvalidParameter()
        {
            string inputParameter = "string";
            bool validInput = int.TryParse(inputParameter, out int noOfReleases);

            if (!validInput)
            {
                Assert.IsTrue(false, $"Invalid input! Assertion failed because input parameter -" + inputParameter + "- is incorrect");
            }
        }

        [TestMethod()]
        public void ApplyReleaseRetentionTestParameter0()
        {
            string inputParameter = "0";
            bool validInput = int.TryParse(inputParameter, out int noOfReleases);

            if (validInput)
            {
                string jsonFilePath = "E:/OctopusDeploy/ReleaseRetentionApp/ReleaseRetentionApp/Json";

                List<RetainedDeployments> expectedList = new();

                if (!string.IsNullOrEmpty(jsonFilePath))//(URL.JSON_FilePath))
                {
                    ListOfJsonData data = JsonFiles.Deserialise(jsonFilePath);//(URL.JSON_FilePath);

                    if (data.Deployments != null && data.Releases != null && data.Projects != null && data.Environments != null)
                    {
                        List<RetainedDeployments> actualList = Rules.ApplyReleaseRetention(data, noOfReleases);

                        //if (actualList.Count != 0)
                        //{
                        expectedList.Should().BeEquivalentTo(actualList, option => option.Excluding(x => x.Reason), "The actual and expected list matched");
                        //}
                        //else
                        //{
                        //    Assert.IsTrue(false, $"Assertion failed because 0 releases doesn't yeild any results");
                        //}
                    }
                    else
                    {
                        Assert.IsTrue(false, $"Assertion failed json data didn't deserialise correctly");
                    }
                }
                else
                {
                    Assert.IsTrue(false, $"Assertion failed because file path is incorrect");
                }
            }
            else
            {
                Assert.IsTrue(false, $"Invalid input! Assertion failed because input parameter type is incorrect");
            }
        }

        [TestMethod()]
        public void ApplyReleaseRetentionTestParameter1()
        {
            string inputParameter = "1";
            bool validInput = int.TryParse(inputParameter, out int noOfReleases);

            if (validInput)
            {
                string jsonFilePath = "E:/OctopusDeploy/ReleaseRetentionApp/ReleaseRetentionApp/Json";

                List<RetainedDeployments> expectedList = new()
                {
                     new RetainedDeployments  {  DeploymentId="Deployment-7", ReleaseId="Release-6", ProjectId="Project-2", EnvironmentId="Environment-2", DeployedAt=Convert.ToDateTime("1/01/0001 12:00:00 AM", CultureInfo.InvariantCulture), Reason=("Release-6 kept because it was the most recently deployed to \r\nEnvironment-2 at 2/01/2000 11:00:00 AM").Trim()  },
                     new RetainedDeployments  {  DeploymentId="Deployment-9", ReleaseId="Release-6", ProjectId="Project-2", EnvironmentId="Environment-1", DeployedAt=Convert.ToDateTime("1/01/0001 12:00:00 AM", CultureInfo.InvariantCulture), Reason=("Release-6 kept because it was the most recently deployed to \r\nEnvironment-1 at 2/01/2000 2:00:00 PM").Trim()  },
                     new RetainedDeployments  {  DeploymentId="Deployment-3", ReleaseId="Release-1", ProjectId="Project-1", EnvironmentId="Environment-2", DeployedAt=Convert.ToDateTime("1/01/0001 12:00:00 AM", CultureInfo.InvariantCulture), Reason=("Release-1 kept because it was the most recently deployed to \r\nEnvironment-2 at 2/01/2000 11:00:00 AM").Trim()  },
                     new RetainedDeployments  {  DeploymentId="Deployment-2", ReleaseId="Release-2", ProjectId="Project-1", EnvironmentId="Environment-1", DeployedAt=Convert.ToDateTime("1/01/0001 12:00:00 AM", CultureInfo.InvariantCulture), Reason=("Release-2 kept because it was the most recently deployed to \r\nEnvironment-1 at 2/01/2000 10:00:00 AM").Trim()  }
                };

                if (!string.IsNullOrEmpty(jsonFilePath))//(URL.JSON_FilePath))
                {
                    ListOfJsonData data = JsonFiles.Deserialise(jsonFilePath);//(URL.JSON_FilePath);

                    if (data.Deployments != null && data.Releases != null && data.Projects != null && data.Environments != null)
                    {
                        List<RetainedDeployments> actualList = Rules.ApplyReleaseRetention(data, noOfReleases);

                        if (actualList.Count != 0)
                        {
                            expectedList.Should().BeEquivalentTo(actualList, option => option.Excluding(x => x.Reason), "The actual and expected list matched");
                        }
                        else
                        {
                            Assert.IsTrue(false, $"Assertion failed because 0 releases doesn't yeild any results");
                        }
                    }
                    else
                    {
                        Assert.IsTrue(false, $"Assertion failed json data didn't deserialise correctly");
                    }
                }
                else
                {
                    Assert.IsTrue(false, $"Assertion failed because file path is incorrect");
                }
            }
            else
            {
                Assert.IsTrue(false, $"Invalid input! Assertion failed because input parameter type is incorrect");
            }
        }

        [TestMethod()]
        public void ApplyReleaseRetentionTestParameter2()
        {
            string inputParameter = "2";
            bool validInput = int.TryParse(inputParameter, out int noOfReleases);

            if (validInput)
            {
                string jsonFilePath = "E:/OctopusDeploy/ReleaseRetentionApp/ReleaseRetentionApp/Json";

                List<RetainedDeployments> expectedList = new()
                {
                     new RetainedDeployments  {  DeploymentId="Deployment-7", ReleaseId="Release-6", ProjectId="Project-2", EnvironmentId="Environment-2", DeployedAt=Convert.ToDateTime("1/01/0001 12:00:00 AM", CultureInfo.InvariantCulture), Reason=("Release-6 kept because it was the most recently deployed to \r\nEnvironment-2 at 2/01/2000 11:00:00 AM").Trim()  },
                     new RetainedDeployments  {  DeploymentId="Deployment-9", ReleaseId="Release-6", ProjectId="Project-2", EnvironmentId="Environment-1", DeployedAt=Convert.ToDateTime("1/01/0001 12:00:00 AM", CultureInfo.InvariantCulture), Reason=("Release-6 kept because it was the most recently deployed to \r\nEnvironment-1 at 2/01/2000 2:00:00 PM").Trim()  },
                     new RetainedDeployments  {  DeploymentId="Deployment-8", ReleaseId="Release-7", ProjectId="Project-2", EnvironmentId="Environment-1", DeployedAt=Convert.ToDateTime("1/01/0001 12:00:00 AM", CultureInfo.InvariantCulture), Reason=("Release-7 kept because it was the most recently deployed to \r\nEnvironment-1 at 2/01/2000 1:00:00 PM").Trim()  },
                     new RetainedDeployments  {  DeploymentId="Deployment-3", ReleaseId="Release-1", ProjectId="Project-1", EnvironmentId="Environment-2", DeployedAt=Convert.ToDateTime("1/01/0001 12:00:00 AM", CultureInfo.InvariantCulture), Reason=("Release-1 kept because it was the most recently deployed to \r\nEnvironment-2 at 2/01/2000 11:00:00 AM").Trim()  },
                     new RetainedDeployments  {  DeploymentId="Deployment-2", ReleaseId="Release-2", ProjectId="Project-1", EnvironmentId="Environment-1", DeployedAt=Convert.ToDateTime("1/01/0001 12:00:00 AM", CultureInfo.InvariantCulture), Reason=("Release-2 kept because it was the most recently deployed to \r\nEnvironment-1 at 2/01/2000 10:00:00 AM").Trim()  },
                     new RetainedDeployments  {  DeploymentId="Deployment-1", ReleaseId="Release-1", ProjectId="Project-1", EnvironmentId="Environment-1", DeployedAt=Convert.ToDateTime("1/01/0001 12:00:00 AM", CultureInfo.InvariantCulture), Reason=("Release-1 kept because it was the most recently deployed to \r\nEnvironment-1 at 1/01/2000 10:00:00 AM").Trim()  }
                };

                if (!string.IsNullOrEmpty(jsonFilePath))//(URL.JSON_FilePath))
                {
                    ListOfJsonData data = JsonFiles.Deserialise(jsonFilePath);//(URL.JSON_FilePath);

                    if (data.Deployments != null && data.Releases != null && data.Projects != null && data.Environments != null)
                    {
                        List<RetainedDeployments> actualList = Rules.ApplyReleaseRetention(data, noOfReleases);

                        if (actualList.Count != 0)
                        {
                            expectedList.Should().BeEquivalentTo(actualList, option => option.Excluding(x => x.Reason), "The actual and expected list matched");
                        }
                        else
                        {
                            Assert.IsTrue(false, $"Assertion failed because 0 releases doesn't yeild any results");
                        }
                    }
                    else
                    {
                        Assert.IsTrue(false, $"Assertion failed json data didn't deserialise correctly");
                    }
                }
                else
                {
                    Assert.IsTrue(false, $"Assertion failed because file path is incorrect");
                }
            }
            else
            {
                Assert.IsTrue(false, $"Invalid input! Assertion failed because input parameter type is incorrect");
            }
        }

    }
}