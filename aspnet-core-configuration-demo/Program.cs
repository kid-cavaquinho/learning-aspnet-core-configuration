using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace aspnet_core_configuration_demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
        }

        ///// <summary>
        ///// Calling the method ```ConfigureAppConfiguration``` after creating the default builder will not replace the default configuration,
        ///// but add another configuration source on top of it.
        ///// </summary>
        ///// <param name="args"></param>
        ///// <returns></returns>
        //public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)
        //    .ConfigureAppConfiguration((builderContext, config) =>
        //    {
        //        config.AddIniFile("appsettings.ini", optional: true, reloadOnChange: true);
        //    })
        //    .UseStartup<Startup>();
    }
}
