using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using SQLite;

namespace ProLyric.Models
{
	[Table("Authors")]
	public class Author : ReactiveObject
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		[Reactive] public string FirstName { get; set; }
		[Reactive] public string LastName { get; set; }

		public Author() { }

		public Author(string lastName)
		{
			LastName = lastName;
		}

		public Author(string firstName, string lastName)
		{
			FirstName = firstName;
			LastName = lastName;
		}

	}
}
