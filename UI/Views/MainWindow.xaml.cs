namespace P05_01_DI_Productos_TAPIADOR_rodrigo;

public partial class MainWindow 
{
    public MainWindow()
    {
        LoadSettings();
        InitializeComponent();
    }
    private void LoadSettings()
    {
        Thread.CurrentThread.CurrentUICulture = new(Properties.Settings.Default.Language);
        Properties.Settings.Default.Save();
    }

}