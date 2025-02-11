using SQLite;
using Xpence.Core;
using Xpence.Models;

namespace Xpence.Services.Data;

public class DatabaseRepo : IDatabaseRepo
{
    private SQLiteAsyncConnection? _database;
    
    public async Task CreateDatabaseAsync()
    {
        if (_database != null) return;
        _database = new SQLiteAsyncConnection(Constants.DATABASE_PATH, SQLiteOpenFlags.Create | SQLiteOpenFlags.FullMutex | SQLiteOpenFlags.ReadWrite);
        await Task.WhenAll(
            _database.CreateTableAsync<Expense>(),
            _database.CreateTableAsync<ExpenseCategory>()
        );

        List<ExpenseCategory> categories =  await _database.Table<ExpenseCategory>().ToListAsync();
        if (categories.Count > 0) return;
        
        // Insert the first category "Uncategorized" if the user does not want to order their expense in a category
       await  _database.InsertAsync(new ExpenseCategory
       {
           Name = "Uncategorized"
       });
    }

    #region Expenses
    public async Task<List<Expense>> GetExpensesAsync()
    {
        await this.CreateDatabaseAsync();
        return await _database!.Table<Expense>().ToListAsync();
    }
    
    public async Task<int> InsertExpenseAsync(Expense expense)
    {
        await this.CreateDatabaseAsync();
        return await _database!.InsertAsync(expense);
    }

    public async Task<int> UpdateExpenseAsync(Expense expense)
    {
        await this.CreateDatabaseAsync();
        return await _database!.UpdateAsync(expense);
    }
    
    #endregion Expenses

    #region Expense Categories
    public async Task<ExpenseCategory> GetExpenseCategoryAsync(ExpenseCategory expenseCategory)
    {
        await this.CreateDatabaseAsync();
        if (expenseCategory.Id == null)
        {
            return await this.GetExpenseCategoryByIdAsync(expenseCategory.Id);
        }
        return await this.GetExpenseCategoryByNameAsync(expenseCategory.Name);
    }
    
    public async Task<ExpenseCategory> GetExpenseCategoryByIdAsync(uint? expenseCategoryId)
    {
        await this.CreateDatabaseAsync();

        uint? id = expenseCategoryId ?? 0;
        // If the expenseCategoryId is null, get the "Uncategorized" category 
        return await _database!.Table<ExpenseCategory>().Where(e => e.Id == id).FirstOrDefaultAsync();
    }
    
    public async Task<ExpenseCategory> GetExpenseCategoryByNameAsync(string expenseCategoryName)
    {
        await this.CreateDatabaseAsync();
        return await _database!.Table<ExpenseCategory>().Where(e => e.Name == expenseCategoryName).FirstOrDefaultAsync();
    }
    
    public async Task<List<ExpenseCategory>> GetExpenseCategoriesAsync()
    {
        await this.CreateDatabaseAsync();
        return await _database!.Table<ExpenseCategory>().ToListAsync();
    }

    public async Task<int> InsertExpenseCategoryAsync(ExpenseCategory expenseCategory)
    {
        await this.CreateDatabaseAsync();
        return await _database!.InsertAsync(expenseCategory);
    }
    
    #endregion Expense Categories
}