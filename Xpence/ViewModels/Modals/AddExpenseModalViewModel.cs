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

    private double _amount;
    public double Amount
    {
        get => _amount; 
        set => SetProperty(ref _amount, value); 
    }

    private string _expenseName;
    public string ExpenseName
    {
        get => _expenseName;
        set => SetProperty(ref _expenseName, value);
    }

    public override async Task InitializeAsync()
    {
        await base.InitializeAsync();
        
        IDatabaseRepo db = this.ServiceProvider.GetRequiredService<IDatabaseRepo>();
        List<ExpenseCategory> temp = await db.GetExpenseCategoriesAsync();
        this.ExpenseCategories = temp;
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
            Amount = this.Amount,
            TimeStamp = DateTime.Now,
            ExpenseName = this.ExpenseName,
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