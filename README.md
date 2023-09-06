# ReleaseRetentionApp

Created a console app that accepts one parameter.
The parameter is validated to check if it's an integer.
No UI, CLI, or database has been used. Final output and error messages are diplayed on a command prompt.
Basic exception handling has been added.
Before running the project, change the path of JSON files in App.config and test cases to the path it is locally present.

Assumptions -
All releases should have projects that are present in the Project list else that release will be deleted.
All deployments should have environments that are present in the Environment list else that deployment will be deleted.

If number of releases supplied is 2, then top 2 latest releases for every project - environment combination is displayed as final output.
