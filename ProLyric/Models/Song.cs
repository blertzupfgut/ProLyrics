using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLyric.Models
{
	public class Song
	{
		public string Title { get; set; }

		public Song(string title)
		{
			Title = title;
		}
	}
}
