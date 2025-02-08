using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Services.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using static SkiaSharp.HarfBuzz.SKShaper;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.UI.ViewModels;
public partial class CharacterViewModel : ObservableObject
{
    private const int PageSize = 10;

    private IService<Location> _locationService;
    private IService<Character> _characterService;

    [ObservableProperty]
    private List<Location> _categories = [];
    [ObservableProperty]
    private ObservableCollection<Character> _characters = [];
    [ObservableProperty]
    private Character? _selectedCharacter = new() { Location = new() { Name = "Otros" } };
    [ObservableProperty]
    private string? _locationName;
    [ObservableProperty]
    private string? _name;
    [ObservableProperty]
    private string? _desc;
    [ObservableProperty]
    private double? _price;
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
        var paginatedCharacters =  await _characterService.GetAll(CurrentPage);
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

    public async void getCategories()
    {
        Categories = new(await _locationService.GetAll(CurrentPage));

        if (Categories.Count > 0)
        {
            MessageBox.Show(Categories[0].Name);
        }
        else
        {
            MessageBox.Show("No se encontraron Categorias.");
        }
    }

    protected override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        base.OnPropertyChanged(e);
        if (e.PropertyName == nameof(SelectedCharacter))
        {
            LocationName = SelectedCharacter?.Location?.Name;
            Name = SelectedCharacter?.Name;
            Desc = SelectedCharacter?.Description;
            Price = SelectedCharacter?.Price;
        }
        else if (e.PropertyName == nameof(ScrollPercentage))
        {
        //    if(ScrollPercentage <= 0.1)
        //    {
        //        LoadPreviousPage();
        //    }
        //    else 
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
            SelectedCharacter.Description = Desc;
            SelectedCharacter.Price = Price;
            _characterService.Update(SelectedCharacter);
            MessageBox.Show($"Se ha editado el charactero: {Name}");
        }
        else
        {
            Character pr = new() { Name = Name, Description = Desc, Price = Price, Location = LocationExistsOrCreate(LocationName ?? "Otros") };
            _characterService.Add(pr);
            Characters.Add(pr);
            MessageBox.Show($"Se ha creado el charactero: {Name}");
        }
    }

    public Location? LocationExistsOrCreate(string nombre)
    {
        if (Categories == null)
        {
            return null;
        }
        var location = Categories.Find(c => c.Name?.Equals(nombre) == true);
        if (location != null)
        {
            return location;
        }
        var result = MessageBox.Show($"La categoría '{nombre}' no existe. ¿Desea crearla?", "Categoría no encontrada", MessageBoxButton.YesNo, MessageBoxImage.Question);
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
            var result = MessageBox.Show($"¿Está seguro de que desea borrar el charactero: {Name}?", "Confirmar borrado", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                _characterService.Delete(SelectedCharacter);
                Characters.Remove(SelectedCharacter);
                MessageBox.Show("El charactero ha sido borrado.");
                Add();
            }
        }
        else
        {
            MessageBox.Show("No hay charactero seleccionado para borrar.");
        }
    }

    [RelayCommand]
    private void Add()
    {
        SelectedCharacter = new() { Location = new() { Name = "Otros" } };
    }
}