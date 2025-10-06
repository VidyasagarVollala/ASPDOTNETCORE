using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using System.Text.Json;

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
				//headers
				//httpContext.Response.ContentType = "text/html";
				//if (httpContext.Request.Headers.ContainsKey("user-agent"))
				//	await httpContext.Response.WriteAsync($"<h1>{httpContext.Request.Headers["user-agent"]}</h1>");
				//headers-With-GET/POST
				//httpContext.Response.ContentType = "text/html";
				//if (httpContext.Request.Headers.ContainsKey("Auth-Key"))
				//	await httpContext.Response.WriteAsync($"<h1>{httpContext.Request.Headers["Auth-Key"]}</h1>");

				StreamReader streamReader = new StreamReader(httpContext.Request.Body);
				string stream = await streamReader.ReadToEndAsync();
				Dictionary<string, StringValues> dictionary = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(stream);

				if (dictionary.Count > 0 || dictionary != null)
				{
					//foreach (var kvp in dictionary)
						await httpContext.Response.WriteAsync(JsonSerializer.Serialize(dictionary));
				}
			});
			app.Run();

		}
	}
}

