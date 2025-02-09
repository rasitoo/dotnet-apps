using P07_01_DI_Contactos_TAPIADOR_rodrigo.UI.ViewModels;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo;

public partial class MainWindow
{
    public MainWindow(MainViewModel viewModel)
    {
        DataContext = viewModel;
        LoadSettings();
        InitializeComponent();
    }
    private static void LoadSettings()
    {
        Thread.CurrentThread.CurrentUICulture = new(Properties.Settings.Default.Language);
        Properties.Settings.Default.Save();
    }

}