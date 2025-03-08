using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Rest;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.PageModels;

public partial class SearchPageModel : ObservableObject
{
    private readonly IRestClient<Genre> _genreService;
    [ObservableProperty]
    private ObservableCollection<Genre> _genres = new();
    [ObservableProperty]
    private bool _genresLoading = true;

    [ObservableProperty]
    private Genre? _selectedGenre;

    async partial void OnSelectedGenreChanged(Genre value)
    {
        if (value != null)
        {
            await Shell.Current.GoToAsync($"genre?id={value.Id}");
            SelectedGenre = null;
        }
    }
    public SearchPageModel(IRestClient<Genre> genreService)
    {
        _genreService = genreService;

        LoadAsync();
    }

    private async void LoadAsync()
    {
        List<Genre> genres = await _genreService.GetAll(0, 50);
        LoadGenres(genres);

    }

    private void LoadGenres(List<Genre> genres)
    {
        Genres = new(genres);
        GenresLoading = false;
    }

}
