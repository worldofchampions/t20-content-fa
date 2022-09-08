using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using System.Net;
using T20.Content.Models;

namespace T20.Content.Functions
{
    public static class ContentsById_GET
    {
        [FunctionName("ContentsById_GET")]
        [OpenApiOperation(
            operationId: "ContentsById_GET",
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
        [OpenApiParameter(
            name: "contentTypeId",
            In = Microsoft.OpenApi.Models.ParameterLocation.Path,
            Type = typeof(string),
            Description = "content type identifier",
            Summary = "content type identifier",
            Required = true,
            Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(
            statusCode: HttpStatusCode.OK,
            bodyType: typeof(Entity),
            contentType: "application/json",
            Description = "Single Document",
            Summary = "OK")]
        [OpenApiResponseWithBody(
            statusCode: HttpStatusCode.NoContent,
            bodyType: typeof(ResponseMessage),
            contentType: "application/json",
            Description = "No Content",
            Summary = "")]
        public static IActionResult Run(
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
            Entity document,
            ILogger log)
        {
            if (!(document?.Visible ?? false))
                return new NoContentResult();

            return new OkObjectResult(document);
        }
    }
}
