using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Windows;

namespace ProLyric.ViewModels
{
    public class AppVM : ReactiveObject
    {
        public extern string Lang { [ObservableAsProperty] get; }
        [Reactive] public string Greeting { get; set; } = "Greeting";

		[Reactive] public string LiveViewAddress { get; set; } = "lyrics://live/";

		[Reactive] public int Top { get; set; } = 0;
		[Reactive] public int Left { get; set; } = 0;
		[Reactive] public int Width { get; set; } = 1024;
		[Reactive] public int Height { get; set; } = 768;

		[Reactive] public WindowState State { get; set; } = WindowState.Normal;

		public AppVM()
        {
            Dictionary<string, string> Greetings = new Dictionary<string, string>() {
                { "English", "Hello World!" },
                { "French", "Bonjour le monde!" },
                { "German", "Hallo Welt!" },
                { "Japanese", "Kon'nichiwa sekai!" },
                { "Spanish", "¡Hola Mundo!" },
            };

            string[] keys = Greetings.Keys.ToArray();

            // Select next language every 2 seconds (100 times max.)
            Observable.Interval(TimeSpan.FromSeconds(1))
                .Take(100)
                .Select(_ => keys[(Array.IndexOf(keys, Lang) + 1) % keys.Count()])
                .ObserveOn(RxApp.MainThreadScheduler)
                .ToPropertyEx(this, x => x.Lang, "Language");

            // Update Greeting when language changes
            this.WhenAnyValue(x => x.Lang)
                .Where(lang => keys.Contains(lang))
                .Select(x => Greetings[x])
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe(x => Greeting = x);
        }
    }
}
