using System.Runtime.CompilerServices;

namespace Xpence.Components;

public partial class ExpenseView
{
    public ExpenseView()
    {
        InitializeComponent();
    }
    
    public static BindableProperty ExpenseNameProperty = BindableProperty.Create(nameof(ExpenseName),typeof(string), typeof(ExpenseView));
    public string ExpenseName
    {
        get => (string)GetValue(ExpenseNameProperty);
        set => SetValue(ExpenseNameProperty, value);
    }

    public static BindableProperty SourceProperty = BindableProperty.Create(nameof(Source), typeof(ImageSource), typeof(ExpenseView));
    public ImageSource? Source
    {
        get => (ImageSource)GetValue(SourceProperty) ?? "not_found.png";
        set => SetValue(SourceProperty, value);
    }
    
    public static BindableProperty ExpenseCategoryNameProperty = BindableProperty.Create(nameof(ExpenseCategoryName), typeof(string), typeof(ExpenseView));
    public string ExpenseCategoryName
    {
        get => (string)GetValue(ExpenseCategoryNameProperty);
        set => SetValue(ExpenseCategoryNameProperty, value);
    }
    
    public static BindableProperty TimestampProperty = BindableProperty.Create(nameof(Timestamp), typeof(DateTime), typeof(ExpenseView));
    public DateTime Timestamp
    {
        
        get => (DateTime)GetValue(TimestampProperty);
        set => SetValue(TimestampProperty, value);
    }
    
    public static BindableProperty AmountProperty = BindableProperty.Create(nameof(Amount), typeof(double), typeof(ExpenseView));
    public double Amount
    {
        get => (double)GetValue(AmountProperty);
        set => SetValue(AmountProperty, value);
    }

    private string _displayAmount = string.Empty;
    public string DisplayAmount
    {
        get => _displayAmount;
        set
        {
            _displayAmount = value;
            this.OnPropertyChanged();
        }
    }

    private string _formattedDate = string.Empty;
    public string FormattedDate
    {
        get => _formattedDate;
        set
        {
            _formattedDate = value;
            this.OnPropertyChanged();
        }
    }

    // TODO: Figure out why this is called three times
    // This will be called three times because the BindingContext is being reset three times.
    // This is caused by the way CollectionView is recycling the items in the its template.
    // Idk how to stop it and I'm not sure I want to
    protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
    
        if (propertyName == TimestampProperty.PropertyName)
        {
            this.FormattedDate = Timestamp.ToString("MMM dd, yyyy");
        }
    
        if (propertyName == AmountProperty.PropertyName)
        {
            this.DisplayAmount = this.Amount.ToString("$0.00");
        }
    }
}