using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using P06_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P06_01_DI_Contactos_TAPIADOR_rodrigo.Services.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace P06_01_DI_Contactos_TAPIADOR_rodrigo.UI.ViewModels;

public partial class ProductViewModel(IRepositoryService<Product> productService, IRepositoryService<Category> categoryService) : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Product> _products = new(productService.GetAll());

    [ObservableProperty]
    private Product? _selectedItem = new();

    [ObservableProperty]
    private string? _categoryName;
    
    protected override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        base.OnPropertyChanged(e);
        if (e.PropertyName == nameof(SelectedItem))
        {
            CategoryName = SelectedItem?.Category?.Name;
        }
    }

    [RelayCommand]
    private void Save()
    {
        SelectedItem ??= new() { Category = new() { Name = "Otros" } };
        SelectedItem.Category ??= CategoryExistsOrCreate("Otros");

        if (SelectedItem.Id != 0)
        {
            SelectedItem.Category = CategoryExistsOrCreate(CategoryName ?? "Otros");
            productService.Update(SelectedItem);
            MessageBox.Show($"Se ha editado el producto: {SelectedItem.Name}");
        }
        else
        {
            Product pr = new() { Name = SelectedItem.Name, Description = SelectedItem.Description, Price = SelectedItem.Price, Category = CategoryExistsOrCreate(CategoryName ?? "Otros") };
            productService.Add(pr);
            Products.Add(pr);
            MessageBox.Show($"Se ha creado el producto: {SelectedItem.Name}");
        }
    }

    public Category? CategoryExistsOrCreate(string nombre)
    {
        var categories = categoryService.GetAll();
        if (categories == null)
        {
            return null;
        }

        var category = categories.Find(c => c.Name?.Equals(nombre) == true);
        if (category != null)
        {
            return category;
        }

        var result = MessageBox.Show($"La categoría '{nombre}' no existe. ¿Desea crearla?", "Categoría no encontrada", MessageBoxButton.YesNo, MessageBoxImage.Question);
        if (result == MessageBoxResult.Yes)
        {
            Category newCategory = new() { Name = nombre };
            categoryService.Add(newCategory);
            return newCategory;
        }

        return null;
    }
    [RelayCommand]
    private void Delete()
    {
        if (SelectedItem != null)
        {
            var result = MessageBox.Show($"¿Está seguro de que desea borrar el producto: {SelectedItem.Name}?", "Confirmar borrado", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                productService.Delete(SelectedItem);
                Products.Remove(SelectedItem);
                MessageBox.Show("El producto ha sido borrado.");
            }
        }
        else
        {
            MessageBox.Show("No hay producto seleccionado para borrar.");
        }
    }
    [RelayCommand]
    private void Add()
    {
        SelectedItem = new() { Category = new() { Name="Otros" } };
    }
}
