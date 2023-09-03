using ReleaseRetention.BLL;
using ReleaseRetention.Entities;
using ReleaseRetention.Utilities;

namespace ReleaseRetentionApp
{
    class Program
    {
        static void Main(string[] args)
        {
           var noOfReleases = 0;
            var validInput = false;

            // loop until you have valid input
            while (!validInput)
                {                  
                    // validate the input
                    validInput = int.TryParse(args[0], out noOfReleases);

                    // if the input is invalid, notify the user
                    if (!validInput)
                    {
                        Console.WriteLine("Invalid input! Please enter a number greater than zero \n");
                    }
                }
                //Deserialise Json files
                ListOfJsonData listOfData = JsonFiles.Deserialise(URL.JSON_FilePath);

            if (listOfData.Deployments != null && listOfData.Releases != null && listOfData.Projects != null && listOfData.Environments != null)
            {
                List<RetainedDeployments> retainedList = Rules.ApplyReleaseRetention(listOfData, noOfReleases);

                if (retainedList.Count != 0)
                {
                    //Print retained list on the console
                    foreach (RetainedDeployments eachDeployment in retainedList)
                    {
                        Console.BufferHeight = Int16.MaxValue - 1;
                        Console.WriteLine("| " + eachDeployment.ProjectId + " | " + eachDeployment.EnvironmentId + " | \n" + "| " + eachDeployment.ReleaseId + " | " + eachDeployment.DeploymentId + " |\n| Reason: " + eachDeployment.Reason + "\n\n");                   
                    }
                }
                else
                    Console.WriteLine("The list returned no data");

                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Please use valid Json files");
                Console.ReadLine();
            }
        }
    }
}
