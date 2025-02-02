using SQLite;

namespace Xpence.Models;

[Table("Expense")]
public class Expense
{
    [PrimaryKey]
    public Guid Id { get; set;}
    public string? ExpenseName { get; set;}
    public double Amount { get; set;}
    public DateTime TimeStamp { get; set; }
    public ExpenseCategory Category { get; set; }
}