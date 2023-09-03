using System;

namespace ReleaseRetention.Entities
{
    public class Releases
    {
        public string Id { get; set; }
        public string ProjectId { get; set; }
        public string Version { get; set; }
        public DateTime Created { get; set; }
    }
}
