using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using P06_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P06_01_DI_Contactos_TAPIADOR_rodrigo.Services.Services;
using P06_01_DI_Contactos_TAPIADOR_rodrigo.UI.Views;
using System.Collections.ObjectModel;
using System.Windows;

namespace P06_01_DI_Contactos_TAPIADOR_rodrigo.UI.ViewModels;



partial class MainViewModel(IRepositoryService<Product> productService,IRepositoryService<Category> categoryService) : ObservableObject
{

    [ObservableProperty]
    private ObservableCollection<Product> _products = new(productService.GetAll());
    [ObservableProperty]
    private ObservableCollection<Category> _categories = new(categoryService.GetAll());
    public HomeView HomeView { get; } = new HomeView();
    [ObservableProperty]
    private object _activeView;
    public ProductView ProductView { get; } = new ProductView();
    public CategoryView CategoryView { get; } = new CategoryView();    
    public SettingsView SettingsView { get; } = new SettingsView();
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

