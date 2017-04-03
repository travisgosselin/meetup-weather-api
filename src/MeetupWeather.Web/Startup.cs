using MeetupWeather.Service.Configuration;
using MeetupWeather.Service.Http;
using MeetupWeather.Service.Meetups;
using MeetupWeather.Service.Weather;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MeetupWeather.Web
{
    /// <summary>
    /// Startup entry point for both lambda and local debugging.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="env">The env.</param>
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public IConfigurationRoot Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            // inject DI on custom services
            services.AddTransient<IMeetupService, MeetupService>();
            services.AddTransient<IHttpClient, HttpClientWrapper>();
            services.AddTransient<IAppSettings, AppSettings>();
            services.AddTransient<IWeatherService, WeatherService>();

            // Add framework services.
            services.AddMvc();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        /// <param name="loggerFactory">The logger factory.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // custom lambda logging - nice to have in code to toggle based on environment variables instead of JSON file.
            loggerFactory.AddLambdaLogger(new LambdaLoggerOptions
            {
                IncludeCategory = true,
                IncludeNewline = true,
                IncludeLogLevel = true,
                Filter = (category, logLevel) => logLevel >= LogLevel.Warning
            });

            // ensure MVC is enabled for Web API usage.
            app.UseMvc();
        }
    }
}
