using P06_01_DI_Contactos_TAPIADOR_rodrigo.UI.ViewModels;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace P06_01_DI_Contactos_TAPIADOR_rodrigo.UI.Views;


public partial class SettingsView : UserControl
{
    public SettingsView(SettingsViewModel viewModel)
    {
        InitializeComponent();
        this.DataContext = viewModel;
    }

    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        
        var temp = (comboBox?.SelectedItem)?.ToString();
        if (!string.IsNullOrEmpty(temp))
        {
            string[] selectedLanguage = temp.Split(" ");
            try
            {
                Properties.Settings.Default.Language = selectedLanguage[1];
                Properties.Settings.Default.Save();
                Thread.CurrentThread.CurrentUICulture = new(Properties.Settings.Default.Language);

                MainWindow newWindow = new MainWindow();
                newWindow.Show();
                Application.Current.MainWindow.Close();
                Application.Current.MainWindow = newWindow;
            }
            catch (CultureNotFoundException ex)
            {
                MessageBox.Show($"Cultura '{selectedLanguage[1]}' inválida.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
    }

}

