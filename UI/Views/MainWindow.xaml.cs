namespace P06_01_DI_Contactos_TAPIADOR_rodrigo;

public partial class MainWindow 
{
    public MainWindow()
    {
        LoadSettings();
        InitializeComponent();
    }
    private static void LoadSettings()
    {
        Thread.CurrentThread.CurrentUICulture = new(Properties.Settings.Default.Language);
        Properties.Settings.Default.Save();
    }

}