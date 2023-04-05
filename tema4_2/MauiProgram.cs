using tema4_2.Services;
using tema4_2.ViewModel;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;

namespace tema4_2;

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
        builder.Services.AddSingleton<View.MainPage>();
        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddSingleton<View.EditItem>();
        builder.Services.AddSingleton<EditViewModel>();

        builder.Services.AddTransient<View.AddItem>();
        builder.Services.AddTransient<AddViewModel>();



        builder.Services.AddSingleton<DbConnection>();

        return builder.Build();
    }
       
	}

