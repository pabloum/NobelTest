using Microsoft.Extensions.Configuration;

namespace App
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            var startup = new Startup(configuration);
            startup.ConfigureServices();
            await startup.Run();
        }
    }
}