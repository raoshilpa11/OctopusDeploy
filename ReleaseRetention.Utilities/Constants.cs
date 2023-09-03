using System.Configuration;

namespace ReleaseRetention.Utilities
{
    public class Filename
    {
        public static string Release = "Releases.json";
        public static string Project = "Projects.json";
        public static string Environment = "Environments.json";
        public static string Deployment = "Deployments.json";
    }
    
    public class URL
    {
        public static string JSON_FilePath = ConfigurationManager.AppSettings["JSON_FilePath"];
    }
}

