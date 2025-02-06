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

    public override async Task InitializeAsync()
    {
        IDatabaseRepo db = this.ServiceProvider.GetService<IDatabaseRepo>()!;
        List<Expense> tempList = await db.GetExpensesAsync();
        //TODO: Check performance of this
        foreach (Expense expense in tempList)
        {
           ExpenseCategory Category =  await db.GetExpenseCategoryByIdAsync(expense.ExpenseCategoryId);
           expense.ExpenseCategoryName = Category.Name;
           expense.ExpenseCategoryId = Category.Id;
        }
        
        this.Expenses = new(tempList);

    }
    
    [RelayCommand]
    public async Task ShowAddExpenseModalAsync()
    {
        AddExpenseModal modal = this.ServiceProvider.GetService<AddExpenseModal>()!;
        await this.ServiceProvider.GetService<INavigationService>()!.NavigateModalAsync(modal);
    }
}