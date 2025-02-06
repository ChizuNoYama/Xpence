using CommunityToolkit.Mvvm.Input;
using Xpence.Models;
using Xpence.Services;
using Xpence.Services.Data;

namespace Xpence.ViewModels.Modals;

public partial class AddExpenseModalViewModel(IServiceProvider serviceProvider) : BaseViewModel(serviceProvider)
{
    public List<ExpenseCategory> _expenseCategories = new();
    public List<ExpenseCategory> ExpenseCategories
    {
        get => _expenseCategories;
        set => SetProperty(ref _expenseCategories, value);
    }

    [RelayCommand]
    public async Task AddExpenseAsync()
    {
        //TODO: Testing inserting Category
        ExpenseCategory category = new()
        {
            Id = 1,
            Name = "Food"
        };
        
        Expense expense = new()
        {
            Id = Guid.NewGuid(),
            Amount = 11.99,
            TimeStamp = DateTime.Now,
            ExpenseName = "Spotify Subscription",
            ExpenseCategoryId = category.Id ?? 0
        };
        
        await this.ServiceProvider.GetService<IDatabaseRepo>()!.InsertExpenseAsync(expense);
    }

    [RelayCommand]
    public async Task CloseModalAsync()
    {
        await this.ServiceProvider.GetService<INavigationService>()!.CloseModalAsync();
    }
}