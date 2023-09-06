using ReleaseRetention.Entities;
using ReleaseRetention.Utilities;

namespace ReleaseRetention.BLL
{
    public class Rules
    {
        public static List<RetainedDeployments> ApplyReleaseRetention(ListOfJsonData dataFiles, int releaseNumber)
        {
            List<RetainedDeployments> includeProjectId = new();
            List<RetainedDeployments> retainedList = new();

            if (releaseNumber != 0)
            {
                //Remove environments from Deployments list that are not present in EnvironmentList
                var cleanAndSortedDeploymentList = dataFiles.Deployments?.Where(x => JsonFiles.GetEnvironmentList(dataFiles).Contains(x.EnvironmentId)).OrderByDescending(x => x.DeployedAt);

                //Add projectId to RetainedDeployments list
                foreach (Deployments deploymentList in cleanAndSortedDeploymentList)
                {
                    RetainedDeployments eachDeployment = new()
                    {
                        ReleaseId = deploymentList.ReleaseId,
                        EnvironmentId = deploymentList.EnvironmentId,
                        ProjectId = dataFiles.Releases.Where(x => x.Id.Equals(deploymentList.ReleaseId, StringComparison.Ordinal)).Select(x => x.ProjectId).FirstOrDefault(),
                        DeploymentId = deploymentList.Id,
                        DeployedAt = deploymentList.DeployedAt
                    };

                    includeProjectId.Add(eachDeployment);
                }

                //Remove projects that do not belong to the projectsList. Sort includeProjectId List as per project and environment
                var finalList = includeProjectId.Where(x => JsonFiles.GetProjectList(dataFiles).Contains(x.ProjectId)).GroupBy(x => new { x.ProjectId, x.EnvironmentId }).ToList();

                //Loop through each project-environment list and pick 'n' releases
                foreach (var eachList in finalList)
                {
                    //Take top 'n' releases
                    var topReleases = eachList.Take(releaseNumber).ToList();
                    //Add each release to the RetainedDeployments list
                    foreach (var releases in topReleases)
                    {
                        RetainedDeployments eachRelease = new()
                        {
                            DeploymentId = releases.DeploymentId,
                            EnvironmentId = releases.EnvironmentId,
                            ProjectId = releases.ProjectId,
                            ReleaseId = releases.ReleaseId,
                            Reason = (releases.ReleaseId + " kept because it was the most recently deployed to \n" + releases.EnvironmentId + " at " + releases.DeployedAt).Trim()
                        };

                        retainedList.Add(eachRelease);
                    }
                }
                retainedList = retainedList.OrderByDescending(x => x.ProjectId).ThenByDescending(x => x.EnvironmentId).ToList();
            }
            return retainedList;
        }
    }
}

