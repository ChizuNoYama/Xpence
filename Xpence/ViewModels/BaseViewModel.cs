using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xpence.Core;
using Xpence.Services.Interfaces;

namespace Xpence.ViewModels;

public abstract class BaseViewModel(INavigationService navigationService) : BaseObject
{
    protected INavigationService NavigationService { get; } = navigationService;
    public virtual void Initialize(){}
    public virtual Task InitializeAsync() => Task.CompletedTask;
}