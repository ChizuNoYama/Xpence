using Xpence.Models;

namespace Xpence.Services.Data;

public interface IDatabaseRepo
{
    protected Task CreateDatabaseAsync();
    Task<List<Expense>> GetExpensesAsync();
    Task<int> InsertExpenseAsync(Expense expense);
    Task<int> UpdateExpenseAsync(Expense expense);
    Task<ExpenseCategory> GetExpenseCategoryAsync(ExpenseCategory expenseCategory);
    Task<ExpenseCategory> GetExpenseCategoryByIdAsync(uint? expenseCategoryId);
    Task<ExpenseCategory> GetExpenseCategoryByNameAsync(string expenseCategoryName);
    Task<List<ExpenseCategory>> GetExpenseCategoriesAsync();
    Task<int> InsertExpenseCategoryAsync(ExpenseCategory expenseCategory);
}