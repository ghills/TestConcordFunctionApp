using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using ServiceReference1;
using System;
using System.Threading.Tasks;

namespace TestConcordFunctionApp
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task Run([TimerTrigger("0 */5 * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            var request = new GetInboundItemListRequest1
            {
                request = new GetInboundItemListRequest
                {
                    ArchivedItems = false
                },
                authentication = new Authentication
                {
                    UserId = "probably wont matter",
                    Password = "failure comes before authentication"
                }
            };

            var client = new InboundWSSoapClient(InboundWSSoapClient.EndpointConfiguration.InboundWSSoap12);
            var response = await client.GetInboundItemListAsync(request.authentication, request.request);

            log.LogInformation("Success? {wasSuccess}", response?.GetInboundItemListResult?.Success);
        }
    }
}
