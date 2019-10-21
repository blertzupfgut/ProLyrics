using ProLyric.ViewModels;
using ReactiveUI;

namespace ProLyric.Views
{
	public partial class DesignManager : ReactiveUserControl<DesignManagerVM>
	{
		public DesignManager()
		{
			InitializeComponent();
			ViewModel = new DesignManagerVM();

			this.WhenActivated(d => {
				// this.OneWayBind(ViewModel, vm => vm.Address, v => v.browser.Address).DisposeWith(d);
			});
		}
	}
}
