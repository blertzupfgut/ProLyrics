using ProLyric.ViewModels;
using ReactiveUI;

namespace ProLyric.Views
{
	public partial class PreView : ReactiveUserControl<PreViewVM>
	{
		public PreView()
		{
			InitializeComponent();
			ViewModel = new PreViewVM();

			this.WhenActivated(d => {
				// this.OneWayBind(ViewModel, vm => vm.Address, v => v.browser.Address).DisposeWith(d);
			});
		}
	}
}
