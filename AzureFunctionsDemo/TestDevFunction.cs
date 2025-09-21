using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzureFunctionsDemo;

public class TestDevFunction
{
    private readonly ILogger<TestDevFunction> _logger;

    public TestDevFunction(ILogger<TestDevFunction> logger)
    {
        _logger = logger;
    }

    [Function("TestDevFunction")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        return new OkObjectResult("Welcome to Azure Functions!");
    }
}