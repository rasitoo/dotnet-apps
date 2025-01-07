using System.Windows.Media;

namespace P05_01_DI_Productos_TAPIADOR_rodrigo;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow 
{
    public MainWindow()
    {
        LoadSettings();
        InitializeComponent();
    }
    private void LoadSettings()
    {
        Properties.Settings.Default.Language = "es";
        Properties.Settings.Default.Save();
    }

}