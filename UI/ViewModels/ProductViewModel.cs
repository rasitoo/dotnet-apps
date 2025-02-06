using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Services.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Documents;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.UI.ViewModels;

public partial class ProductViewModel : ObservableObject
{

    [ObservableProperty]
    private List<Category> _categories = [];
    [ObservableProperty]
    private ObservableCollection<Product> _products = [];
    [ObservableProperty]
    private Product? _selectedProduct = new() { Category = new() { Name = "Otros" } };
    [ObservableProperty]
    private string? _categoryName;    
    [ObservableProperty]
    private string? _name;    
    [ObservableProperty]
    private string? _desc;    
    [ObservableProperty]
    private double? _price;
    private IRepositoryService<Category> _categoryService;
    private IRepositoryService<Product> _productService;
    public ProductViewModel(IRepositoryService<Category> categoryService, IRepositoryService<Product> productService)
    {
        this._categoryService = categoryService;
        this._productService = productService;
        getProducts();
    }
    public async void getProducts()
    {
        Products = new(await _productService.GetAll());

        if (Products.Count > 0)
        {
            MessageBox.Show(Products[0].Name);
        }
        else
        {
            MessageBox.Show("No se encontraron Categorias.");
        }
    }
    public async void getCategories()
    {
        Categories =  new(await _categoryService.GetAll());

        if (Categories.Count > 0)
        {
            MessageBox.Show(Categories[0].Name);
        }
        else
        {
            MessageBox.Show("No se encontraron Categorias.");
        }
    }
    protected override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        //No me gusta usar este evento pero si no, se verían cambios de productos en las listas aunque
        //no se guardaran en la base de datos, además cambiaría el nombre de categoría a todos los prductos
        //en vez de cambiar la categoría del producto concreto
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
            SelectedProduct.Name = Name;
            SelectedProduct.Description = Desc;
            SelectedProduct.Price = Price;
            _productService.Update(SelectedProduct);
            MessageBox.Show($"Se ha editado el producto: {Name}");
        }
        else
        {
            Product pr = new() { Name = Name, Description = Desc, Price = Price, Category = CategoryExistsOrCreate(CategoryName ?? "Otros") };
            _productService.Add(pr);
            Products.Add(pr);
            MessageBox.Show($"Se ha creado el producto: {Name}");
        }
    }
    public Category? CategoryExistsOrCreate(string nombre)
    {
        if (Categories == null)
        {
            return null;
        }
        var category = Categories.Find(c => c.Name?.Equals(nombre) == true);
        if (category != null)
        {
            return category;
        }
        var result = MessageBox.Show($"La categoría '{nombre}' no existe. ¿Desea crearla?", "Categoría no encontrada", MessageBoxButton.YesNo, MessageBoxImage.Question);
        if (result == MessageBoxResult.Yes)
        {
            Category newCategory = new() { Name = nombre };
            _categoryService.Add(newCategory);
            return newCategory;
        }
        return null;
    }
    [RelayCommand]
    private void Delete()
    {
        if (SelectedProduct != null && SelectedProduct.Id != 0)
        {
            var result = MessageBox.Show($"¿Está seguro de que desea borrar el producto: {Name}?", "Confirmar borrado", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                _productService.Delete(SelectedProduct);
                Products.Remove(SelectedProduct);
                MessageBox.Show("El producto ha sido borrado.");
                Add();
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