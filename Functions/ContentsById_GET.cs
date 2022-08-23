using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace T20.Content.Functions
{
    public static class ContentsById_GET
    {
        [FunctionName("ContentsById_GET")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "contents/{contentType}/{contentTypeId}")] HttpRequest req,
            string contentType, string contentTypeId,
            [CosmosDB(
                databaseName: "%DatabaseName%",
                collectionName: "%ContentCollectionName%",
                ConnectionStringSetting = "CosmosDBConnectionString",
                PreferredLocations = "%PreferredLocations%",
                PartitionKey = "{contentType}",
                Id = "{contentTypeId}"
                )]
            dynamic document,
            ILogger log)
        {
            if (document == null)
                return new NoContentResult();

            return new OkObjectResult(document);
        }
    }
}
