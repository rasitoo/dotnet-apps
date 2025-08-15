using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Messages;
using System.Collections.ObjectModel;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.PageModels;

[QueryProperty(nameof(Album), "album")]
public partial class AlbumPageModel : ObservableObject
{
    [ObservableProperty]
    private Album _album = new();
    partial void OnAlbumChanged(Album value)
    {
        Songs = new(Album.Songs.OrderBy(song => song.Track_num));
    }
    [ObservableProperty]
    private ObservableCollection<Song> _songs;
    [ObservableProperty]
    private Song? _selectedSong = new();


    async partial void OnSelectedSongChanged(Song value)
    {
        if (value != null)
        {
            value.Album = Album;
            await Shell.Current.GoToAsync("song", new ShellNavigationQueryParameters { { "song", value } });
            SelectedSong = null;
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
