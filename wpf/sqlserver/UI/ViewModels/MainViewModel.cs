using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using P06_01_DI_Contactos_TAPIADOR_rodrigo.UI.Views;
using System.Windows;

namespace P06_01_DI_Contactos_TAPIADOR_rodrigo.UI.ViewModels;


public partial class MainViewModel(HomeView homeView, ProductView productView, CategoryView categoryView, SettingsView settingsView, IServiceProvider serviceProvider) : ObservableObject
{
    [ObservableProperty]
    private object? _activeView = homeView;
    [RelayCommand]
    private void ActivateHomeView()
    {
        //Un poco trampa y bastante feo pero es la forma que se me ha ocurrido para que al borrar un producto o categoría se vea reflejado en el homeview
        var homeView = serviceProvider.GetRequiredService<HomeView>();
        homeView.DataContext = serviceProvider.GetRequiredService<HomeViewModel>();
        ActiveView = homeView;
    }
    [RelayCommand]
    private void ActivateProductView() => ActiveView = productView;
    [RelayCommand]
    private void ActivateCategoryView() => ActiveView = categoryView;
    [RelayCommand]
    private void ActivateSettingsView() => ActiveView = settingsView;
    [RelayCommand]
    private static void Exit() => Application.Current.Shutdown();
}