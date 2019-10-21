using ProLyric.ViewModels;
using ProLyric.Views;
using ReactiveUI;
using System;
using System.Reactive.Disposables;

namespace ProLyric
{
    public partial class MainWindow : ReactiveWindow<AppVM>
    {
		ProjectorWindow projectorWindow;

		public MainWindow()
        {
            InitializeComponent();
			this.Closed += onClosed;

			ViewModel = new AppVM();

            this.WhenActivated(d => {
				//this.OneWayBind(ViewModel, viewModel => viewModel.LiveViewAddress,
				//	view => view.preViewBrowser.Address).DisposeWith(d);
				//this.OneWayBind(ViewModel, viewModel => viewModel.LiveViewAddress,
				//	view => view.liveViewBrowser.Address).DisposeWith(d);
				//this.OneWayBind(ViewModel, viewModel => viewModel.Lang,
    //                view => view.preView.Content).DisposeWith(d);
    //            this.OneWayBind(ViewModel, viewModel => viewModel.Greeting,
    //                view => view.liveView.Content).DisposeWith(d);
            });

			projectorWindow = new ProjectorWindow();
			showProjectorView(true);
        }

		void onClosed(object sender, EventArgs e)
		{
			projectorWindow.Close();
		}

		void showProjectorView(bool show)
		{
			if (show) {
				projectorWindow.Show();
			}
			else {
				projectorWindow.Close();
			}
		}
	}
}
