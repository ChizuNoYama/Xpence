using Xpence.Core;
using Xpence.Services;

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

    public Task NavigateModalAsync(BaseContentPage page, IDictionary<string, object>? parameters = null)
    {
        return Shell.Current.Navigation.PushModalAsync(page);
    }

    public Task CloseModalAsync()
    {
        return Shell.Current.Navigation.PopModalAsync();
    }

    public Task PopAsync()
    {
        return Shell.Current.GoToAsync("..");
    }
}