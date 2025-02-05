using CommunityToolkit.Maui;
using Xpence.Pages.Modals;
using Xpence.Services;
using Xpence.Services.Data;
using Xpence.ViewModels.Modals;
using Xpence.ViewModels.Page;

namespace Xpence.Core;

public static class AppBuilderExtensions
{
    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<MainPageViewModel>();
        builder.Services.AddTransient<AddExpenseModalViewModel>();
        // builder.Services.AddTransient<WeeklyExpenseViewModel>();
        // builder.Services.AddTransient<WeeklyExpense>
        return builder;
    }

    public static MauiAppBuilder RegisterPages(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<AddExpenseModal>();
        return builder;
    }
    
    public static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<INavigationService, NavigationService>();
        builder.Services.AddSingleton<IDatabaseRepo, DatabaseRepo>();
        return builder;
    }
}