using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;

namespace P06_01_DI_Contactos_TAPIADOR_rodrigo.UI.ViewModels;

public partial class SettingsViewModel(IServiceProvider serviceProvider) : ObservableObject
{
    [ObservableProperty]
    private string _selectedItem = Properties.Settings.Default.Language;

    private readonly IServiceProvider _serviceProvider = serviceProvider;

    public ObservableCollection<string> Languages { get; } =
    [
        "en",
        "es"
    ];

    partial void OnSelectedItemChanged(string value)
    {
        var temp = (SelectedItem)?.ToString();
        if (!string.IsNullOrEmpty(temp))
        {
            string[] selectedLanguage = temp.Split(" ");
            try
            {
                Properties.Settings.Default.Language = selectedLanguage[0];
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
                MessageBox.Show($"Cultura '{selectedLanguage[0]}' inválida: {ex}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}




