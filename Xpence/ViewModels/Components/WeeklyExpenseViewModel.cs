namespace Xpence.ViewModels.Components;

public class WeeklyExpenseViewModel(IServiceProvider serviceProvider) : BaseViewModel(serviceProvider)
{
    public string? DisplayGroceryTotalAmount { get; set; }
    public string? DisplayEatingOutTotalAmount { get; set; }
    public string? DisplayShoppingTotalAmount { get; set; }
    public string? DisplayTransportationTotalAmount { get; set; }
}