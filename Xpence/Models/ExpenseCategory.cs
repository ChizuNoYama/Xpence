using SQLite;

namespace Xpence.Models;

[Table("ExpenseCategory")]
public class ExpenseCategory
{
    [PrimaryKey, AutoIncrement]
    public uint? Id { get; set; }

    public string Name { get; set; } = "";
}