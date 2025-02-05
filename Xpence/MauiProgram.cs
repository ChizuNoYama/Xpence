using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Xpence.Core;
using Xpence.ViewModels.Page;

namespace Xpence;

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
            })
            .RegisterServices()
            .RegisterViewModels()
            .RegisterPages();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}