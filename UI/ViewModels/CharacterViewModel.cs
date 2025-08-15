using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Services.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.UI.ViewModels;
public partial class CharacterViewModel : ObservableObject
{
    private IService<Location> _locationService;
    private IService<Character> _characterService;

    [ObservableProperty]
    private List<Location> _locations = [];
    [ObservableProperty]
    private ObservableCollection<Character> _characters = [];
    [ObservableProperty]
    private Character? _selectedCharacter = new() { Location = new() { Name = "Otros" } };
    [ObservableProperty]
    private string? _locationName;
    [ObservableProperty]
    private string? _name;
    [ObservableProperty]
    private string? _type;
    [ObservableProperty]
    private string? _status;
    [ObservableProperty]
    private int _currentPage = 1;
    [ObservableProperty]
    private int _totalPages;
    [ObservableProperty]
    private double _scrollPercentage = 0.0;

    public CharacterViewModel(IService<Location> locationService, IService<Character> characterService)
    {
        this._locationService = locationService;
        this._characterService = characterService;
        getCharacters();
    }

    private void LoadNextPage()
    {
        if (CurrentPage < TotalPages)
        {
            CurrentPage++;
            addCharacters();
        }
    }
    public async void getCharacters()
    {
        var paginatedCharacters = await _characterService.GetAll(CurrentPage);
        Characters = new ObservableCollection<Character>(paginatedCharacters);
        TotalPages = _characterService.TotalPages;
    }
    public async void addCharacters()
    {
        var paginatedCharacters = await _characterService.GetAll(CurrentPage);
        foreach (var character in paginatedCharacters)
        {
            Characters.Add(character);
        }
        TotalPages = _characterService.TotalPages;
    }

    public async void getLocations()
    {
        Locations = new(await _locationService.GetAll(CurrentPage));
    }

    protected async override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        base.OnPropertyChanged(e);
        if (e.PropertyName == nameof(SelectedCharacter))
        {
            LocationName = "";
            Name = SelectedCharacter?.Name;
            Type = SelectedCharacter?.Type;
            Status = SelectedCharacter?.Status;
            LocationName = (SelectedCharacter?.LocationId != null) ? (await _locationService.Get(SelectedCharacter.LocationId.Value))?.Name : null;
        }
        else if (e.PropertyName == nameof(ScrollPercentage))
        {
            if (ScrollPercentage >= 0.8)
            {
                LoadNextPage();
            }
        }
    }

    [RelayCommand]
    private void Save()
    {
        SelectedCharacter ??= new() { Location = new() { Name = "Otros" } };
        SelectedCharacter.Location ??= LocationExistsOrCreate("Otros");

        if (SelectedCharacter.Id != 0)
        {
            SelectedCharacter.Location = LocationExistsOrCreate(LocationName ?? "Otros");
            SelectedCharacter.Name = Name;
            SelectedCharacter.Type = Type;
            SelectedCharacter.Status = Status;
            _characterService.Update(SelectedCharacter);
            MessageBox.Show($"Se ha editado el charactero: {Name}");
        }
        else
        {
            Character pr = new() { Name = Name, Type = Type, Status = Status, Location = LocationExistsOrCreate(LocationName ?? "Otros") };
            _characterService.Add(pr);
            Characters.Add(pr);
            MessageBox.Show($"Se ha creado el charactero: {Name}");
        }
    }

    public Location? LocationExistsOrCreate(string nombre)
    {
        if (Locations == null)
        {
            return null;
        }
        var location = Locations.Find(c => c.Name?.Equals(nombre) == true);
        if (location != null)
        {
            return location;
        }
        var result = MessageBox.Show($"La localizacion '{nombre}' no existe. ¿Desea crearla?", "Localizacion no encontrada", MessageBoxButton.YesNo, MessageBoxImage.Question);
        if (result == MessageBoxResult.Yes)
        {
            Location newLocation = new() { Name = nombre };
            _locationService.Add(newLocation);
            return newLocation;
        }
        return null;
    }

    [RelayCommand]
    private void Delete()
    {
        if (SelectedCharacter != null && SelectedCharacter.Id != 0)
        {
            var result = MessageBox.Show($"¿Está seguro de que desea borrar el personaje: {Name}?", "Confirmar borrado", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                _characterService.Delete(SelectedCharacter);
                Characters.Remove(SelectedCharacter);
                MessageBox.Show("El personaje ha sido borrado.");
                Add();
            }
        }
        else
        {
            MessageBox.Show("No hay personaje seleccionado para borrar.");
        }
    }

    [RelayCommand]
    private void Add()
    {
        SelectedCharacter = new() { Location = new() { Name = "Otros" } };
    }
}