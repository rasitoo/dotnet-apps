using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Services.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.UI.ViewModels;

public partial class LocationViewModel : ObservableObject
{
    private const double PageSize = 10;

    [ObservableProperty]
    private ObservableCollection<Location> _locations = [];
    [ObservableProperty]
    private ObservableCollection<Character>? _charactersByLocation = [];
    [ObservableProperty]
    private Location? _selectedItem = new();
    [ObservableProperty]
    private Character? _selectedCharacter;
    [ObservableProperty]
    private string? _locationName;
    [ObservableProperty]
    private int _currentPage = 1;
    [ObservableProperty]
    private int _totalPages;
    [ObservableProperty]
    private double _scrollPercentage = 0.0;

    private IService<Location> _locationService;
    private IService<Character> _characterService;

    public LocationViewModel(IService<Location> locationService, IService<Character> characterService)
    {
        this._locationService = locationService;
        this._characterService = characterService;
        LoadLocations();
    }
    public async void LoadLocations()
    {
        Locations = new(await _locationService.GetAll());
    }
    public async void LoadCharactersBySelectedLocation()
    {
        CharactersByLocation = [];
        CurrentPage = 0;
        if (SelectedItem != null)
        {
            var characters = (await _locationService.Get(SelectedItem.Id, CurrentPage, PageSize)).Characters;
            CharactersByLocation = new(characters);
            TotalPages = (int)Math.Ceiling(SelectedItem.ResidentsNum / PageSize);
            CurrentPage++;
        }
    }

    protected override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        base.OnPropertyChanged(e);
        if (e.PropertyName == nameof(SelectedItem))
        {
            LoadCharactersBySelectedLocation();
            LocationName = SelectedItem?.Name;
        }
        else if (e.PropertyName == nameof(ScrollPercentage))
        {
            if (ScrollPercentage >= 0.8)
            {
                LoadNextPageOfCharacters();
            }
        }
    }
    public async void LoadNextPageOfCharacters()
    {
        if (SelectedItem != null && CurrentPage < TotalPages)
        {
            CurrentPage++;
            var nextPageCharacters = (await _locationService.Get(SelectedItem.Id, CurrentPage, PageSize)).Characters;
            foreach (var character in nextPageCharacters)
            {
                CharactersByLocation.Add(character);
            }
        }
    }

    public async void addCharacters()
    {
        var paginatedCharacters = await _characterService.GetAll(CurrentPage);
        foreach (var character in paginatedCharacters)
        {
            CharactersByLocation.Add(character);
        }
        TotalPages = _characterService.TotalPages;
    }
    [RelayCommand]
    private void Save()
    {
        if (SelectedItem != null && SelectedItem.Name == "Sin localizacion")
        {
            MessageBox.Show("No se puede crear o editar una localizacion llamada 'Sin localizacion'.");
            return;
        }
        if (SelectedItem != null && SelectedItem.Id != 0)
        {
            SelectedItem.Name = LocationName;
            _locationService.Update(SelectedItem);
            MessageBox.Show($"Se ha editado la localizacion: {SelectedItem.Name}");
        }
        else
        {
            if (SelectedItem != null)
            {
                Location pr = new() { Name = LocationName };
                _locationService.Add(pr);
                Locations.Add(pr);
                MessageBox.Show($"Se ha creado la localizacion: {SelectedItem.Name}");
            }
        }
    }

    [RelayCommand]
    private void Delete()
    {
        if (SelectedItem != null && SelectedItem.Id != 0)
        {
            if (SelectedItem.Name == "Sin localizacion")
            {
                MessageBox.Show("No se puede borrar la localizacion 'Sin localizacion'.");
                return;
            }
            var result = MessageBox.Show($"¿Está seguro de que desea borrar la localizacion: {SelectedItem.Name}?", "Confirmar borrado", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                Location ct;
                var characters = _characterService.GetAll(1).Result.Where(p => p.LocationId == SelectedItem.Id).ToList();
                var location = Locations.ToList().Find(c => c.Name?.Equals("Sin localizacion") == true);
                if (location != null)
                {
                    ct = location;
                }
                else
                {
                    ct = new() { Name = "Sin localizacion" };
                    _locationService.Add(ct);
                }
                foreach (var character in characters)
                {
                    character.Location = ct;
                    character.LocationId = null;
                    _characterService.Update(character);
                }
                _locationService.Delete(SelectedItem);
                LoadLocations();
                Add();
                MessageBox.Show("La localizacion ha sido borrada.");
            }
        }
        else
        {
            MessageBox.Show("No hay localizacion seleccionada para borrar.");
        }
    }

    [RelayCommand]
    private void Add()
    {
        SelectedItem = new();
    }
}