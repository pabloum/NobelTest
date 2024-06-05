using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceCollection _serviceProvider;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
            _serviceProvider = new ServiceCollection();
        }
        public IServiceProvider ConfigureServices()
        {
            return _serviceProvider.BuildServiceProvider();
        }

        public void Run()
        {
            var url = _configuration.GetSection("endpoint");
            System.Console.WriteLine($"the url is {url}");
        }
    }
}