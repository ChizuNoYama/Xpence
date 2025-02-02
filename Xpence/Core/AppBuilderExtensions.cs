using Xpence.Components;
using Xpence.Data;
using Xpence.Services;
using Xpence.Services.Interfaces;
using Xpence.ViewModels.Components;
using Xpence.ViewModels.Page;

namespace Xpence.Core;

public static class AppBuilderExtensions
{
    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<MainPageViewModel>();
        // builder.Services.AddTransient<WeeklyExpenseViewModel>();
        return builder;
    }

    public static MauiAppBuilder RegisterPages(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<MainPage>();
        return builder;
    }
    
    public static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<INavigationService, NavigationService>();
        builder.Services.AddSingleton<IDatabaseRepo, DatabaseRepo>();
        return builder;
    }
}