using CommunityToolkit.Mvvm.ComponentModel;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Rest;
using System.Collections.ObjectModel;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.PageModels;

public partial class MainPageModel : ObservableObject
{
    private readonly IRestClient<Artist> _artistService;
    private readonly IRestClient<Album> _albumService;
    private readonly IRestClient<Song> _songService;
    private readonly IRestClient<Playlist> _playlistService;

    [ObservableProperty]
    private ObservableCollection<Artist> _artists = new();
    [ObservableProperty]
    private ObservableCollection<Album> _albums = new();
    [ObservableProperty]
    private ObservableCollection<Song> _songs = new();
    [ObservableProperty]
    private ObservableCollection<Playlist> _playlists = new();

    [ObservableProperty]
    private bool _playlistsLoading = true;
    [ObservableProperty]
    private bool _albumsLoading = true;
    [ObservableProperty]
    private bool _songsLoading = true;
    [ObservableProperty]
    private bool _artistsLoading = true;

    [ObservableProperty]
    private Artist? _selectedArtist;

    async partial void OnSelectedArtistChanged(Artist value)
    {
        if (value != null)
        {
            await Shell.Current.GoToAsync($"artist?id={value.Id}");
            SelectedArtist = null;
        }
    }

    [ObservableProperty]
    private Album? _selectedAlbum = new();
    async partial void OnSelectedAlbumChanged(Album value)
    {
        if(value != null)
        {
            foreach (Song song in value.Songs)
            {
                song.Album = value;
            }
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

    [ObservableProperty]
    private Playlist? _selectedPlaylist = new();
    async partial void OnSelectedPlaylistChanged(Playlist value)
    {
        if (value != null)
        {
            await Shell.Current.GoToAsync($"playlist?id={value.Id}");
            SelectedPlaylist = null;
        }
    }

    public MainPageModel(IRestClient<Artist> artistService, IRestClient<Album> albumservice, IRestClient<Song> songService, IRestClient<Playlist> playlistService)
    {
        _artistService = artistService;
        _albumService = albumservice;
        _songService = songService;
        _playlistService = playlistService;

        LoadAsync();
    }

    private async void LoadAsync()
    {
        List<Artist> artists = await _artistService.GetAll(0, 100);
        List<Album> albums = await _albumService.GetAll(0, 100);
        List<Song> songs = await _songService.GetAll(0, 200);
        List<Playlist> playlists = await _playlistService.GetAll(0, 100);
        LoadArtists(artists);
        LoadSongs(songs);
        LoadPlaylists(playlists);
        LoadAlbums(albums);

    }

    private void LoadArtists(List<Artist> artists)
    {
        Artists = new(artists);
        ArtistsLoading = false;
    }

    private void LoadAlbums(List<Album> albums)
    {
        Albums = new(albums);
        AlbumsLoading = false;
    }

    private void LoadSongs(List<Song> songs)
    {
        Songs = new(songs);
        SongsLoading = false;
    }

    private void LoadPlaylists(List<Playlist> playlists)
    {
        foreach (var playlist in playlists)
        {
            if (playlist.Songs == null)
            {
                playlist.Songs = new List<Song>();
            }
        }
        Playlists = new(playlists);
        PlaylistsLoading = false;

    }

}