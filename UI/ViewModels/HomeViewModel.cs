using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Services.Services;
using System.Collections.ObjectModel;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.UI.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Location> _locations = [];
    public ObservableCollection<ISeries>? CharactersByLocationSeries { get; }
    public int? TotalCharacters => _characterService.Total;
    public int? TotalLocations => _locationService.Total;
    public int? LocationWithoutCharacters => Locations.Count(p => p.ResidentsNum == 0);
    private IService<Location> _locationService;
    private IService<Character> _characterService;
    public async void getLocations()
    {
        Locations = new(await _locationService.GetAll(1));
    }
    public HomeViewModel(IService<Character> characterService, IService<Location> locationService)
    {
        _locationService = locationService;
        _characterService = characterService;
        getLocations();
        CharactersByLocationSeries = CreateCharactersByLocation();
    }

    private ObservableCollection<ISeries>? CreateCharactersByLocation()
    {
        var series = new ObservableCollection<ISeries>();
        foreach (var location in Locations)
        {
            series.Add(new PieSeries<int>
            {
                Name = location.Name,
                Values = new [] { location.ResidentsNum }
            });
        }
        return series;
    }
}