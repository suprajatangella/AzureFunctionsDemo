using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzureFunctionsDemo
{
    public class UserInfo
    {
        private readonly ILogger<UserInfo> _logger;

        public UserInfo(ILogger<UserInfo> logger)
        {
            _logger = logger;
        }

        [Function("GetUserInfo")]
        public IActionResult GetUserInfo([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult("Supraja Tangella");
        }

        [Function("GetAllUsers")]
        public IActionResult GetAllUsers([HttpTrigger(AuthorizationLevel.Function, "get", Route = "user/getallusers")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult("Supraja Tangella, Mounika Chittemsetty");
        }
    }
}
