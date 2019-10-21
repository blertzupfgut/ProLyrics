using ProLyric.ViewModels;
using ReactiveUI;

namespace ProLyric.Views
{
	public partial class ServiceManager : ReactiveUserControl<ServiceManagerVM>
	{
		public ServiceManager()
		{
			InitializeComponent();
			ViewModel = new ServiceManagerVM();

			this.WhenActivated(d => {
				// this.OneWayBind(ViewModel, vm => vm.Address, v => v.browser.Address).DisposeWith(d);
			});
		}
	}
}
