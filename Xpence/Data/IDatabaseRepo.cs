using Xpence.Models;

namespace Xpence.Data;

public interface IDatabaseRepo
{
    Task CreateDatabaseAsync();
    Task<List<Expense>> GetExpensesAsync();
    Task<int> InsertExpenseAsync(Expense expense);
}