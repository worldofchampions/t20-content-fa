# t20-content-fa

T20 Cricket League Content Azure Function App

## Configuration

The following application settings have to be set to run the function app

| Setting Name                 				|     Setting Type    | Description                                     |
|-------------------------------------------|:-------------------:|-------------------------------------------------|
| DatabaseName					|  string  | Cosmos BD database name/id   |
| CosmosDBConnectionString					|  Connection String  | Cosmos DB connection string   |
| StorageConnectionString					|  Connection String  | Storage account connection for various tables   |
| ContentCollectionName					|  string  | Cosmos DB content container name   |
| PreferredLocations					|  string  | Cosmos DB prefered location   |
| StorageConnectionString					|  Connection String  | Storage account connection for various tables   |
| OpenApi__Info__Title 						|  string             | Content									|
| OpenApi__Info__Description 				|  string             | API to manage Content				|
| OpenApi__Info__Version 					|  string             | v1												|

These settings should be set inside `local.settings.json` file when running locally.

{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet",

    "DatabaseName": "cricketdata",
    "CosmosDBConnectionString": "",
    "ContentCollectionName": "content"
    "PreferredLocations": "UAE North",

    "StorageConnectionString": "",

    "OpenApi__Info__Title": "Content",
    "OpenApi__Info__Description": "API to Manage Content",
    "OpenApi__Info__Version": "v1",
  }
}

There setting can also be download via vs code command palette, press F1 and paste:
Azure Functions: Download Remote Settings....
