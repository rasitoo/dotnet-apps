using CommunityToolkit.Mvvm.ComponentModel;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.PageModels;

[QueryProperty(nameof(Album), "album")]
public partial class AlbumPageModel : ObservableObject
{
    [ObservableProperty]
    private Album _album = new();
}
