using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;

namespace BlazorApp.Api
{
    public class NewsProxyFunction
    {
        private readonly HttpClient httpClient;

        public NewsProxyFunction(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        [FunctionName("News")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            // var queryString = req.QueryString;
            
            var response = await httpClient.GetAsync("https://www.motorsport.com/rss/f1/news/");
            var content = await response.Content.ReadAsStringAsync();

            var result = new ContentResult
            {
                Content = content,
                ContentType = response.Content.Headers.ContentType.ToString(),
                StatusCode = (int) response.StatusCode
            };

            return result;

            /*req.HttpContext.Response.StatusCode = (int)response.StatusCode
            req.HttpContext.Response.ContentType = response.Content.Headers.ContentType.ToString();
            req.HttpContext.Response.ContentLength = response.Content.Headers.ContentLength;

            await req.HttpContext.Response.WriteAsync(content);*/
        }
    }
}
