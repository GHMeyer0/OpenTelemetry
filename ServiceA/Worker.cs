using Microsoft.Extensions.Hosting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceA
{
    public class Worker : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var client = new RestClient("http://serviceb/values");
                var request = new RestRequest();
                var response = client.Post(request);
                await Task.Delay(30000, stoppingToken);
            }
        }
    }
}
