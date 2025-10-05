namespace SECTION_1
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			var app = builder.Build();

			app.Run(async (HttpContext httpContext) =>
			{

				//Response
				//httpContext.Response.StatusCode = 500;
				//httpContext.Response.Headers["MyKey"] = "MySecreat_Key";
				//httpContext.Response.ContentType = "text/html";
				//await httpContext.Response.WriteAsync("<h3>Hello</h3>");
				//await httpContext.Response.WriteAsync(" DotnetCore World");

				//Request
				//httpContext.Response.ContentType = "text/html";
				//await httpContext.Response.WriteAsync($"<h3>{httpContext.Request.Path}</h3>");

				//QueryString
				//httpContext.Response.ContentType = "text/html";
				//if(httpContext.Request.Method =="GET")
				//{
				//	if (httpContext.Request.Query.ContainsKey("id"))
				//		await httpContext.Response.WriteAsync($"<h2>{httpContext.Request.Query["id"]}</h2>");
				//}
				httpContext.Response.ContentType = "text/html";
				if (httpContext.Request.Headers.ContainsKey("user-agent"))
					await httpContext.Response.WriteAsync($"<h1>{httpContext.Request.Headers["user-agent"]}</h1>");
				
			});
			app.Run();

		}
	}
}
	
