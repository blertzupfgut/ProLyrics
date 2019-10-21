using ProLyric.ViewModels;
using ReactiveUI;

namespace ProLyric.Views
{
	public partial class ProjectorManager : ReactiveUserControl<ProjectorManagerVM>
	{
		public ProjectorManager()
		{
			InitializeComponent();
			ViewModel = new ProjectorManagerVM();

			this.WhenActivated(d => {
				// this.OneWayBind(ViewModel, vm => vm.Address, v => v.browser.Address).DisposeWith(d);
			});
		}
	}
}
