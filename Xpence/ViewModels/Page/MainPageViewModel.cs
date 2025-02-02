using System.Collections.ObjectModel;
using Xpence.Models;
using Xpence.Services.Interfaces;

namespace Xpence.ViewModels.Page;

public class MainPageViewModel(INavigationService navigationService) : BaseViewModel(navigationService)
{
    private ObservableCollection<Expense> _expenses = new();
    public ObservableCollection<Expense> Expenses
    {
        get => _expenses;
        set => this.SetProperty(ref _expenses, value);
    }

    public override void Initialize()
    {
        base.Initialize();
        List<Expense> temp = 
        [ 
            new() 
            {
                Id = Guid.NewGuid(),
                Amount = 11.99,
                TimeStamp = DateTime.Now,
                ExpenseName = "Spotify Subscription"
            }
        ];
        
        this.Expenses = new(temp);
    }
}