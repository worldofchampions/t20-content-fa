using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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
            name: "userId",
            In = Microsoft.OpenApi.Models.ParameterLocation.Path,
            Type = typeof(string),
            Description = "user identifier",
            Summary = "user identifier",
            Required = true,
            Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(
            statusCode: HttpStatusCode.OK,
            bodyType: typeof(List<NotificationEnvelope>),
            contentType: "application/json",
            Description = "List of Notification Envelope",
            Summary = "OK")]
        [OpenApiResponseWithBody(
            statusCode: HttpStatusCode.BadRequest,
            bodyType: typeof(ResponseMessage),
            contentType: "application/json",
            Description = "Bad Request",
            Summary = "")]
        [OpenApiResponseWithBody(
            statusCode: HttpStatusCode.Forbidden,
            contentType: "application/json",
            bodyType: typeof(ResponseMessage),
            Description = "The Forbidden response")]
        [OpenApiResponseWithBody(
            statusCode: HttpStatusCode.Unauthorized,
            contentType: "application/json",
            bodyType: typeof(ResponseMessage),
            Description = "The Unauthorized response")]
        [OpenApiSecurity("oidc_auth",
            SecuritySchemeType.OpenIdConnect,
            OpenIdConnectUrl = "https://fidm.eu1.gigya.com/oidc/op/v1.0/3_BvA3VlTvrwSX1WhYFItrqeg1_mIU796DfEaXSRI4U3CeoUhQeQ_K0N9Zswq5nFeW/.well-known/openid-configuration",
            OpenIdConnectScopes = "openid,profile,email,phone,address")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "contents/{contentType}")] HttpRequest req,
            string contentType,
            [CosmosDB(
                databaseName: "%DatabaseName%",
                collectionName: "%ContentCollectionName%",
                ConnectionStringSetting = "CosmosDBConnectionString",
                PreferredLocations = "%PreferredLocations%",
                SqlQuery = "select * from c where c.partitionKey = {contentType}"
                )]
            IEnumerable<dynamic> documents,
            ILogger log)
        {
            if (!documents.Any())
                return new NoContentResult();

            return new OkObjectResult(documents);
        }
    }
}
