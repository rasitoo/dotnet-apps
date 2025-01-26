using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using P06_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P06_01_DI_Contactos_TAPIADOR_rodrigo.Services.Services;
using P06_01_DI_Contactos_TAPIADOR_rodrigo.UI.Views;
using System.Collections.ObjectModel;
using System.Windows;

namespace P06_01_DI_Contactos_TAPIADOR_rodrigo.UI.ViewModels;


public partial class MainViewModel(HomeView homeView, ProductView productView, CategoryView categoryView, SettingsView settingsView) : ObservableObject
{
    [ObservableProperty]
    private object? _activeView = homeView;
    [RelayCommand]
    private void ActivateHomeView() => ActiveView = homeView;
    [RelayCommand]
    private void ActivateProductView() => ActiveView = productView;
    [RelayCommand]
    private void ActivateCategoryView() => ActiveView = categoryView;
    [RelayCommand]
    private void ActivateSettingsView() => ActiveView = settingsView;
    [RelayCommand]
    private void Exit() => Application.Current.Shutdown();
}

