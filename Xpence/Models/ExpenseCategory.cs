using SQLite;

namespace Xpence.Models;

[Table("ExpenseCategory")]
public class ExpenseCategory
{
    [PrimaryKey]
    public Guid Id { get; set; }
    public string? Name { get; set; }
}