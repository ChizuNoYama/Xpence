using Xpence.ViewModels;
using Xpence.ViewModels.Modals;

namespace Xpence.Pages.Modals;

public partial class AddExpenseModal
{
    public AddExpenseModal(AddExpenseModalViewModel viewModel) : base(viewModel)
    {
        InitializeComponent();
    }
}