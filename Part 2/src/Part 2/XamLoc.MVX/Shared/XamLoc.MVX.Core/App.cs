using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using XamLoc.MVX.Core.Services;

namespace XamLoc.MVX.Core
{
	public class App : MvxApplication
	{
		public override void Initialize()
		{
			CreatableTypes()
				.EndingWith("Service")
				.AsInterfaces()
				.RegisterAsLazySingleton();

			RegisterServices();
			RegisterAppStart<MainViewModel>();
		}

		public void FirstRunCompleted()
		{
			RegisterAppStart<MainViewModel>();
		}

		void RegisterServices()
		{
			Mvx.RegisterSingleton<IDemoService>(new DemoService());
		}
	}
}