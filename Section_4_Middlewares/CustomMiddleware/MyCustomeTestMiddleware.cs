using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Section_4_Middlewares.CustomMiddleware
{
	// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
	public class MyCustomeTestMiddleware
	{
		private readonly RequestDelegate _next;

		public MyCustomeTestMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public Task Invoke(HttpContext httpContext)
		{
			if (httpContext.Request.Query.ContainsKey("Id"))
				httpContext.Response.WriteAsync($"\n Here Id is {httpContext.Request.Query["Id"]}");

			return _next(httpContext);
		}
	}

	// Extension method used to add the middleware to the HTTP request pipeline.
	public static class MyCustomeTestMiddlewareExtensions
	{
		public static IApplicationBuilder UseMyCustomeTestMiddleware(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<MyCustomeTestMiddleware>();
		}
	}
}
