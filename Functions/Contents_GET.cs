using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using T20.Content.Models;

namespace T20.Content.Functions
{
    public static class Contents_GET
    {
        [FunctionName("Contents_GET")]
        [OpenApiOperation(
            operationId: "Contents_GET",
            tags: new[] { "contents" },
            Visibility = OpenApiVisibilityType.Important)]
        [OpenApiParameter(
            name: "contentType",
            In = Microsoft.OpenApi.Models.ParameterLocation.Path,
            Type = typeof(string),
            Description = "content type",
            Summary = "content type",
            Required = true,
            Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(
            statusCode: HttpStatusCode.OK,
            bodyType: typeof(List<Entity>),
            contentType: "application/json",
            Description = "List of Documents",
            Summary = "OK")]
        [OpenApiResponseWithBody(
            statusCode: HttpStatusCode.NoContent,
            bodyType: typeof(ResponseMessage),
            contentType: "application/json",
            Description = "No Content",
            Summary = "")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "contents/{contentType}")] HttpRequest req,
            string contentType,
            [CosmosDB(
                databaseName: "%DatabaseName%",
                collectionName: "%ContentCollectionName%",
                ConnectionStringSetting = "CosmosDBConnectionString",
                PreferredLocations = "%PreferredLocations%",
                SqlQuery = "select * from c where c.partitionKey = {contentType} and c.visible = true"
                )]
            IEnumerable<Entity> documents,
            ILogger log)
        {
            if (!documents.Any())
                return new NoContentResult();

            return new OkObjectResult(documents);
        }
    }
}
