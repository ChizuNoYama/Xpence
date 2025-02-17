using Xpence.Models;

namespace Xpence.Services.Data;

public class WeeklyExpenseService(IServiceProvider _serviceProvider) : IWeeklyExpenseService
{
    public async Task<List<CategoryTotalAmount>> GetCategoryAmounts(List<Expense>? existingExpenses = null)
    {
        List<CategoryTotalAmount> amountsByCategory = new();
        IDatabaseRepo db = _serviceProvider.GetService<IDatabaseRepo>()!;
        List<Expense> expenses = existingExpenses ?? await db.GetExpensesAsync();

        if (expenses.Count == 0)
        {
            List<ExpenseCategory> expenseCategories = await db.GetExpenseCategoriesAsync();
            foreach (ExpenseCategory expenseCategory in expenseCategories)
            {
                amountsByCategory.Add(new CategoryTotalAmount{ ExpenseCategoryName = expenseCategory.Name, TotalAmount = 0});
            }
            return amountsByCategory;
        }
        
        foreach (var expense in expenses)
        {
            // NOTE: This can be very inefficient. The list is iterated for every expense
            // NOTE:Time complexity is variable as the size of the list changes based on the number of categories each expense is registered to
            CategoryTotalAmount? foundAmount = amountsByCategory.Find(c => c.ExpenseCategoryName == expense.ExpenseCategoryName);
            if (foundAmount == null)
            {
                amountsByCategory.Add(new CategoryTotalAmount { ExpenseCategoryName = expense.ExpenseCategoryName, TotalAmount = expense.Amount });
            }
            else
            {
                foundAmount.TotalAmount += expense.Amount;
            }
        }
        return amountsByCategory;
    }
}