using Microsoft.Extensions.Configuration;
using System;

namespace Section_14_Configuration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            //Supply  an object of WeatherApi(with 'weatherapi' section) as a service
            builder.Services.Configure<WeatherApiOption>(builder.Configuration.GetSection("WeatherAPI"));

            //Loading MyOwnConfig.json
            builder.Host.ConfigureAppConfiguration((hostcontext, config) =>
            {
                config.AddJsonFile("MyOwnConfigFile.json", optional: true, reloadOnChange: true);
            });
            var app = builder.Build();

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {

                endpoints.Map("/config", async context =>
                {
                    // await context.Response.WriteAsync(app.Configuration["MyKey"]);

                    await context.Response.WriteAsync(app.Configuration.GetValue<string>("MyKey") + "\n");

                    await context.Response.WriteAsync(app.Configuration.GetValue<int>("X", 10) + "\n");

                 


                });
            });
            app.MapControllers();

            app.Run();
        }
    }
}

