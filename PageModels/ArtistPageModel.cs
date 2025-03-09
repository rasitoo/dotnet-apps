using CommunityToolkit.Mvvm.ComponentModel;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Rest;
using System.Collections.ObjectModel;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.PageModels;

[QueryProperty(nameof(Id), "id")]
public partial class ArtistPageModel : ObservableObject
{
    private readonly IRestClient<Artist> _artistService;
    private readonly IRestClient<Genre> _genreService;

    [ObservableProperty]
    private int _id;
    partial void OnIdChanged(int value)
    {
        LoadAsync();
    }
    [ObservableProperty]
    private Artist _artist = new();

    [ObservableProperty]
    private ObservableCollection<Song> _topSongs = new();
    [ObservableProperty]
    private ObservableCollection<Genre> _genres = new();

    [ObservableProperty]
    private bool _albumsLoading = true;
    [ObservableProperty]
    private bool _songsLoading = true;
    [ObservableProperty]
    private bool _genresLoading = true;

    [ObservableProperty]
    private Genre? _selectedGenre = new();

    async partial void OnSelectedGenreChanged(Genre value)
    {
        if(value != null)
        {
            await Shell.Current.GoToAsync($"genre?id={value.Id}");
            SelectedGenre = null;
        }
    }

    [ObservableProperty]
    private Album? _selectedAlbum = new();
    async partial void OnSelectedAlbumChanged(Album value)
    {
        if (value != null)
        {
            value.Artist = Artist;
            await Shell.Current.GoToAsync("album", new ShellNavigationQueryParameters { { "album", value } });
            SelectedAlbum = null;
        }
    }

    [ObservableProperty]
    private Song? _selectedSong = new();
    async partial void OnSelectedSongChanged(Song value)
    {
        if (value != null)
        {
            await Shell.Current.GoToAsync("song", new ShellNavigationQueryParameters { { "song", value } });
            SelectedSong = null;
        }
    }
    public ArtistPageModel(IRestClient<Artist> artistService, IRestClient<Genre> genreService)
    {
        _artistService = artistService;
        _genreService = genreService;
    }
    private async void LoadAsync()
    {
        Artist = await _artistService.Get(Id) ?? new Artist();
        AlbumsLoading = false;

        List<Genre> genres = await LoadGenresAsync();

        LoadSongs();
        LoadGenres(genres);
    }

    private async Task<List<Genre>> LoadGenresAsync()
    {
        List<Genre> genres = new();
        List<int> genresId = new();
        if (Artist.Albums != null)
        {
            foreach (Album album in Artist.Albums)
            {
                if (album.Songs != null)
                {
                    var song = album.Songs.First();
                    if (song.Genre_id != null && !genresId.Contains(song.Genre_id.Value))
                    {
                        genresId.Add(song.Genre_id.Value);
                        var genre = await _genreService.Get(song.Genre_id.Value);
                        if (genre != null)
                        {
                            genres.Add(genre);
                        }
                    }

                }
            }
        }
        return genres;
    }

    private void LoadSongs()
    {
        List<Song> songs = new();
        if (Artist.Albums != null)
        {
            foreach (Album album in Artist.Albums)
            {
                if (album.Songs != null)
                {
                    foreach (Song song in album.Songs)
                    {
                        song.Album = album;

                        if (songs.Count < 10)
                        {
                            songs.Add(song);
                        }
                        else
                        {
                            TopSongs = new(songs);
                            SongsLoading = false;
                        }
                    }
                }
            }
        }
        TopSongs = new(songs);
        SongsLoading = false;
    }

    private void LoadGenres(List<Genre> genres)
    {
        Genres = new(genres);
        GenresLoading = false;
    }
}
