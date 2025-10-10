
namespace Section_4_Middlewares.CustomMiddleware
{
	public class MyCustomeMiddleware : IMiddleware
	{
		public async Task InvokeAsync(HttpContext context, RequestDelegate next)
		{
			await context.Response.WriteAsync("\n customMiddleware Begin");
			await next(context);
			await context.Response.WriteAsync("\n customMiddleware End");
		}

		
	}
	//Here we are extending the IApplicationBuilder object 
	//In program.cs if we go to implementation we can see the WebApplication
	//WebApplication  is the child of IApplicationBuilder so if we extend the IApplicationBuilder automatically that is injected into app object
	public static class CustomMiddlewareExtension
	{
		public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder app)
		{
			return app.UseMiddleware<MyCustomeMiddleware>();
		}
	}
}
