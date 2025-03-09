using CommunityToolkit.Mvvm.ComponentModel;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
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
}
