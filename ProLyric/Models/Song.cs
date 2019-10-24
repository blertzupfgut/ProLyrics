using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ProLyric.Models
{
	[Table("Songs")]
	public class Song : ReactiveObject
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		[NotNull]
		[Reactive] public string Title { get; set; }

		[Reactive] public string Title2 { get; set; }

		[Reactive] public string Lyrics { get; set; }

		[Reactive] public string VerseOrder { get; set; }

		[Reactive] public string Translation { get; set; }

		[ManyToMany(typeof(SongAuthor))]
		[Reactive] public List<Author> Authors { get; set; } = new List<Author>();

		[Reactive] public string Copyright { get; set; }

		[Reactive] public string CCLI { get; set; }

		//[ForeignKey(typeof(Design))]
		//public int DesignID { get; set; }

		//[ManyToOne]
		//public Design Design { get; set; }

		[Reactive] public string DesignID { get; set; }

		[Ignore]
		public Design Design {
			get => Designs.Find(DesignID);
			set => DesignID = Design.ID;
		}

		[NotNull]
		[Reactive] public DateTime CreatedAt { get; set; }

		[NotNull]
		[Reactive] public DateTime UpdatedAt { get; set; }

		//[Ignore]
		//public string Label { [ObservableAsProperty]get; }

		public Song()
		{
			//this.WhenAnyValue(x => x.Title, x => x.Authors)
			//	.Select(x => x.Item1 + " (" + x.Item2[0] + ")")
			//	.ToPropertyEx(this, x => x.Label);
		}

		public Song(string title)
		{
			Title = title;
			CreatedAt = DateTime.Now;
			UpdatedAt = DateTime.Now;
		}
	}

	[Table("SongAuthors")]
	public class SongAuthor
	{
		[ForeignKey(typeof(Song))]
		public int SongID { get; set; }

		[ForeignKey(typeof(Author))]
		public int AuthorID { get; set; }
	}
}
