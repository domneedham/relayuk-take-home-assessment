using Microsoft.Extensions.Logging;
using TakeHomeAssessment.ViewModels;
using TakeHomeAssessment.Views;

namespace TakeHomeAssessment;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder.UseMauiApp<App>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		// this fixes some issues on mac and iOS
		builder.ConfigureMauiHandlers(handlers =>
		{
#if MACCATALYST || IOS
			handlers.AddHandler(typeof(Label), typeof(CustomLabelHandler));
#endif
		});

		builder.Services.AddSingleton<MainPageViewModel>();
		builder.Services.AddSingleton<QuotesViewModel>();
		builder.Services.AddTransient<MainPage>();
		builder.Services.AddTransient<QuotesPage>();

		// add any services from here

		return builder.Build();
	}
}