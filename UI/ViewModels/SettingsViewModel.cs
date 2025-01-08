using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using P05_01_DI_Productos_TAPIADOR_rodrigo.UI.Views;
using System.Windows.Input;

namespace P05_01_DI_Productos_TAPIADOR_rodrigo.UI.ViewModels;

partial class SettingsViewModel : ObservableObject
{
    [ObservableProperty]
    private string _selectedItem;


    public SettingsViewModel()
    {
        SelectedItem = Properties.Settings.Default.Language;
    }

}

