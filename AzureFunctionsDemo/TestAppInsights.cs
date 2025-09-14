using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AzureFunctionsDemo;

public class TestAppInsights
{
    private readonly ILogger<TestAppInsights> _logger;

    public TestAppInsights(ILogger<TestAppInsights> logger)
    {
        _logger = logger;
    }

    [Function("CheckErrorInAppInsights")]
    public IActionResult CheckErrorInAppInsights([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req)
    {
        var str = "This is a String";
        int number = Convert.ToInt32(str);
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        return new OkObjectResult("Can't convert from string to int");
    }

    [Function("CheckPerfOfFunction")]
    public async Task<IActionResult> CheckPerfOfFunction([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req)
    {
        await Task.Delay(TimeSpan.FromSeconds(10));
        return new OkObjectResult("The function is delayed for 10+ seconds");
    }
}