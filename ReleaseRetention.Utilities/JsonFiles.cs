using Newtonsoft.Json;
using ReleaseRetention.Entities;

namespace ReleaseRetention.Utilities
{
    public class JsonFiles
    {
        public static ListOfJsonData Deserialise(string filePath)
        {
            ListOfJsonData data = new ListOfJsonData();

            try
            {
                List<Projects> ProjectData = JsonConvert.DeserializeObject<List<Projects>>(File.ReadAllText(filePath + @"\" + Filename.Project));
                List<Releases> ReleaseData = JsonConvert.DeserializeObject<List<Releases>>(File.ReadAllText(filePath + @"\" + Filename.Release));
                List<Deployments> DeploymentData = JsonConvert.DeserializeObject<List<Deployments>>(File.ReadAllText(filePath + @"\" + Filename.Deployment));
                List<Environments> EnvironmentData = JsonConvert.DeserializeObject<List<Environments>>(File.ReadAllText(filePath + @"\" + Filename.Environment));

                data.Deployments = DeploymentData;
                data.Releases = ReleaseData;
                data.Projects = ProjectData;
                data.Environments = EnvironmentData;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return data;
        }
    }
}
