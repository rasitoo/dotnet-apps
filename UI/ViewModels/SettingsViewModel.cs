using CommunityToolkit.Mvvm.ComponentModel;

namespace P06_01_DI_Contactos_TAPIADOR_rodrigo.UI.ViewModels;

partial class SettingsViewModel : ObservableObject
{
    [ObservableProperty]
    private string _selectedItem;


    public SettingsViewModel()
    {
        SelectedItem = Properties.Settings.Default.Language;
    }

}

