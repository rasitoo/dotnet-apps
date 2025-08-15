using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Rest;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Messages;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.PageModels;

[QueryProperty(nameof(Id), "id")]
[QueryProperty(nameof(MessagedSong), "song")]
public partial class PlaylistPageModel(IRestClient<Playlist> playlistRestClient, IRestClient<Song> songRestClient, IRestClient<Album> albumRestClient) : ObservableObject
{
    [ObservableProperty]
    private int _id;
    partial void OnIdChanged(int value)
    {
        if (Id == 0)
        {
            Playlist = new();
        }
        else
        {
            LoadAsync();
        }
    }

    [ObservableProperty]
    private Playlist _playlist = new();
    [ObservableProperty]
    private ObservableCollection<Song> _songs = new();
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
    private async void LoadAsync()
    {
        Playlist = await playlistRestClient.Get(Id);
        if (Playlist.Songs == null)
        {
            Playlist.Songs = new();
        }
        else
        {
            foreach (var song in Playlist.Songs)
            {
                song.Album = await albumRestClient.Get(song.Album_id ?? 0);
            }
        }
        Songs = new(Playlist.Songs);
    }
    [ObservableProperty]
    private Song? _messagedSong;
    partial void OnMessagedSongChanged(Song value)
    {
        if (value != null)
        {

            if (Playlist.Songs == null)
            {
                Playlist.Songs = new List<Song>();
            }
            if (!Playlist.Songs.Contains(value))
            {
                Playlist.Songs.Add(value);
                songRestClient.UpdatePlaylist(value.Id, Playlist.Id);
                Songs.Add(value);
            }
        }
    }
    [RelayCommand]
    private async Task Save()
    {
        if (Id == 0)
        {
            Playlist = await playlistRestClient.Add(Playlist);
            Id = Playlist.Id;
        }
        else
        {
            playlistRestClient.Update(Playlist);
        }
    }
    [RelayCommand]
    private void AddToFavorites(Song song)
    {
        //https://stackoverflow.com/questions/77090721/how-to-use-weakreferencemessenger-in-maui
        if (song != null)
        {
            WeakReferenceMessenger.Default.Send(new SongAddedToFavoritesMessage(song));
        }
    }
    [RelayCommand]
    private async void AddToPlaylist(Song song)
    {
        if (song != null)
        {
            await Shell.Current.GoToAsync("playlists", new ShellNavigationQueryParameters { { "song", song } });
        }
    }
}
