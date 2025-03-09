using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Rest;
using CommunityToolkit.Mvvm.Input;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.PageModels;


public partial class SearchPageModel : ObservableObject
{
    private readonly IRestClient<Genre> _genreService;
    private readonly IRestClient<Artist> _artistService;
    private readonly IRestClient<Album> _albumService;
    private readonly IRestClient<Song> _songService;
    private readonly IRestClient<Playlist> _playlistService;

    [ObservableProperty]
    private ObservableCollection<Genre> _genres = new();
    [ObservableProperty]
    private ObservableCollection<Artist> _artists = new();
    [ObservableProperty]
    private ObservableCollection<Album> _albums = new();
    [ObservableProperty]
    private ObservableCollection<Song> _songs = new();
    [ObservableProperty]
    private ObservableCollection<Playlist> _playlists = new();

    [ObservableProperty]
    private ObservableCollection<Genre> _filteredGenres = new();
    [ObservableProperty]
    private ObservableCollection<Artist> _filteredArtists = new();
    [ObservableProperty]
    private ObservableCollection<Album> _filteredAlbums = new();
    [ObservableProperty]
    private ObservableCollection<Song> _filteredSongs = new();
    [ObservableProperty]
    private ObservableCollection<Playlist> _filteredPlaylists = new();


    [ObservableProperty]
    private bool _genresLoading = true;
    [ObservableProperty]
    private string _searchText = string.Empty;
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

    public SearchPageModel(IRestClient<Genre> genreService, IRestClient<Artist> artistService, IRestClient<Album> albumService, IRestClient<Song> songService, IRestClient<Playlist> playlistService)
    {
        _genreService = genreService;
        _artistService = artistService;
        _albumService = albumService;
        _songService = songService;
        _playlistService = playlistService;

        LoadAsync();
    }

    private async void LoadAsync()
    {
        var genres = await _genreService.GetAll(0, 50);
        var artists = await _artistService.GetAll(0, 50);
        var albums = await _albumService.GetAll(0, 50);
        var songs = await _songService.GetAll(0, 50);
        var playlists = await _playlistService.GetAll(0, 50);

        LoadGenres(genres);
        LoadArtists(artists);
        LoadAlbums(albums);
        LoadSongs(songs);
        LoadPlaylists(playlists);
    }

    private void LoadGenres(List<Genre> genres)
    {
        Genres = new(genres);
        GenresLoading = false;
    }

    private void LoadArtists(List<Artist> artists)
    {
        Artists = new(artists);
    }

    private void LoadAlbums(List<Album> albums)
    {
        Albums = new(albums);
    }

    private void LoadSongs(List<Song> songs)
    {
        Songs = new(songs);
    }

    private void LoadPlaylists(List<Playlist> playlists)
    {
        Playlists = new(playlists);
    }

    private void FilterItems()
    {
        if (string.IsNullOrWhiteSpace(SearchText))
        {
            FilteredGenres = new(Genres);
            FilteredArtists = new(Artists);
            FilteredAlbums = new(Albums);
            FilteredSongs = new(Songs);
            FilteredPlaylists = new(Playlists);
        }
        else
        {
            var lowerSearchText = SearchText.ToLower();
            FilteredGenres = new(Genres.Where(g => g.Name.ToLower().Contains(lowerSearchText)));
            FilteredArtists = new(Artists.Where(a => a.Name.ToLower().Contains(lowerSearchText)));
            FilteredAlbums = new(Albums.Where(a => a.Title.ToLower().Contains(lowerSearchText)));
            FilteredSongs = new(Songs.Where(s => s.Title.ToLower().Contains(lowerSearchText)));
            FilteredPlaylists = new(Playlists.Where(p => p.Title.ToLower().Contains(lowerSearchText)));
        }
    }
    [RelayCommand]
    private void Search()
    {
        FilterItems();
    }


}


