using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace My.Function
{
    public class HttpExample
    {
        private readonly ILogger<HttpExample> _logger;

        public HttpExample(ILogger<HttpExample> logger)
        {
            _logger = logger;
        }

        [Function("HttpExample")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            var test  = req.Headers.UserAgent;
            if(test.Contains("Safari"))
            {
                _logger.LogInformation("Its a mac browser");
                return new OkObjectResult("Download for mac os");
            }
            else 
            {
                 _logger.LogInformation("Its not a mac browser");
                return new OkObjectResult("Download for other os");

             //_logger.LogInformation("C# HTTP trigger function processed a request.");
            //return new OkObjectResult("Welcome to Azure Functions!");
            }
        }
    }
}
