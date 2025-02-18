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

    private double? _amount;
    public double? Amount
    {
        get => _amount; 
        set => SetProperty(ref _amount, value); 
    }

    private string _expenseName = "";
    public string ExpenseName
    {
        get => _expenseName;
        set => SetProperty(ref _expenseName, value);
    }
    
    private ExpenseCategory _selectedExpenseCategory = new();
    public ExpenseCategory SelectedExpenseCategory
    {
        get => _selectedExpenseCategory;
        set => SetProperty(ref _selectedExpenseCategory, value);
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
        //TODO: Get the chosen category from the UI 
        
        Expense expense = new()
        {
            Id = Guid.NewGuid(),
            Amount = this.Amount ?? 0,
            TimeStamp = DateTime.Now,
            ExpenseName = this.ExpenseName,
            ExpenseCategoryId = this.SelectedExpenseCategory.Id
        };
        
        await this.ServiceProvider.GetService<IDatabaseRepo>()!.InsertExpenseAsync(expense);
        await this.CloseModalAsync();
    }

    [RelayCommand]
    public async Task CloseModalAsync()
    {
        await this.ServiceProvider.GetService<INavigationService>()!.CloseModalAsync();
    }
}