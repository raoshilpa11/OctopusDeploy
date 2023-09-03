using System;

namespace ReleaseRetention.Entities
{
    public class RetainedDeployments
    {
        public string DeploymentId { get; set; }
        public string ReleaseId { get; set; }
        public string ProjectId { get; set; }
        public string EnvironmentId { get; set; }
        public DateTime DeployedAt { get; set; }
        public string Reason { get; set; }
    }
}
