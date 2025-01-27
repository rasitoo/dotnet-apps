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
    private Category? _selectedItem;


    [RelayCommand]
    private void Edit()
    {
        if (SelectedItem != null)
        {
            categoryService.Update(SelectedItem);
            MessageBox.Show($"Se ha editado el producto: {SelectedItem.Name}");
        }
        else
        {
            MessageBox.Show("No hay producto seleccionado para editar.");
        }
    }

    [RelayCommand]
    private void Delete()
    {
        if (SelectedItem != null)
        {
            var result = MessageBox.Show($"¿Está seguro de que desea borrar el producto: {SelectedItem.Name}?", "Confirmar borrado", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                categoryService.Delete(SelectedItem);
                Categories.Remove(SelectedItem);
                MessageBox.Show("El producto ha sido borrado.");
            }
        }
        else
        {
            MessageBox.Show("No hay producto seleccionado para borrar.");
        }
    }
}