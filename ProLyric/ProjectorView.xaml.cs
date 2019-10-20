using ReactiveUI;
using System.Reactive.Disposables;

namespace ProLyric
{
	public partial class ProjectorView : ReactiveWindow<ProjectorViewVM>
	{
		public ProjectorView()
		{
			InitializeComponent();
			ViewModel = new ProjectorViewVM();

			this.WhenActivated(d => {
				this.OneWayBind(ViewModel, viewModel => viewModel.Address,
					view => view.browser.Address).DisposeWith(d);
				//this.OneWayBind(ViewModel, viewModel => viewModel.ShowDevTools,
				//	view => view.browser.Show).DisposeWith(d);
				//view.browser.ShowDevTools();

			});
		}
	}
}
