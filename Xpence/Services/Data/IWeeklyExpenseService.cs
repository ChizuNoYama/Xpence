using Xpence.Models;

namespace Xpence.Services.Data;

public interface IWeeklyExpenseService
{
    public Task<List<CategoryTotalAmount>> GetCategoryAmounts(List<Expense>? expenses = null);
}