using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.PageModels;

public partial class SettingsPageModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<string> _languages = new ObservableCollection<string> { "Español", "Inglés", "Francés" };

    [ObservableProperty]
    private string _selectedLanguage;

    public SettingsPageModel()
    {
        _selectedLanguage = _languages[0];
    }

    [RelayCommand]
    private void ChangeLanguage()
    {

    }
}
