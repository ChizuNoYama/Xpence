using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using Xpence.Core;
using Xpence.Models;
using Xpence.Pages.Modals;
using Xpence.Services;
using Xpence.Services.Data;

namespace Xpence.ViewModels.Page;

public partial class MainPageViewModel(IServiceProvider serviceProvider) : BaseViewModel(serviceProvider)
{
    private ObservableCollection<Expense> _expenses = new();
    public ObservableCollection<Expense> Expenses
    {
        get => _expenses;
        set => this.SetProperty(ref _expenses, value);
    }
    
    private ObservableCollection<CategoryTotalAmount> _categoryAmounts = new();
    public ObservableCollection<CategoryTotalAmount> CategoryAmounts
    {
        get => _categoryAmounts;
        set => SetProperty(ref _categoryAmounts, value);
    }

    public override async Task InitializeAsync()
    {
        IDatabaseRepo db = this.ServiceProvider.GetService<IDatabaseRepo>()!;
        
        // Get the current list of expenses
        //TODO: Check performance of this
        List<Expense> tempExpenseList = await db.GetExpensesAsync();
        foreach (Expense expense in tempExpenseList)
        {
            ExpenseCategory Category = await db.GetExpenseCategoryByIdAsync(expense.ExpenseCategoryId);
            expense.ExpenseCategoryName = Category.Name;
            expense.ExpenseCategoryId = Category.Id;
        }
        tempExpenseList.Reverse();
        this.Expenses = new(tempExpenseList);
        
        // Get the list of Categories for the week
        List<CategoryTotalAmount> tempWeeklyList = await this.ServiceProvider.GetService<IWeeklyExpenseService>()!.GetCategoryAmounts(this.Expenses.ToList());
        this.CategoryAmounts = new (tempWeeklyList);
    }
    
    [RelayCommand]
    public async Task ShowAddExpenseModalAsync()
    {
        AddExpenseModal modal = this.ServiceProvider.GetService<AddExpenseModal>()!;
        await this.ServiceProvider.GetService<INavigationService>()!.NavigateModalAsync(modal);
    }
}