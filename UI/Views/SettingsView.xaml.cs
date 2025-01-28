using P06_01_DI_Contactos_TAPIADOR_rodrigo.UI.ViewModels;
using System.Windows.Controls;

namespace P06_01_DI_Contactos_TAPIADOR_rodrigo.UI.Views;

public partial class SettingsView : UserControl
{
    public SettingsView(SettingsViewModel viewModel)
    {
        InitializeComponent();
        this.DataContext = viewModel;
    }
}

