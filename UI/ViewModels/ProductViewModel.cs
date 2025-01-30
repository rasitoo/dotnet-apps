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
    private Product? _selectedProduct = new() { ImageUri= "https://picsum.photos/250/250" };
    [ObservableProperty]
    private string? _categoryName;    
    [ObservableProperty]
    private string? _name;    
    [ObservableProperty]
    private string? _desc;    
    [ObservableProperty]
    private double? _price;
    protected override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        base.OnPropertyChanged(e);
        if (e.PropertyName == nameof(SelectedProduct))
        {
            CategoryName = SelectedProduct?.Category?.Name;
            Name = SelectedProduct?.Name;
            Desc = SelectedProduct?.Description;
            Price = SelectedProduct?.Price;
        }
    }
    [RelayCommand]
    private void Save()
    {
        SelectedProduct ??= new() { Category = new() { Name = "Otros" } };
        SelectedProduct.Category ??= CategoryExistsOrCreate("Otros");

        if (SelectedProduct.Id != 0)
        {
            SelectedProduct.Category = CategoryExistsOrCreate(CategoryName ?? "Otros");
            productService.Update(SelectedProduct);
            MessageBox.Show($"Se ha editado el producto: {SelectedProduct.Name}");
        }
        else
        {
            Product pr = new() { Name = SelectedProduct.Name, Description = SelectedProduct.Description, Price = SelectedProduct.Price, Category = CategoryExistsOrCreate(CategoryName ?? "Otros") };
            productService.Add(pr);
            Products.Add(pr);
            MessageBox.Show($"Se ha creado el producto: {SelectedProduct.Name}");
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
        if (SelectedProduct != null)
        {
            var result = MessageBox.Show($"¿Está seguro de que desea borrar el producto: {SelectedProduct.Name}?", "Confirmar borrado", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                productService.Delete(SelectedProduct);
                Products.Remove(SelectedProduct);
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
        SelectedProduct = new() { Category = new() { Name = "Otros" } };
    }
}