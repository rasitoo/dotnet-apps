using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Services.Services;
using System.Collections.ObjectModel;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.UI.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Location> _locations = new();
    public ObservableCollection<ISeries>? CharactersByLocationSeries { get; private set; }
    public int? TotalCharacters => _characterService.Total;
    public int? TotalLocations => _locationService.Total;
    public int? LocationWithoutCharacters => Locations.Count(p => p.ResidentsNum == 0);
    private readonly IService<Location> _locationService;
    private readonly IService<Character> _characterService;

    public HomeViewModel(IService<Character> characterService, IService<Location> locationService)
    {
        _locationService = locationService;
        _characterService = characterService;
        InitializeAsync();
    }

    private async void InitializeAsync()
    {
        await GetLocationsAsync();
        CharactersByLocationSeries = CreateCharactersByLocation();
    }

    public async Task GetLocationsAsync()
    {
        Locations = new(await _locationService.GetAll(1));
    }
    private ObservableCollection<ISeries>? CreateCharactersByLocation()
    {
        var locations = Locations.ToArray();
        if (locations == null || locations.Count() == 0)
        {
            return null;
        }

        var series = new ObservableCollection<ISeries>();
        foreach (var location in locations)
        {
            if (location != null)
            {
                series.Add(new PieSeries<int>
                {
                    Name = location.Name ?? "Unknown",
                    Values = new[] { location.ResidentsNum }
                });
            }
        }
        return series;
    }

    [RelayCommand]
    private async void RefreshData()
    {
        CharactersByLocationSeries = CreateCharactersByLocation();
        OnPropertyChanged(nameof(CharactersByLocationSeries));
        OnPropertyChanged(nameof(TotalCharacters));
        OnPropertyChanged(nameof(TotalLocations));
        OnPropertyChanged(nameof(LocationWithoutCharacters));
    }
}