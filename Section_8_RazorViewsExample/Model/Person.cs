namespace Section_8_RazorViewsExample.Model
{
	public class Person
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public int Age { get; set; }
		public string? SurName { get; set; }

		public Gender Gender { get; set; }
	}

	public enum Gender
	{
		Male,Female,Other
	}
}
