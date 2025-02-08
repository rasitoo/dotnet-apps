using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Services.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.UI.ViewModels;

//behavioours, endpoint para graficas
public partial class LocationViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Location> _categories = [];
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
    private int _totalPages = 1;

    private IRepositoryService<Location> _locationService;
    private IRepositoryService<Character> _characterService;

    public LocationViewModel(IRepositoryService<Location> locationService, IRepositoryService<Character> characterService)
    {
        this._locationService = locationService;
        this._characterService = characterService;
        LoadCategories();
        LoadCharactersBySelectedLocation();
    }
    public async void LoadCategories()
    {
        Categories = new(await _locationService.GetAll());

        if (Categories.Count > 0)
        {
            MessageBox.Show(Categories[0].Name);
        }
        else
        {
            MessageBox.Show("No se encontraron Categorias.");
        }
    }
    //private async Task LoadCharactersByLocationAsync(int? locationId)
    //{
    //    CharactersByLocation = new ObservableCollection<Character>();
    //    await foreach (var character in _characterService.GetAll())
    //    {
    //        if (character.LocationId == locationId)
    //        {
    //            CharactersByLocation.Add(character);
    //        }
    //    }
    //}
    public async void LoadCharactersBySelectedLocation()
    {
        if (SelectedItem != null)
        {
            CharactersByLocation = new ObservableCollection<Character>((await _locationService.Get(SelectedItem.Id)).Characters);
        }
    }
    //[RelayCommand]
    //private async void LoadNextPage()
    //{
    //    if (_currentPage < _totalPages)
    //    {
    //        _currentPage++;
    //        await LoadCharactersByLocationAsync(SelectedItem?.Id);
    //    }
    //}

    //[RelayCommand]
    //private async void LoadPreviousPage()
    //{
    //    if (_currentPage > 1)
    //    {
    //        _currentPage--;
    //        await LoadCharactersByLocationAsync(SelectedItem?.Id);
    //    }
    //}


    protected override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        base.OnPropertyChanged(e);
        if (e.PropertyName == nameof(SelectedItem))
        {
            LoadCharactersBySelectedLocation();
            LocationName = SelectedItem?.Name;
        }
    }

    [RelayCommand]
    private void Save()
    {
        if (SelectedItem != null && SelectedItem.Name == "Sin categoría")
        {
            MessageBox.Show("No se puede crear o editar una categoría llamada 'Sin categoría'.");
            return;
        }
        if (SelectedItem != null && SelectedItem.Id != 0)
        {
            SelectedItem.Name = LocationName;
            _locationService.Update(SelectedItem);
            MessageBox.Show($"Se ha editado la categoría: {SelectedItem.Name}");
        }
        else
        {
            if (SelectedItem != null)
            {
                Location pr = new() { Name = LocationName };
                _locationService.Add(pr);
                Categories.Add(pr);
                MessageBox.Show($"Se ha creado la categoría: {SelectedItem.Name}");
            }
        }
    }

    [RelayCommand]
    private void Delete()
    {
        if (SelectedItem != null && SelectedItem.Id != 0)
        {
            if (SelectedItem.Name == "Sin categoría")
            {
                MessageBox.Show("No se puede borrar la categoría 'Sin categoría'.");
                return;
            }
            var result = MessageBox.Show($"¿Está seguro de que desea borrar la categoría: {SelectedItem.Name}?", "Confirmar borrado", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                Location ct;
                var characters = _characterService.GetAll().Result.Where(p => p.LocationId == SelectedItem.Id).ToList();
                var location = Categories.ToList().Find(c => c.Name?.Equals("Sin categoría") == true);
                if (location != null)
                {
                    ct = location;
                }
                else
                {
                    ct = new() { Name = "Sin categoría" };
                    _locationService.Add(ct);
                }
                foreach (var character in characters)
                {
                    character.Location = ct;
                    character.LocationId = null;
                    _characterService.Update(character);
                }
                _locationService.Delete(SelectedItem);
                LoadCategories();
                Add();
                MessageBox.Show("La categoría ha sido borrada.");
            }
        }
        else
        {
            MessageBox.Show("No hay categoría seleccionada para borrar.");
        }
    }

    [RelayCommand]
    private void Add()
    {
        SelectedItem = new();
    }
}