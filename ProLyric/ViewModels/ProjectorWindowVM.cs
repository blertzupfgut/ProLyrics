using System.Windows;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ProLyric.ViewModels
{
	public class ProjectorWindowVM : ReactiveObject
    {
		[Reactive] public string Address { get; set; } = "lyrics://live/";

		[Reactive] public bool ShowDevTools { get; set; } = true;

		[Reactive] public int Top { get; set; } = 0;
		[Reactive] public int Left { get; set; } = 0;
		[Reactive] public int Width { get; set; } = 1024;
		[Reactive] public int Height { get; set; } = 768;

		[Reactive] public WindowState State { get; set; } = WindowState.Normal;

		public ProjectorWindowVM()
        {
		}
    }
}
