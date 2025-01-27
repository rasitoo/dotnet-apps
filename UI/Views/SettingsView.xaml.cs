using P06_01_DI_Contactos_TAPIADOR_rodrigo.UI.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace P06_01_DI_Contactos_TAPIADOR_rodrigo.UI.Views;

public partial class SettingsView : UserControl
{
    public SettingsView(SettingsViewModel viewModel)
    {
        InitializeComponent();
        this.DataContext = viewModel;
    }

    public static readonly DependencyProperty SelectedItemProperty =
        DependencyProperty.Register("SelectedItem", typeof(string), typeof(SettingsView), new PropertyMetadata(null));
    public string SelectedItem
    {
        get { return (string)GetValue(SelectedItemProperty); }
        set { SetValue(SelectedItemProperty, value); }
    }
}

