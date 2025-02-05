using Xpence.Core;

namespace Xpence.ViewModels;

public abstract class BaseViewModel(IServiceProvider serviceProvider) : BaseObject
{
    protected IServiceProvider ServiceProvider { get; } = serviceProvider;
    //protected INavigationService NavigationService => ServiceProvider.GetService<INavigationService>()!;
    public virtual void Initialize(){}
    public virtual Task InitializeAsync() => Task.CompletedTask;
}