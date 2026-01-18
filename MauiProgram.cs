namespace ImageViewer;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
#if DEBUG
		builder.Logging.AddDebug();
#endif
		builder.Services.AddSingleton<MainViewModel>();
		Routing.RegisterRoute("xrayview", typeof(BlankPage));

		builder.Services.AddSingleton<MainPage>();

		builder.Services.AddSingleton<BlankViewModel>();

		builder.Services.AddSingleton<BlankPage>();

		builder.Services.AddSingleton<SampleViewModel>();

		builder.Services.AddSingleton<SamplePage>();

		return builder.Build();
	}
}
