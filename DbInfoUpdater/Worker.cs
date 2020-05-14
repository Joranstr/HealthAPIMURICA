using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DbInfoUpdater
{
    public class Worker : BackgroundService
    {
        private string PreveousDatabase;
        private readonly ILogger<Worker> _logger;
        private HttpClient client;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            client = new HttpClient();
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            client.Dispose();
            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                //_logger.LogInformation("før getasync");
                try
                {
                    var result = await client.GetAsync("http://localhost:44309/api/patients"); //http://www.vg.no https://localhost:44386/index.html

                    if (result.IsSuccessStatusCode)
                    {
                        _logger.LogInformation("The website is up. Status code {StatusCode}", result.StatusCode);
                        var EndringerIDatabase = await result.Content.ReadAsStringAsync();
                        if (PreveousDatabase != EndringerIDatabase)
                        {
                            PreveousDatabase = EndringerIDatabase;
                            _logger.LogInformation("Det har skjedd endringer i databasen");
                        }
                    }
                    else
                    {
                        _logger.LogError("The website is down. Status code {StatusCode}", result.StatusCode);
                    }
                }
                catch (Exception e)
                {
                    _logger.LogInformation(e, "Catch");
                }

                await Task.Delay(2000, stoppingToken);
            }
        }
    }
}
