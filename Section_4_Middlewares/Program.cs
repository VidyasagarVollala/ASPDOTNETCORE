namespace Section_4_Middlewares
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			var app = builder.Build();

			app.Use(async (HttpContext context, RequestDelegate next) =>
			{
				await context.Response.WriteAsync("hello world");
				await next(context);
				await context.Response.WriteAsync("\n hello world from M-1 after next");
			});

			app.Use(async (HttpContext context, RequestDelegate next) =>
			{
				await context.Response.WriteAsync("\n hello world from M-2");
				await next(context);
				await context.Response.WriteAsync("\n hello world from M-2 after next");
			});

			app.Run(async (HttpContext context) =>
			{
				await context.Response.WriteAsync("\n hello world");
			});

			app.Run();
		}
	}
}
