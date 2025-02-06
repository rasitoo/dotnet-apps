using CommunityToolkit.Mvvm.ComponentModel;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Services.Services;
using System.Collections.ObjectModel;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using System.Windows;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.UI.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Category> _categories;
    [ObservableProperty]
    private ObservableCollection<Product> _products;
    public ObservableCollection<ISeries>? AveragePriceByCategorySeries { get; }
    public ObservableCollection<ISeries>? ProductsByCategorySeries { get; }
    //public int? TotalProducts => Products.Count;
    public int TotalCategories => Categories.Count;
    //public int ProductsWithoutCategory => Products.Count(p => p.Category?.Name == "Sin categoría");
    private IRepositoryService<Category> _categoryService;
    private IRepositoryService<Product> _productService;
    public async void getProducts()
    {
        Products = new(await _productService.GetAll());

        if (Products.Count > 0)
        {
            MessageBox.Show(Products[0].Name);
        }
        else
        {
            MessageBox.Show("No se encontraron Productos.");
        }
    }
    public async void getCategories()
    {
        Categories = new(await _categoryService.GetAll());

        if (Categories.Count > 0)
        {
            MessageBox.Show(Categories[0].Name);
        }
        else
        {
            MessageBox.Show("No se encontraron Categorias.");
        }
    }
    public HomeViewModel(IRepositoryService<Product> productService, IRepositoryService<Category> categoryService)
    {
        _categoryService = categoryService;
        _productService = productService;
        getProducts();
        getCategories();
        AveragePriceByCategorySeries = CreateAveragePriceByCategory();
        ProductsByCategorySeries = CreateProductsByCategory();
    }

    private ObservableCollection<ISeries>? CreateProductsByCategory()
    {
        var series = new ObservableCollection<ISeries>();
        foreach (var category in Categories)
        {
            var products = Products.Where(p => p.Category?.Name == category.Name);
            series.Add(new PieSeries<int>
            {
                Name = category.Name,
                Values = new [] { products.Count() }
            });
        }
        return series;
    }

    private ObservableCollection<ISeries>? CreateAveragePriceByCategory()
    {
        var series = new ObservableCollection<ISeries>();
        foreach (var category in Categories)
        {
            var averagePrice = Products.Where(p => p.Category?.Name == category.Name).Average(p => p.Price) ?? 0;
            series.Add(new PieSeries<double>
            {
                Name = category.Name,
                Values = new[] { averagePrice }
            });
        }
        return series;
    }
}