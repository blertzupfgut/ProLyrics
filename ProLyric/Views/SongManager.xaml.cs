using System.Reactive.Disposables;
using ProLyric.ViewModels;
using ReactiveUI;

namespace ProLyric.Views
{
	public partial class SongManager : ReactiveUserControl<SongManagerVM>
	{
		public SongManager()
		{
			InitializeComponent();
			ViewModel = new SongManagerVM();

			this.WhenActivated(d => {
				this.OneWayBind(ViewModel, vm => vm.Songs, v => v.SongList.ItemsSource).DisposeWith(d);

				this.BindCommand(ViewModel, vm => vm.AddSong, v => v.AddSong).DisposeWith(d);
			});
		}
	}
}
