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
using System.Threading.Tasks;
using T20.Content.Models;

namespace T20.Content.Functions
{
    public static class TeamPage_GET
    {
        [FunctionName("TeamPage_GET")]
        [OpenApiOperation(
            operationId: "TeamPage_GET",
            tags: new[] { "teamPage" },
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
            bodyType: typeof(List<TeamPageEnvelope>),
            contentType: "application/json",
            Description = "List of Team Pages",
            Summary = "OK")]
        [OpenApiResponseWithBody(
            statusCode: HttpStatusCode.NoContent,
            bodyType: typeof(ResponseMessage),
            contentType: "application/json",
            Description = "No Content",
            Summary = "")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "content/teamPage")] HttpRequest req,
            [CosmosDB(
                databaseName: "%DatabaseName%",
                collectionName: "%ContentCollectionName%",
                ConnectionStringSetting = "CosmosDBConnectionString",
                PreferredLocations = "%PreferredLocations%",
                SqlQuery = "select * from c where c.partitionKey = 'teamPage' and c.visible = true"
                )]
            IEnumerable<TeamPageEnvelope> documents,
            ILogger log)
        {
            if (!documents.Any())
                return new NoContentResult();

            return new OkObjectResult(documents);
        }
    }
}
