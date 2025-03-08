using CommunityToolkit.Mvvm.ComponentModel;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.PageModels;

[QueryProperty(nameof(Id), "id")]
public partial class PlaylistPageModel : ObservableObject
{
    [ObservableProperty]
    private int _id;
    [ObservableProperty]
    private Playlist _playlist;
}
