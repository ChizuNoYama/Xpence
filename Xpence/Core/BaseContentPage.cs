using Xpence.ViewModels;

namespace Xpence.Core;

public class BaseContentPage : ContentPage
{
    protected BaseContentPage(BaseViewModel viewModel)
    {
        this.ViewModel = viewModel;
        this.BindingContext = this.ViewModel;
        this.ViewModel.Initialize();
    }

    private BaseViewModel _viewModel = null!;
    public BaseViewModel ViewModel
    {
        get => _viewModel;
        init => _viewModel = value ?? throw new ArgumentNullException(nameof(value));
    }
}