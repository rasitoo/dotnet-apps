using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Services.Services;
using System.Collections.ObjectModel;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.UI.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Location> _locations = [];
    [ObservableProperty]
    private ObservableCollection<Character> _characters = [];
    public ObservableCollection<ISeries>? AverageStatusByLocationSeries { get; }
    public ObservableCollection<ISeries>? CharactersByLocationSeries { get; }
    public int? TotalCharacters => _characterService.Total;
    public int? TotalLocations => _locationService.Total;
    //public int CharactersWithoutLocation => Characters.Count(p => p.Location?.Name == "Sin categoría");
    private IService<Location> _locationService;
    private IService<Character> _characterService;
    public async void getCharacters()
    {
        Characters = new(await _characterService.GetAll(1));
    }
    public async void getCategories()
    {
        Locations = new(await _locationService.GetAll(1));
    }
    public HomeViewModel(IService<Character> characterService, IService<Location> locationService)
    {
        _locationService = locationService;
        _characterService = characterService;
        getCharacters();
        getCategories();
        AverageStatusByLocationSeries = CreateAverageStatusByLocation();
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

    private ObservableCollection<ISeries>? CreateAverageStatusByLocation()
    {
        var series = new ObservableCollection<ISeries>();
        //foreach (var location in Categories)
        //{
        //    var averageStatus = Characters.Where(p => p.Location?.Name == location.Name).Average(p => p.Status) ?? 0;
        //    series.Add(new PieSeries<double>
        //    {
        //        Name = location.Name,
        //        Values = new[] { averageStatus }
        //    });
        //}
        return series;
    }
}