using Microsoft.Extensions.DependencyInjection;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Services.Services;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.UI.ViewModels;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.UI.Views;
using System.Windows;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo;


public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        try
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider() ?? throw new InvalidOperationException("ServiceProvider no se pudo inicializar.");

            var mainWindow = serviceProvider.GetService<MainWindow>() ?? throw new InvalidOperationException("MainWindow no se pudo inicializar.");
            mainWindow.DataContext = serviceProvider.GetRequiredService<MainViewModel>();
            mainWindow.Show();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            Current.Shutdown();
        }
    }
    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<MainWindow>();
        services.AddTransient<MainViewModel>();
        services.AddTransient<CategoryView>();
        services.AddTransient<CategoryViewModel>();
        services.AddTransient<ProductView>();
        services.AddTransient<ProductViewModel>();
        services.AddTransient<SettingsView>();
        services.AddTransient<SettingsViewModel>();
        services.AddTransient<HomeView>();
        services.AddTransient<HomeViewModel>();
        //services.AddScoped<IRepository<Product>, ProductRepository>();
        //services.AddScoped<IRepository<Category>, CategoryRepository>();
        services.AddScoped<IRepositoryService<Product>, ProductService>();
        services.AddScoped<IRepositoryService<Category>, CategoryService>();
    }
}