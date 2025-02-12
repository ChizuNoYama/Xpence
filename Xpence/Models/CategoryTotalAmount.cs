using Xpence.Core;

namespace Xpence.Models;

public class CategoryTotalAmount
{
    public string ExpenseCategoryName { get; set; } = Constants.DEFAULT_CATEGORY_NAME;
    public double TotalAmount { get; set; }
}