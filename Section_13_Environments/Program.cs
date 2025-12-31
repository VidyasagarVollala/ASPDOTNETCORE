namespace Section_13_Environments
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            var app = builder.Build();

            //Environment which get or set the name of the environments by  default it reads the value from the either DOTNET_ENVIRONMENTS OR ASPNETCORE_ENVIRONMENTS
            //Content Path
                //Get or set the absoulte path of the application folder.
            if (app.Environment.IsDevelopment()|| app.Environment.IsStaging() || app.Environment.IsEnvironment("beta"))
                app.UseDeveloperExceptionPage();

            app.UseStaticFiles();
            app.UseRouting();
            app.MapControllers();

            app.Run();
        }
    }
}
