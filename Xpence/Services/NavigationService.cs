using Xpence.Services.Interfaces;

namespace Xpence.Services;

public class NavigationService : INavigationService
{
    public Task NavigateToAsync(string route, IDictionary<string, object>? parameters = null)
    {
        if (parameters == null)
        {
            return Shell.Current.GoToAsync(route);
        }
        return Shell.Current.GoToAsync(route, parameters);
    }

    public Task PopAsync()
    {
        return Shell.Current.GoToAsync("..");
    }
}