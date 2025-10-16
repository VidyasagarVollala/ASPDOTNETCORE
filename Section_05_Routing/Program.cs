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

			////Route Parameteres
			//app.Map("files/{filename}.{extension}", async (context) =>
			//{
			//	string? filename = Convert.ToString(context.Request.RouteValues["filename"]);
			//	string? extension = Convert.ToString(context.Request.RouteValues["extension"]);
			//	await context.Response.WriteAsync($"In Files {filename}.{extension}");
			//});

			////URL :localhost/Employee/profile/Vidyasagar
			//app.Map("Employee/profile/{employeeName}", async (context) =>
			//{
			//	string? employeeName = Convert.ToString(context.Request.RouteValues["employeeName"]);
				
			//	await context.Response.WriteAsync($"In From  Map {employeeName}");
			//});
			////URL :localhost/employee?Ename=Vidyasagar
			//app.MapGet("employee", async (context) =>
			//{
				
			//	await context.Response.WriteAsync($"In from query string Map {context.Request.Query["EName"]}");
			//});
			//app.MapFallback(async (context) =>
			//{
			//	await context.Response.WriteAsync($"Request received at{context.Request.Path}");
			//});




			////Default Parameteres
			//app.Map("employee/{id=3}", async (context) =>
			//{
			//	string? id = Convert.ToString(context.Request.RouteValues["id"]);
			//	await context.Response.WriteAsync($"Employee Id is {id}");
			//});

			//app.MapFallback(async (context) =>
			//{
			//	await context.Response.WriteAsync($"Request received at{context.Request.Path}");
			//});



			//Optional Parameteres
			app.Map("student/{id?}", async (context) =>
			{
				if (context.Request.RouteValues.ContainsKey("id"))
				{
					string? id = Convert.ToString(context.Request.RouteValues["id"]);
					await context.Response.WriteAsync($"Student Id is {id}");
				}
				else
				{
					await context.Response.WriteAsync($"Student Id is Not supplied");
				}
			});

			app.MapFallback(async (context) =>
			{
				await context.Response.WriteAsync($"Request received at{context.Request.Path}");
			});


			app.Run();
		}
	}
}