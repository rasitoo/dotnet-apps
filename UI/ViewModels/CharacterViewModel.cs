using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Services.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Documents;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.UI.ViewModels;

public partial class CharacterViewModel : ObservableObject
{

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
    private IRepositoryService<Location> _locationService;
    private IRepositoryService<Character> _characterService;
    public CharacterViewModel(IRepositoryService<Location> locationService, IRepositoryService<Character> characterService)
    {
        this._locationService = locationService;
        this._characterService = characterService;
        getCharacters();
    }
    public async void getCharacters()
    {
        Characters = new(await _characterService.GetAll());

        if (Characters.Count > 0)
        {
            MessageBox.Show(Characters[0].Name);
        }
        else
        {
            MessageBox.Show("No se encontraron Categorias.");
        }
    }
    public async void getCategories()
    {
        Categories =  new(await _locationService.GetAll());

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
        //No me gusta usar este evento pero si no, se verían cambios de characters en las listas aunque
        //no se guardaran en la base de datos, además cambiaría el nombre de categoría a todos los prductos
        //en vez de cambiar la categoría del charactero concreto
        base.OnPropertyChanged(e);
        if (e.PropertyName == nameof(SelectedCharacter))
        {
            LocationName = SelectedCharacter?.Location?.Name;
            Name = SelectedCharacter?.Name;
            Desc = SelectedCharacter?.Description;
            Price = SelectedCharacter?.Price;
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