using System.Diagnostics;
using Xpence.ViewModels.Page;

namespace Xpence;

public partial class MainPage
{
    public MainPage(MainPageViewModel viewModel) : base(viewModel)
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        try
        {
            base.OnAppearing();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        
    }
}