using ProLyric.ViewModels;
using ReactiveUI;
using System.Reactive.Disposables;

namespace ProLyric.Views
{
	public partial class ProjectorWindow : ReactiveWindow<ProjectorWindowVM>
	{
		public ProjectorWindow()
		{
			InitializeComponent();
			ViewModel = new ProjectorWindowVM();

			this.WhenActivated(d => {
				//this.OneWayBind(ViewModel, viewModel => viewModel.Address,
				//	view => view.browser.Address).DisposeWith(d);
				//this.OneWayBind(ViewModel, viewModel => viewModel.ShowDevTools,
				//	view => view.browser.Show).DisposeWith(d);
				//view.browser.ShowDevTools();

			});
		}
	}
}
