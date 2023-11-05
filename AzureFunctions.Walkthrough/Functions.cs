using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace AzureFunctions.Walkthrough;

public static class Functions
{
    [Function("HttpFunction")]
    public static async Task<HttpResponseData> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "walkthrough")] 
        HttpRequestData req,
        FunctionContext executionContext)
    {
        var logger = executionContext.GetLogger("HttpFunction");
        logger.LogInformation("C# HTTP trigger function processed a request");

        var response = req.CreateResponse();
        await response.WriteAsJsonAsync(new
        {
            Name = "Azure Function",
            CurrentTime = DateTime.UtcNow
        });

        return response;
        
    }
    
    [Function("CurrentTime")]
    public static async Task<HttpResponseData> RunCurrentTime(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "current-time-utc")] 
        HttpRequestData req,
        FunctionContext executionContext)
    {
        var logger = executionContext.GetLogger("CurrentTime");
        logger.LogInformation("C# HTTP trigger function processed a request");

        var response = req.CreateResponse();
        await response.WriteAsJsonAsync(new
        {
            currentTime = DateTime.UtcNow
        });

        return response;
        
    }
}