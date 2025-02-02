using SQLite;
using Xpence.Core;
using Xpence.Models;

namespace Xpence.Data;

public class DatabaseRepo : IDatabaseRepo
{
    private SQLiteAsyncConnection? _database;
    
    public async Task CreateDatabaseAsync()
    {
        if (_database != null) return;
        _database = new SQLiteAsyncConnection(Constants.DATABASE_NAME, SQLiteOpenFlags.Create | SQLiteOpenFlags.FullMutex);
        await _database.CreateTableAsync<Expense>();
    }

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
}