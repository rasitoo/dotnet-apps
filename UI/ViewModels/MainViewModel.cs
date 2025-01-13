using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using P06_01_DI_Contactos_TAPIADOR_rodrigo.UI.Views;
using System.Windows;

namespace P06_01_DI_Contactos_TAPIADOR_rodrigo.UI.ViewModels;



partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private object _activeView;
    public HomeView HomeView { get; } = new HomeView();
    public ProductView ProductView { get; } = new ProductView();
    public CategoryView CategoryView { get; } = new CategoryView();    
    public SettingsView SettingsView { get; } = new SettingsView();
    public MainViewModel() => ActiveView = HomeView;
    [RelayCommand]
    private void ActivateHomeView() => ActiveView = HomeView;
    [RelayCommand]
    private void ActivateProductView() => ActiveView = ProductView;
    [RelayCommand]
    private void ActivateCategoryView() => ActiveView = CategoryView;    
    [RelayCommand]
    private void ActivateSettingsView() => ActiveView = SettingsView;
    [RelayCommand]
    private void Exit() => Application.Current.Shutdown();
}

