using ProLyric.ViewModels;
using ReactiveUI;

namespace ProLyric.Views
{
	public partial class LiveView : ReactiveUserControl<LiveViewVM>
	{
		public LiveView()
		{
			InitializeComponent();
			ViewModel = new LiveViewVM();

			this.WhenActivated(d => {
				// this.OneWayBind(ViewModel, vm => vm.Address, v => v.browser.Address).DisposeWith(d);
			});
		}
	}
}
