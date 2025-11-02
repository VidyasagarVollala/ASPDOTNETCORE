using Microsoft.AspNetCore.Mvc;

namespace ControllerExample.Models
{
	public class Book
	{
		//[FromQuery]
		public int Id { get; set; }
		public string? Author { get; set; }

		public override string ToString()
		{
			return $"Id {Id} Author {Author}";
		}
	}
}
