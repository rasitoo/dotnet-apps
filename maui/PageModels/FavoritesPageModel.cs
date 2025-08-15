using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Rest;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Messages;
using System.Collections.ObjectModel;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.PageModels;

public partial class FavoritesPageModel : ObservableObject
{
    private IRestClient<Song> _songRestClient;
    private IRestClient<Playlist> _playlistRestClient;
    private IRestClient<Album> _albumRestClient;
    [ObservableProperty]
    private ObservableCollection<Song> _favoriteSongs = new();
    [ObservableProperty]
    private Playlist _favoritesPlaylist = new();
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
    public FavoritesPageModel(IRestClient<Song> songRestClient,IRestClient<Playlist> playlistRestClient,IRestClient<Album> albumRestClient)
    {
        _songRestClient = songRestClient;
        _playlistRestClient = playlistRestClient;
        _albumRestClient = albumRestClient;
        WeakReferenceMessenger.Default.Register<SongAddedToFavoritesMessage>(this, (r, m) =>
        {
            AddSongToFavorites(m.Value);
        });
        LoadAsync();
    }

    private async  void LoadAsync()
    {
        var playlist = await _playlistRestClient.Get(1);
        FavoritesPlaylist = playlist;
        foreach (var song in FavoritesPlaylist.Songs)
        {
            song.Album = await _albumRestClient.Get(song.Album_id ?? 0);
        }
        FavoriteSongs = new(FavoritesPlaylist.Songs);
    }

    private async void AddSongToFavorites(Song value)
    {
        if (value != null)
        {
            var playlist = await _playlistRestClient.Get(1);
            if (playlist.Songs == null)
            {
                playlist.Songs = new List<Song>();
            }
            if (!playlist.Songs.Contains(value))
            {
                playlist.Songs.Add(value);
                _songRestClient.UpdatePlaylist(value.Id, playlist.Id);
                FavoriteSongs.Add(value);
            }
        }
        if (!FavoriteSongs.Contains(value))
            FavoriteSongs.Add(value);
    }
}
