using CommunityToolkit.Mvvm.ComponentModel;
using LiveCharts.Wpf;
using LiveCharts;
using P06_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P06_01_DI_Contactos_TAPIADOR_rodrigo.Services.Services;
using System.Collections.ObjectModel;

namespace P06_01_DI_Contactos_TAPIADOR_rodrigo.UI.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Category> categories;
    [ObservableProperty]
    private ObservableCollection<Product> products;
    public SeriesCollection? AveragePriceByCategorySeries { get; }
    public SeriesCollection? ProductsByCategorySeries { get; }
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

    private SeriesCollection? CreateProductsByCategory()
    {
        var series = new SeriesCollection();
        foreach (var category in Categories)
        {
            var products = Products.Where(p => p.Category?.Name == category.Name);
            series.Add(new PieSeries
            {
                Title = category.Name,
                Values = new ChartValues<int> { products.Count() }
            });
        }
        return series;
    }

    private SeriesCollection? CreateAveragePriceByCategory()
    {
        var series = new SeriesCollection();
        foreach (var category in Categories)
        {
            var averagePrice = Products.Where(p => p.Category?.Name == category.Name).Average(p => p.Price) ?? 0;
            series.Add(new PieSeries
            {
                Title = category.Name,
                Values = new ChartValues<double> { averagePrice }
            });
        }
        return series;
    }
}