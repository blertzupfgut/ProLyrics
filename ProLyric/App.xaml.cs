using CefSharp;
using CefSharp.SchemeHandler;
using CefSharp.Wpf;
using ReactiveUI;
using Splat;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;

namespace ProLyric
{
	public partial class App : Application
	{
		public App()
		{
			// Add Custom assembly resolver for CefSharp:
			// AppDomain.CurrentDomain.AssemblyResolve += Resolver;

			// A helper method that will register all classes that derive off IViewFor 
			// into our dependency injection container. ReactiveUI uses Splat for it's 
			// dependency injection by default, but you can override this if you like.

			// Locator.CurrentMutable.RegisterViewsForViewModels(Assembly.GetCallingAssembly());

			// Any CefSharp references have to be in another method with NonInlining
			// attribute so the assembly rolver has time to do it's thing.

			initializeCefSharp();
		}

		protected override void OnExit(ExitEventArgs e)
		{
			try {
				Cef.Shutdown();
			}
			finally {
				base.OnExit(e);
			}
		}

		//// Will attempt to load missing assembly from either x86 or x64 subdir
		//// Required by CefSharp to load the unmanaged dependencies when running using AnyCPU
		//static Assembly Resolver(object sender, ResolveEventArgs args)
		//{
		//	if (args.Name.StartsWith("CefSharp")) {
		//		string assemblyName = args.Name.Split(new[] { ',' }, 2)[0] + ".dll";
		//		string archSpecificPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
		//											   Environment.Is64BitProcess ? "x64" : "x86",
		//											   assemblyName);

		//		return File.Exists(archSpecificPath)
		//				   ? Assembly.LoadFile(archSpecificPath)
		//				   : null;
		//	}

		//	return null;
		//}

		//[MethodImpl(MethodImplOptions.NoInlining)]
		private static void initializeCefSharp()
		{
			var settings = new CefSettings {
				RemoteDebuggingPort = 8088,
			};

			settings.RegisterScheme(new CefCustomScheme {
				SchemeName = "lyrics",
				DomainName = "live",
				SchemeHandlerFactory = new FolderSchemeHandlerFactory(
					rootFolder: @"D:\P_Dev\Prolyric\ProLyric\data",
					hostName: "live",
					defaultPage: "index.html" // will default to index.html
				)
			});

			//// Set BrowserSubProcessPath based on app bitness at runtime:
			//settings.BrowserSubprocessPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
			//									   Environment.Is64BitProcess ? "x64" : "x86",
			//									   "CefSharp.BrowserSubprocess.exe");

			//// Make sure you set performDependencyCheck to false:
			//Cef.Initialize(settings, performDependencyCheck: false, browserProcessHandler: null);

			// Cef.Initialize(settings, performDependencyCheck: true, browserProcessHandler: null);
			Cef.Initialize(settings);
		}
	}
}
