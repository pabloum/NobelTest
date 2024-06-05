using System.Net.Http.Headers;
using App.Domain;
using App.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceCollection _serviceCollection;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
            _serviceCollection = new ServiceCollection();
        }
        public void ConfigureServices()
        {
            _serviceCollection
                    .AddSingleton(_configuration)
                    .AddHttpClient();
        }

        public async Task Run()
        {
            using (var client = _serviceCollection.BuildServiceProvider().GetRequiredService<HttpClient>())
            {
                var url = _configuration.GetSection("endpointBaseUrl").Value;
                client.BaseAddress = new Uri(url ?? "");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync(Constants.CodingResourcesEndpoint);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<IEnumerable<CodingResources>>();
                    PrintResult(result);
                }
                else
                {
                    Console.WriteLine("Response was not succesfull");
                }
            }
        }

        private void PrintResult(IEnumerable<CodingResources> codingResources)
        {
            var topics = codingResources.SelectMany(x => x.Topics).Distinct();

            foreach (var topic in topics)
            {
                System.Console.WriteLine(topic);
            }
        }
    }
}