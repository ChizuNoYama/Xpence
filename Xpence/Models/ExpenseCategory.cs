using SQLite;

namespace Xpence.Models;

[Table("ExpenseCategory")]
public class ExpenseCategory
{
    [PrimaryKey, AutoIncrement] public uint Id { get; set; } = 1;

    public string Name { get; set; } = "";
}