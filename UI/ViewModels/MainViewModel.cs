using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.UI.Views;
using System.Windows;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.UI.ViewModels;


public partial class MainViewModel(HomeView homeView, CharacterView characterView, LocationView locationView, SettingsView settingsView, IServiceProvider serviceProvider) : ObservableObject
{
    [ObservableProperty]
    private object? _activeView = homeView;
    [RelayCommand]
    private void ActivateHomeView()
    {
        //Un poco trampa y bastante feo pero es la forma que se me ha ocurrido para que al borrar un character o location se vea reflejado en el homeview
        var homeView = serviceProvider.GetRequiredService<HomeView>();
        homeView.DataContext = serviceProvider.GetRequiredService<HomeViewModel>();
        ActiveView = homeView;
    }
    [RelayCommand]
    private void ActivateCharacterView() => ActiveView = characterView;
    [RelayCommand]
    private void ActivateLocationView() => ActiveView = locationView;
    [RelayCommand]
    private void ActivateSettingsView() => ActiveView = settingsView;
    [RelayCommand]
    private static void Exit() => Application.Current.Shutdown();
}