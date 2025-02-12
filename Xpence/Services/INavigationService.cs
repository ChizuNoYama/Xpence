using Xpence.Core;

namespace Xpence.Services;

public interface INavigationService
{
    Task NavigateToAsync(string route, IDictionary<string, object>? parameters = null);
    Task NavigateModalAsync(BaseContentPage page, bool animated = false, IDictionary<string, object>? parameters = null);
    Task CloseModalAsync();
    Task PopAsync();
}