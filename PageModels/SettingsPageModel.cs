using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Globalization;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.PageModels;

//https://stackoverflow.com/questions/76555754/how-to-reload-or-update-ui-in-net-maui-when-culture-has-been-changed#:~:text=To%20change%20current,language%20just%20call%20LocalizationManager.Instance.SetCulture%28newCultureOfChoice%29%3B
public partial class SettingsPageModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<string> _languages = new ObservableCollection<string> { "Español-es", "English-en" };

    [ObservableProperty]
    private string _selectedLanguage;

    public SettingsPageModel()
    {
        _selectedLanguage = _languages[0];
    }

    [RelayCommand]
    private void ChangeLanguage()
    {
        if (!string.IsNullOrEmpty(_selectedLanguage))
        {
            var cultureCode = _selectedLanguage.Split('-')[1];
            var culture = new CultureInfo(cultureCode);
            LocalizationManager.Instance.SetCulture(culture);
        }
    }
}
