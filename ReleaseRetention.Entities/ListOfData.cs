using System.Collections.Generic;

namespace ReleaseRetention.Entities
{
    public class ListOfJsonData
    {
        public List<Deployments>? Deployments { get; set; }
        public List<Releases>? Releases { get; set; }
        public List<Projects>? Projects { get; set; }
        public List<Environments>? Environments { get; set; }
    }
}
