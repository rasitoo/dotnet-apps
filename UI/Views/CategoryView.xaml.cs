using P07_01_DI_Contactos_TAPIADOR_rodrigo.UI.ViewModels;
using System.Windows.Controls;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.UI.Views;

public partial class CategoryView : UserControl
{
    public CategoryView(CategoryViewModel viewModel)
    {
        InitializeComponent();
        this.DataContext = viewModel;
    }
}
