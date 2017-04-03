using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace MeetupWeather.Web
{
    /// <summary>
    /// Standard program entry point for local and asp.net bootstrapping.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method for bootstrapping during local development.
        /// </summary>
        /// <param name="args">args passed to the main function.</param>
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
