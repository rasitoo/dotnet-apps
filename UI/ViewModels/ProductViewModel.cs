using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using P06_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P06_01_DI_Contactos_TAPIADOR_rodrigo.Services.Services;
using System.Collections.ObjectModel;
using System.Windows;

namespace P06_01_DI_Contactos_TAPIADOR_rodrigo.UI.ViewModels;

public partial class ProductViewModel(IRepositoryService<Product> productService) : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Product> _products = new(productService.GetAll());

    [ObservableProperty]
    private Product _selectedItem;

    [RelayCommand]
    private void Edit(Category category)
    {
        MessageBox.Show($"Editando el producto:{_selectedItem.Name}");
    }

    [RelayCommand]
    private void Delete(Category category)
    {
        MessageBox.Show($"Borrando el producto: {_selectedItem.Name}");

    }
}
