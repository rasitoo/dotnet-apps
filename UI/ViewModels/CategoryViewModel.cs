using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using P06_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P06_01_DI_Contactos_TAPIADOR_rodrigo.Services.Services;
using System.Collections.ObjectModel;
using System.Windows;

namespace P06_01_DI_Contactos_TAPIADOR_rodrigo.UI.ViewModels;

public partial class CategoryViewModel(IRepositoryService<Category> categoryService) : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Category> _categories = new(categoryService.GetAll());
    
    [ObservableProperty]
    private Category _selectedItem;

    [RelayCommand]
    private void Edit(Category category)
    {
        MessageBox.Show($"Editando la categoría:{_selectedItem.Name}");
    }

    [RelayCommand]
    private void Delete(Category category)
    {
        MessageBox.Show($"Borrando la categoría:{_selectedItem.Name}");

    }
}