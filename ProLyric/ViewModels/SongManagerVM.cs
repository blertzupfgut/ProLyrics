using System.Collections.Generic;
using System.Diagnostics;
using System.Reactive;
using ProLyric.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ProLyric.ViewModels
{
	public class SongManagerVM : ReactiveObject
    {
		[Reactive] public List<Song> Songs { get; set; } = new List<Song>();

		public ReactiveCommand<Unit, Unit> AddSong { get; }
		public ReactiveCommand<Unit, Unit> DeleteSong { get; }
		public ReactiveCommand<Unit, Unit> EditSong { get; }

		public SongManagerVM()
        {
			AddSong = ReactiveCommand.Create(addSong);
			DeleteSong = ReactiveCommand.Create(deleteSong);
			EditSong = ReactiveCommand.Create(editSong);

			readSongsFromDB();
		}

		void readSongsFromDB()
		{
			Songs.Add(new Song("All creation"));
			Songs.Add(new Song("All that I need"));
			Songs.Add(new Song("History Maker"));
		}

		void addSong() {
			Debug.WriteLine("Add song");
		}
		
		void deleteSong() { }
		
		void editSong() { }
	}
}
