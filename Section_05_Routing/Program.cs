using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System;

namespace Section_05_Routing
{
	public class Program
	{
		public static void Main(string[] args)
		{
			//var builder = WebApplication.CreateBuilder(args);
			//var app = builder.Build();


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
			//app.Map("student/{id?}", async (context) =>
			//{
			//	if (context.Request.RouteValues.ContainsKey("id"))
			//	{
			//		string? id = Convert.ToString(context.Request.RouteValues["id"]);
			//		await context.Response.WriteAsync($"Student Id is {id}");
			//	}
			//	else
			//	{
			//		await context.Response.WriteAsync($"Student Id is Not supplied");
			//	}
			//});


			////Routing Constraints 
			//app.Map("student/{id:int?}", async (context) =>
			//{
			//	if (context.Request.RouteValues.ContainsKey("id"))
			//	{
			//		string? id = Convert.ToString(context.Request.RouteValues["id"]);
			//		await context.Response.WriteAsync($"Student Id is {id}");
			//	}
			//	else
			//	{
			//		await context.Response.WriteAsync($"Student Id is Not supplied");
			//	}
			//});

			//app.Map("daily-report/{date:datetime}", async (context) =>
			//{
			//	if (context.Request.RouteValues.ContainsKey("date"))
			//	{
			//		DateTime? dateReport = Convert.ToDateTime(context.Request.RouteValues["date"]);
			//		await context.Response.WriteAsync($"Report for the date {dateReport}");
			//	}
			//	else
			//	{
			//		await context.Response.WriteAsync($"No report found");
			//	}
			//});


			//app.Map("cities/{cityId:guid}", async (context) =>
			//{
			//	if (context.Request.RouteValues.ContainsKey("cityId"))
			//	{
			//		Guid? cituNumber = Guid.Parse(Convert.ToString(context.Request.RouteValues["cityId"])!);
			//		await context.Response.WriteAsync($"Report for the date {cituNumber}");
			//	}
			//	else
			//	{
			//		await context.Response.WriteAsync($"No report found");
			//	}
			//});

			//minlength
			//maxlenth
			//length(Min,Max)

			//app.Map("cities/{cityId:minlength(3)}", async (context) =>
			//app.Map("cities/{cityId:maxlenth(6)}", async (context) =>
			//app.Map("cities/{cityId:minlength(3):maxlength(4)}", async (context) =>
			//app.Map("cities/{cityId:length(3,5)}", async (context) =>

			//int Matches 32 - bit integers { id: int}
			//bool Matches true or false   { active: bool}
			//datetime Matches DateTime values { date: datetime}
			//decimal Matches decimal numbers { price: decimal}
			//double Matches double values   { value: double}
			//float Matches float values    { rate: float}
			//guid Matches GUIDs   { id: guid}
			//length(n)   Exact length    { name: length(5)}
			//minlength(n)    Minimum length  { name: minlength(3)}
			//maxlength(n)    Maximum length  { name: maxlength(10)}
			//min(n)  Minimum numeric value   { age: min(18)}
			//max(n)  Maximum numeric value   { age: max(65)}
			//range(min, max)  Numeric range   { score: range(1, 100)}
			//alpha Letters only(a - z, A - Z) { name: alpha}
			//regex(expression)   Custom regex match  { zip: regex(^\\d{ { 5} }$)}

			//It will look for files in wwwroot folder
			//app.UseStaticFiles();   //Works with web root path

			//In the place of wwwroot folder we create the our new folder but it should configure in the request

			var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
			{
				WebRootPath ="MyFolder"
			});

			var app = builder.Build();

			//ContentRootPath --By deafult represent the working path.  F:\ASPDOTNETCORE\Section_05_Routing\Section_05_Routing.sln

			app.MapGet("path", async (context) =>
			{
				await context.Response.WriteAsync("testing post method");
			});


			app.Run();
		}
	}
}