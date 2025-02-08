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
    private ObservableCollection<Location> _categories;
    [ObservableProperty]
    private ObservableCollection<Character> _characters;
    public ObservableCollection<ISeries>? AveragePriceByLocationSeries { get; }
    public ObservableCollection<ISeries>? CharactersByLocationSeries { get; }
    //public int? TotalCharacters => Characters.Count;
    //public int TotalCategories => Categories.Count;
    //public int CharactersWithoutLocation => Characters.Count(p => p.Location?.Name == "Sin categoría");
    private IService<Location> _locationService;
    private IService<Character> _characterService;
    public async void getCharacters()
    {
        Characters = new(await _characterService.GetAll(1));

        if (Characters.Count > 0)
        {
            MessageBox.Show(Characters[0].Name);
        }
        else
        {
            MessageBox.Show("No se encontraron Characteros.");
        }
    }
    public async void getCategories()
    {
        Categories = new(await _locationService.GetAll(1));

        if (Categories.Count > 0)
        {
            MessageBox.Show(Categories[0].Name);
        }
        else
        {
            MessageBox.Show("No se encontraron Categorias.");
        }
    }
    public HomeViewModel(IService<Character> characterService, IService<Location> locationService)
    {
        _locationService = locationService;
        _characterService = characterService;
        getCharacters();
        getCategories();
        AveragePriceByLocationSeries = CreateAveragePriceByLocation();
        CharactersByLocationSeries = CreateCharactersByLocation();
    }

    private ObservableCollection<ISeries>? CreateCharactersByLocation()
    {
        var series = new ObservableCollection<ISeries>();
        //foreach (var location in Categories)
        //{
        //    var characters = Characters.Where(p => p.Location?.Name == location.Name);
        //    series.Add(new PieSeries<int>
        //    {
        //        Name = location.Name,
        //        Values = new [] { characters.Count() }
        //    });
        //}
        return series;
    }

    private ObservableCollection<ISeries>? CreateAveragePriceByLocation()
    {
        var series = new ObservableCollection<ISeries>();
        //foreach (var location in Categories)
        //{
        //    var averagePrice = Characters.Where(p => p.Location?.Name == location.Name).Average(p => p.Price) ?? 0;
        //    series.Add(new PieSeries<double>
        //    {
        //        Name = location.Name,
        //        Values = new[] { averagePrice }
        //    });
        //}
        return series;
    }
}