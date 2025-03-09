using System.ComponentModel;
using System.Globalization;
using System.Resources;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo;
//https://www.youtube.com/watch?v=cf4sXULR7os&ab_channel=GeraldVersluis
public class LocalizationManager : INotifyPropertyChanged
{
    private ResourceManager _resourceManager;

    public event PropertyChangedEventHandler? PropertyChanged;

    private LocalizationManager()
    {
        _resourceManager = new ResourceManager("P07_01_DI_Contactos_TAPIADOR_rodrigo.Properties.Resources", typeof(LocalizationManager).Assembly);
    }

    public static LocalizationManager Instance { get; } = new();

    public string GetString(string key)
    {
        return _resourceManager.GetString(key, CultureInfo.CurrentUICulture);
    }

    public void SetCulture(CultureInfo culture)
    {
        Thread.CurrentThread.CurrentUICulture = culture;
        Thread.CurrentThread.CurrentCulture = culture;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
    }
    public string this[string key] => GetString(key);

}
