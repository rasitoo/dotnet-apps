using CommunityToolkit.Mvvm.ComponentModel;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using System.Collections.ObjectModel;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.PageModels;

public partial class PlaylistsPageModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Playlist> _playlists = new();
}
