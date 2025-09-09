using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AzureFunctionsDemo
{
    public class AccessLocSettings
    {
        private readonly ILogger<AccessLocSettings> _logger;
        private readonly IConfiguration _configuration;

        public AccessLocSettings(ILogger<AccessLocSettings> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }  

        [Function("GetExternalServiceURL")]
        public IActionResult GetExternalServiceURL([HttpTrigger(AuthorizationLevel.Function, "get", Route = "externalservice/getexternalserviceurl")] HttpRequest req)
        {
            var externalServiceUrl = Environment.GetEnvironmentVariable("ExternalServiceURL");
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult(externalServiceUrl);
        }

        [Function("WorkWithSqlDBConnectionString")]
        public IActionResult WorkWithSqlDBConnectionString([HttpTrigger(AuthorizationLevel.Function, "get", Route = "connectionstring/getsqlconnectionstring")] HttpRequest req)
        {
            var sqlConnectionString = _configuration.GetConnectionString("SqlConnectionString");
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult(sqlConnectionString);
        }
    }
}
