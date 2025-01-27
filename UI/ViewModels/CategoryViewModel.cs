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
    private void Save()
    {
        if (SelectedItem != null && SelectedItem.Id != 0)
        {
            categoryService.Update(SelectedItem);
            MessageBox.Show($"Se ha editado la categoría: {SelectedItem.Name}");
        }
        else
        {
            if (SelectedItem != null)
            {
                Category pr = new() { Name = SelectedItem.Name };
                categoryService.Add(pr);
                Categories.Add(pr);
            }
        }
    }

    [RelayCommand]
    private void Delete()
    {
        if (SelectedItem != null)
        {
            var result = MessageBox.Show($"¿Está seguro de que desea borrar la categoría: {SelectedItem.Name}?", "Confirmar borrado", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                categoryService.Delete(SelectedItem);
                Categories.Remove(SelectedItem);
                MessageBox.Show("La categoría ha sido borrada.");
            }
        }
        else
        {
            MessageBox.Show("No hay categoría seleccionada para borrar.");
        }
    }
    [RelayCommand]
    private void Add()
    {
        SelectedItem = new();
    }
}