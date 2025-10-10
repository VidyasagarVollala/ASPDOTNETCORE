using Section_4_Middlewares.CustomMiddleware;

namespace Section_4_Middlewares
{
	public class Program
	{
		public static void Main(string[] args)
		{

			//Custom-Middleware-example
			//var builder = WebApplication.CreateBuilder(args);
			//builder.Services.AddTransient<MyCustomeMiddleware>();
			//var app = builder.Build();

			//app.Use(async (HttpContext context, RequestDelegate next) =>
			//{
			//	await context.Response.WriteAsync("hello world");
			//	await next(context);
			//	await context.Response.WriteAsync("\n hello world from M-1 after next");
			//});

			//app.UseMiddleware<MyCustomeMiddleware>();

			////app.Use(async (HttpContext context, RequestDelegate next) =>
			////{
			////	await context.Response.WriteAsync("\n hello world from M-2");
			////	await next(context);
			////	await context.Response.WriteAsync("\n hello world from M-2 after next");
			////});

			//app.Run(async (HttpContext context) =>
			//{
			//	await context.Response.WriteAsync("\n hello world from RUN");
			//});
			//app.Run();


			////Custome Middelware with Extension

			//var builder = WebApplication.CreateBuilder(args);
			//builder.Services.AddTransient<MyCustomeMiddleware>();
			//var app = builder.Build();

			//app.Use(async (HttpContext context, RequestDelegate next) =>
			//{
			//	await context.Response.WriteAsync("hello world");
			//	await next(context);
			//	await context.Response.WriteAsync("\n hello world from M-1 after next");
			//});


			//app.UseMyCustomMiddleware();
			//app.Run(async (HttpContext context) =>
			//{
			//	await context.Response.WriteAsync("\n hello world from RUN");
			//});
			//app.Run();



			//Custome Middelware with Conventional method

			//var builder = WebApplication.CreateBuilder(args);

			//var app = builder.Build();

			//app.Use(async (HttpContext context, RequestDelegate next) =>
			//{
			//	await context.Response.WriteAsync("hello world");
			//	await next(context);
			//	await context.Response.WriteAsync("\n hello world from M-1 after next");
			//});


			//app.UseMyCustomeTestMiddleware();
			//app.Run(async (HttpContext context) =>
			//{
			//	await context.Response.WriteAsync("\n hello world from RUN");
			//});


			//UseWhen Example

			var builder = WebApplication.CreateBuilder(args);
			var app = builder.Build();
			app.UseWhen((HttpContext context) => context.Request.Query.ContainsKey("id"), async app =>
			{
				app.Use(async (HttpContext context, RequestDelegate next) =>
				{
					await context.Response.WriteAsync("hello from chain");
					await next(context);
				});
			});

			app.Run(async (HttpContext context) =>
			{
				await context.Response.WriteAsync("Hello from Main Midd");
			});


			app.Run();





		}
	}
}
