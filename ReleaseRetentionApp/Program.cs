using ReleaseRetention.BLL;
using ReleaseRetention.Entities;
using ReleaseRetention.Utilities;

Console.SetWindowSize(80, 40);

int noOfReleases;
try
{ 
    // validate the input
    bool validInput = int.TryParse(args[0], out noOfReleases);

    if (validInput)
    {
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
                    Console.WriteLine("| " + eachDeployment.ProjectId + " | " + eachDeployment.EnvironmentId + " | \n" + "| " + eachDeployment.ReleaseId + " | " + eachDeployment.DeploymentId + " |\n| Reason: " + eachDeployment.Reason + "\n\n");
                }
            }
            else
                Console.WriteLine("The list returned no data");
        }
        else
        {
            Console.WriteLine("Please use valid Json files");
        }
        Console.ReadLine();
    }
    else
    {
        // if the input is invalid, notify the user
        Console.WriteLine("Invalid input! Please enter a number greater than zero \n");
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

