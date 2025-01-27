using Microsoft.Extensions.DependencyInjection;
using P06_01_DI_Contactos_TAPIADOR_rodrigo.UI.ViewModels;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace P06_01_DI_Contactos_TAPIADOR_rodrigo.UI.Views;

public partial class SettingsView : UserControl
{
    private readonly IServiceProvider _serviceProvider;

    public SettingsView(SettingsViewModel viewModel, IServiceProvider serviceProvider)
    {
        InitializeComponent();
        this.DataContext = viewModel;
        _serviceProvider = serviceProvider;
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

                var newWindow = _serviceProvider.GetService<MainWindow>();
                if (newWindow != null)
                {
                    newWindow.DataContext = _serviceProvider.GetRequiredService<MainViewModel>();
                    newWindow.Height = Application.Current.MainWindow.ActualHeight;
                    newWindow.Width = Application.Current.MainWindow.ActualWidth;
                    newWindow.Top = Application.Current.MainWindow.Top;
                    newWindow.Left = Application.Current.MainWindow.Left;
                    newWindow.WindowState = Application.Current.MainWindow.WindowState;
                    newWindow.Show();
                    Application.Current.MainWindow.Close();
                    Application.Current.MainWindow = newWindow;
                }
                else
                {
                    MessageBox.Show("No se pudo crear la nueva ventana principal.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (CultureNotFoundException ex)
            {
                MessageBox.Show($"Cultura '{selectedLanguage[1]}' inválida: {ex}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

