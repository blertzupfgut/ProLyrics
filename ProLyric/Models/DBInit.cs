using SQLite;
using SQLiteNetExtensions.Attributes;
using SQLiteNetExtensions.Extensions;

namespace ProLyric.Models
{
	public static class DBInit
	{
		static Author author1 = new Author("Vineyard");
		static Author author2 = new Author("Michael", "Frye");

		public static void Run(SQLiteConnection db)
		{
			initSchema(db);
			initAuthors(db);
			initSongs(db);

		}

		static void initSchema(SQLiteConnection db)
		{
			db.CreateTable<Song>();
			db.CreateTable<Author>();
			db.CreateTable<SongAuthor>();
		}

		static void initAuthors(SQLiteConnection db)
		{
			db.Insert(author1);
			db.Insert(author2);
		}

		static void initSongs(SQLiteConnection db)
		{
			var s1 = new Song("All creation") {
				Lyrics = @"We come to You with a heart of thanks, 
for your love
To be a living sacrifice, 
brought with love
We come to You with a heart of thanks, 
for Your love
An offering of all we are, 
brought with love

All creation, looks to You
All provision, comes from You
In every sunrise, hope shines through
For Your mercy, we thank You

We come to You with a song of praise, 
for Your love
The music of our soul's delight, 
brought with love
We come to You with a song of praise,
for Your love
Sounds of joy and gratefulness, 
brought with love

All creation, looks to You
All provision, comes from You
In every sunrise, hope shines through
For Your mercy, we thank You

... Instrumental ...

All creation looks to You
All provision comes from You
In every rhythm we thank You
For Your love

...
All creation looks to You
All provision comes from You
In every rhythm we thank You
For Your love

All creation looks to You
All provision comes from You
In every season we thank You
For Your love

All creation, looks to You
All provision, comes from You
In every sunrise, hope shines through
For Your mercy, we thank You

...
All creation, looks to You
All provision, comes from You
In every sunrise, hope shines through
For Your mercy, we thank You
"
			};
			db.Insert(s1);

			s1.Authors.Add(author1);
			db.UpdateWithChildren(s1);

			var s2 = new Song("Be the center") {
				Lyrics = @"Jesus be the centre,
be my source, be my light Jesus.
Jesus be the centre,
be my hope, be my song Jesus.

Be the fire in my heart,
Be the wind in these sails.
Be the reason that I live,
Jesus, Jesus.

Jesus be my vision,
be my path, be my guide Jesus.

Be the fire in my heart,
Be the wind in these sails.
Be the reason that I live,
Jesus, Jesus.

Jesus, sei das Zentrum, 
sei mein Halt und mein Licht, Jesus.
Jesus, sei das Zentrum, 
sei meine Kraft und mein Lied, Jesus.

Sei das Feuer tief in mir,
sei der Wind, der mich führt,
sei mein Leben und mein Ziel.
Jesus, Jesus.

Jesus, sei meine Hoffnung,
meine Vision und mein Weg.
Jesus.
"
			};
			db.Insert(s2);

			s2.Authors.Add(author2);
			db.UpdateWithChildren(s2);
		}
	}
}
