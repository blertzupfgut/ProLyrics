using System;
using System.Collections.Generic;
using System.IO;
using System.Reactive;
using ProLyric.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using SQLite;

namespace ProLyric.ViewModels
{
	public class SongManagerVM : ReactiveObject, IDisposable
	{
		SQLiteConnection db;

		[Reactive] public List<Song> Songs { get; set; } = new List<Song>();
		[Reactive] public List<Author> Authors { get; set; } = new List<Author>();

		public ReactiveCommand<Unit, Unit> AddSong { get; }
		public ReactiveCommand<Unit, Unit> DeleteSong { get; }
		public ReactiveCommand<Unit, Unit> EditSong { get; }

		public SongManagerVM()
        {
			AddSong = ReactiveCommand.Create(addSong);
			DeleteSong = ReactiveCommand.Create(deleteSong);
			EditSong = ReactiveCommand.Create(editSong);

			var dbPath = Path.Combine("D:\\P_Dev\\ProLyric", "ProLyrics.Songs.db");
			if (initDB(dbPath))
				readDB();
		}

		bool initDB(string dbPath)
		{
			if (!File.Exists(dbPath)) {
				db = new SQLiteConnection(dbPath, storeDateTimeAsTicks: false);
				DBInit.Run(db);
			}
			else {
				db = new SQLiteConnection(dbPath, storeDateTimeAsTicks: false);
			}

			return true;
		}

		void readDB()
		{
			foreach (var a in db.Table<Author>())
				Authors.Add(a);

			foreach (var s in db.Table<Song>())
				Songs.Add(s);
		}

		void addSong() {

		}

		void deleteSong()
		{
		}

		void editSong()
		{
		}

		~SongManagerVM()
		{
			Dispose(false);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing) {
				// Free managed resources:
				if (db != null) {
					db.Dispose();
					db = null;
				}
			}

			//// Free native resources if there are any:
			//if (nativeResource != IntPtr.Zero) {
			//	Marshal.FreeHGlobal(nativeResource);
			//	nativeResource = IntPtr.Zero;
			//}
		}
	}
}
