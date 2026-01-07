using StocksApp.Services;

namespace StocksApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpClient();
            builder.Services.AddScoped<FinhubServices>();
            builder.Services.Configure<TradingOptions>(builder.Configuration.GetSection(nameof(TradingOptions)));//add IOptions<TradingOptions> as a service
            var app = builder.Build();
            app.UseStaticFiles();
            app.UseRouting();
            app.MapControllers();

            app.Run();
        }
    }
}
