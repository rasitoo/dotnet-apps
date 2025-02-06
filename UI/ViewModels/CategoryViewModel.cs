using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Services.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.UI.ViewModels;

public partial class CategoryViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Category> _categories = [];
    [ObservableProperty]
    private ObservableCollection<Product>? _productsByCategory = [];
    [ObservableProperty]
    private Category? _selectedItem = new();
    [ObservableProperty]
    private Product? _selectedProduct;
    [ObservableProperty]
    private string? _categoryName;

    private IRepositoryService<Category> _categoryService;
    private IRepositoryService<Product> _productService;

    public CategoryViewModel(IRepositoryService<Category> categoryService, IRepositoryService<Product> productService)
    {
        this._categoryService = categoryService;
        this._productService = productService;
        //getCategories();
        getProductsByCategory();
    }
    public async void getCategories()
    {
        Categories = new (await _categoryService.GetAll());

        if (Categories.Count > 0)
        {
            MessageBox.Show(Categories[0].Name);
        }
        else
        {
            MessageBox.Show("No se encontraron Categorias.");
        }
    }
    public async void getProductsByCategory()
    {
        ProductsByCategory = new ((await _productService.GetAll()).Where(p => p.CategoryId == SelectedItem?.Id));

        if (ProductsByCategory.Count > 0)
        {
            MessageBox.Show(ProductsByCategory[0].Name);
        }
        else
        {
            MessageBox.Show("No se encontraron Productos por categoria.");
        }
    }
    protected override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        base.OnPropertyChanged(e);
        if (e.PropertyName == nameof(SelectedItem))
        {
        //    Categories = new(categoryService.GetAll());
        //    ProductsByCategory = new(productService.GetAll().Where(p => p.CategoryId == SelectedItem?.Id));
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
            SelectedItem.Name = CategoryName;
            _categoryService.Update(SelectedItem);
            MessageBox.Show($"Se ha editado la categoría: {SelectedItem.Name}");
        }
        else
        {
            if (SelectedItem != null)
            {
                Category pr = new() { Name = CategoryName };
                _categoryService.Add(pr);
                Categories.Add(pr);
                MessageBox.Show($"Se ha creado la categoría: {SelectedItem.Name}");
            }
        }
    }
    [RelayCommand]
    private void Delete()
    {
        if (SelectedItem != null && SelectedItem.Id != 0)
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
                //var products = _productService.GetAll().Where(p => p.CategoryId == SelectedItem.Id).ToList();
                var category = Categories.ToList().Find(c => c.Name?.Equals("Sin categoría") == true);
                if (category != null)
                {
                    ct = category;
                }
                else
                {
                    ct = new() { Name = "Sin categoría" };
                    _categoryService.Add(ct);
                }
                //foreach (var product in products)
                //{
                //    product.Category = ct;
                //    product.CategoryId = null;
                //    productService.Update(product);
                //}
                _categoryService.Delete(SelectedItem);
                //Categories = new(_categoryService.GetAll());
                Add();
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