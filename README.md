# TestConcordFunctionApp
demonstration of a WCF error in azure function host v2

https://github.com/Azure/azure-functions-host/issues/3568

Sample `local.settings.json`:
```
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "AzureWebJobsDashboard": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet"
  }
}
```
