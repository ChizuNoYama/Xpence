namespace Xpence.Components;

public partial class WeeklyExpenseView
{
    public WeeklyExpenseView()
    {
        InitializeComponent();
    }
    
    public string? DisplayGroceryTotalAmount { get; set; }
    public string? DisplayEatingOutTotalAmount { get; set; }
    public string? DisplayShoppingTotalAmount { get; set; }
    public string? DisplayTransportationTotalAmount { get; set; }
    
}