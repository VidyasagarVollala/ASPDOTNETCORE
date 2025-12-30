using Section_12_Services;
using ServiceContracts;

namespace Section_12_DI_Example
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            // builder.Services.Add(new ServiceDescriptor(typeof(ICitiesServices), typeof(CitiesServices), ServiceLifetime.Transient));

            builder.Services.AddScoped<ICitiesServices, CitiesServices>();
            var app = builder.Build();
              
           app.UseStaticFiles();
            app.UseRouting();
            app.MapControllers();   
              
            app.Run();
        }
    }
}
