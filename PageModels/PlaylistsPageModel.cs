using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using System.Collections.ObjectModel;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.PageModels;

public partial class PlaylistsPageModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Playlist> _playlists = new();
    [ObservableProperty]
    private bool _playlistsLoading = true;
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

    [RelayCommand]
    private async void CreatePlaylist()
    {
        await Shell.Current.GoToAsync($"playlist?id=0");
    }
}
