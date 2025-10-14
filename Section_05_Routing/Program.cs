namespace Section_05_Routing
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			var app = builder.Build();
			////Routing is automatically enabled.
			////No  need for  app.UseRouting() anymore
			////Endpoints are defined directly on the "app" object

			//app.MapGet("map1", async (context) =>
			//{
			//await	context.Response.WriteAsync("In Map 1");
			//});
			//app.MapPost("map2", async (context) =>
			//{
			//await	context.Response.WriteAsync("In Map 2");
			//});
			////If any request not match it will execute the MapFallback
			//app.MapFallback(async (context) =>
			//{
			//await	context.Response.WriteAsync($"Request received at{context.Request.Path}");
			//});

			//Route Parameteres
			app.MapGet("files/{filename}.{extension}", async (context) =>
			{
				string? filename = Convert.ToString(context.Request.RouteValues["filename"]);
				string? extension = Convert.ToString(context.Request.RouteValues["extension"]);
				await context.Response.WriteAsync($"In Files {filename}.{extension}");
			});

			app.MapGet("Employee/profile/{employeeName}", async (context) =>
			{
				string? employeeName = Convert.ToString(context.Request.RouteValues["employeeName"]);

				await context.Response.WriteAsync($"In Employee Map {employeeName}");
			});
			app.MapFallback(async (context) =>
			{
				await context.Response.WriteAsync($"Request received at{context.Request.Path}");
			});


			app.Run();
		}
	}
}