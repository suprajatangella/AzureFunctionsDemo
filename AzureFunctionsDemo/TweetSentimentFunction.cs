using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AzureFunctionsDemo;

public class TweetSentimentFunction
{
    private readonly ILogger<TweetSentimentFunction> _logger;

    public TweetSentimentFunction(ILogger<TweetSentimentFunction> logger)
    {
        _logger = logger;
    }

    [Function("TweetSentimentFunction")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        string requestBody = String.Empty;
        using (StreamReader streamReader = new StreamReader(req.Body))
        {
            requestBody = await streamReader.ReadToEndAsync();
        }

        dynamic score = JsonConvert.DeserializeObject(requestBody);
        // Fix CS1973: Cast score?.value to a concrete type (e.g., double) before logging
        double? scoreValue = (double?)score?.value;
        _logger.LogInformation("Score: {scoreValue}", scoreValue);

        string value = "Positive";

        if (scoreValue < .3)
        {
            value = "Negative";
        }
        else if (scoreValue < .6)
        {
            value = "Neutral";
        }

        return requestBody != null
            ? (ActionResult)new OkObjectResult(value)
           : new BadRequestObjectResult("Pass a sentiment score in the request body.");
    }
}