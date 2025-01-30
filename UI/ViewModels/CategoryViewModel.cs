using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using P06_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P06_01_DI_Contactos_TAPIADOR_rodrigo.Services.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace P06_01_DI_Contactos_TAPIADOR_rodrigo.UI.ViewModels;

public partial class CategoryViewModel(IRepositoryService<Category> categoryService, IRepositoryService<Product> productService) : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Category> _categories = new(categoryService.GetAll());
    [ObservableProperty]
    private ObservableCollection<Product>? _productsByCategory;
    [ObservableProperty]
    private Category? _selectedItem = new();
    [ObservableProperty]
    private Product? _selectedProduct;
    [ObservableProperty]
    private string? _categoryName;
    protected override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        base.OnPropertyChanged(e);
        if (e.PropertyName == nameof(SelectedItem))
        {
            Categories = new(categoryService.GetAll());
            ProductsByCategory = new(productService.GetAll().Where(p => p.CategoryId == SelectedItem?.Id));
            CategoryName = SelectedItem?.Name;
        }
    }
    [RelayCommand]
    private void Save()
    {
        if (SelectedItem != null && SelectedItem.Name == "Sin categoría")
        {
            MessageBox.Show("No se puede crear o editar una categoría llamada 'Sin categoría'.");
            return;
        }
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
                MessageBox.Show($"Se ha creado la categoría: {SelectedItem.Name}");
            }
        }
    }
    [RelayCommand]
    private void Delete()
    {
        if (SelectedItem != null)
        {
            if (SelectedItem.Name == "Sin categoría")
            {
                MessageBox.Show("No se puede borrar la categoría 'Sin categoría'.");
                return;
            }
            var result = MessageBox.Show($"¿Está seguro de que desea borrar la categoría: {SelectedItem.Name}?", "Confirmar borrado", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                Category ct;
                var products = productService.GetAll().Where(p => p.CategoryId == SelectedItem.Id).ToList();
                var category = Categories.ToList().Find(c => c.Name?.Equals("Sin categoría") == true);
                if (category != null)
                {
                    ct = category;
                }
                else
                {
                    ct = new() { Name = "Sin categoría" };
                    categoryService.Add(ct);
                }
                foreach (var product in products)
                {
                    product.Category = ct;
                    product.CategoryId = null;
                    productService.Update(product);
                }
                categoryService.Delete(SelectedItem);
                Categories = new(categoryService.GetAll());
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