using CefSharp;
using ReactiveUI;
using System;
using System.Reactive.Disposables;

namespace ProLyric
{
    public partial class MainWindow : ReactiveWindow<AppVM>
    {
		ProjectorView projectorView;

		public MainWindow()
        {
            InitializeComponent();
			this.Closed += new EventHandler(onClosed);

			ViewModel = new AppVM();

            this.WhenActivated(d => {
				//this.OneWayBind(ViewModel, viewModel => viewModel.LiveViewAddress,
				//	view => view.preViewBrowser.Address).DisposeWith(d);
				this.OneWayBind(ViewModel, viewModel => viewModel.LiveViewAddress,
					view => view.liveViewBrowser.Address).DisposeWith(d);
				this.OneWayBind(ViewModel, viewModel => viewModel.Lang,
                    view => view.preView.Content).DisposeWith(d);
                this.OneWayBind(ViewModel, viewModel => viewModel.Greeting,
                    view => view.liveView.Content).DisposeWith(d);
            });

			projectorView = new ProjectorView();
			showProjectorView(true);
			WindowState
        }

		void onClosed(object sender, EventArgs e)
		{
			projectorView.Close();
		}

		void showProjectorView(bool show)
		{
			if (show) {
				projectorView.Show();
			}
			else {
				projectorView.Close();
			}
		}
	}
}
