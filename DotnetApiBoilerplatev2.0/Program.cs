using Serilog;

namespace DotnetApiBoilerplatev2._0
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
             .UseKestrel()
             .UseContentRoot(Directory.GetCurrentDirectory())
             .ConfigureAppConfiguration((hostingContext, config) =>
             {
                 var env = hostingContext.HostingEnvironment;
                 config.AddJsonFile("Config/appsettings.json", optional: true, reloadOnChange: true);
                 config.AddJsonFile("Secrets/secrets.json", optional: false, reloadOnChange: true);
                 config.AddEnvironmentVariables();
             })
             .ConfigureLogging((hostingContext, logging) =>
             {
                 logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                 logging.AddSerilog(dispose: true);
             })
             .UseStartup<Startup>()
             .Build();

            host.Run();

        }
    }
}
