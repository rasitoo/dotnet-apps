using CommunityToolkit.Mvvm.ComponentModel;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Services.Services;
using System.Collections.ObjectModel;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.UI.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Category> categories;
    [ObservableProperty]
    private ObservableCollection<Product> products;
    public ObservableCollection<ISeries>? AveragePriceByCategorySeries { get; }
    public ObservableCollection<ISeries>? ProductsByCategorySeries { get; }
    public int TotalProducts => Products.Count;
    public int TotalCategories => Categories.Count;
    public int ProductsWithoutCategory => Products.Count(p => p.Category?.Name == "Sin categoría");
    public HomeViewModel(IRepositoryService<Product> productService, IRepositoryService<Category> categoryService)
    {
        categories = new(categoryService.GetAll());
        products = new(productService.GetAll());
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