using ReleaseRetention.Entities;

namespace ReleaseRetention.BLL
{
    public class Rules
    {       
        public static List<RetainedDeployments> ApplyReleaseRetention(ListOfJsonData dataFiles, int releaseNumber)
        {
            List<RetainedDeployments> includeProjectId = new List<RetainedDeployments>();
            List<RetainedDeployments> retainedList = new List<RetainedDeployments>();

            //Comma separated Project Id list
            string commaSeparatedProjectIds = string.Join(",", dataFiles.Projects.Select(x => x.Id));
            //Comma separated Environment Id list
            string commaSeparatedEnvironmentIds = string.Join(",", dataFiles.Environments.Select(x => x.Id));

            //Remove Deployments not present in EnvironmentList
            var cleanAndSortedDeploymentList = dataFiles.Deployments.Where(x => commaSeparatedEnvironmentIds.Contains(x.EnvironmentId)).OrderByDescending(x => x.DeployedAt);

            //Add projectId to RetainedDeployments list
            foreach (Deployments deploymentList in cleanAndSortedDeploymentList)
            {
                RetainedDeployments eachDeployment = new RetainedDeployments();
                
                eachDeployment.ReleaseId = deploymentList.ReleaseId;
                eachDeployment.EnvironmentId = deploymentList.EnvironmentId;
                eachDeployment.ProjectId = dataFiles.Releases.Where(x => x.Id.Equals(eachDeployment.ReleaseId, StringComparison.Ordinal)).Select(x => x.ProjectId).FirstOrDefault();
                eachDeployment.DeploymentId = deploymentList.Id;
                eachDeployment.DeployedAt = deploymentList.DeployedAt;

                includeProjectId.Add(eachDeployment);               
            }

            //Remove projects that do not belong to the projectsList. Sort includeProjectId List as per project and environment
            var finalList = includeProjectId.Where(x => commaSeparatedProjectIds.Contains(x.ProjectId)).GroupBy(x => new { x.ProjectId, x.EnvironmentId }).ToList();

            //Loop through each project-environment list and pick 'n' releases
            foreach(var eachList in finalList)
            {
                //Take top 'n' releases
                var topReleases = eachList.Take(releaseNumber).ToList();
                //Add each release to the RetainedDeployments list
                foreach (var releases in topReleases)
                {
                    RetainedDeployments eachRelease = new RetainedDeployments();

                    eachRelease.DeploymentId = releases.DeploymentId;
                    eachRelease.EnvironmentId = releases.EnvironmentId;
                    eachRelease.ProjectId = releases.ProjectId;
                    eachRelease.ReleaseId = releases.ReleaseId;
                    eachRelease.Reason = releases.ReleaseId + " kept because it was the most recently deployed to \n" + releases.EnvironmentId + " at " + releases.DeployedAt;

                    retainedList.Add(eachRelease);
                }
            }
            retainedList = retainedList.OrderByDescending(x => x.ProjectId).ThenByDescending(x => x.EnvironmentId).ToList();
            return retainedList;                  
        }
    }
}

