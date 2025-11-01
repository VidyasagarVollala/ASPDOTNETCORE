using ControllerExample.Controllers;

namespace ControllerExample
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			//in real world we have lot of controllers so instead of registering every controller as service so it can participate in dependency injection like this we can use below method
			//builder.Services.AddTransient<HomeController>();
			//A service class is resuable class
			//In asp core controllers also treated as services

			
			builder.Services.AddControllers();
			//Adds the all controllers as in the IServiceCollection.So that they can be accessed when a specific endpoint need it
			// with this asp.dotnet core willl detects the all controllers- What are classes suffix with controller it will add
			//Adds the all the controller classes as services



			var app = builder.Build();

			app.MapControllers();
			//Adds all actions methods as endpoints. So that no need of using UseEndpoints() method for adding the action methods as endpoints
			//It will detects the all controllers of enitre project and it will pick up all action methods and routing will be adding at a time.by this

			//app.UseRouting();
			app.UseStaticFiles();
			app.Run();
		}
	}
}
