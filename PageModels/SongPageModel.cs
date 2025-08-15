using CommunityToolkit.Mvvm.ComponentModel;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.PageModels;

[QueryProperty(nameof(Song), "song")]
public partial class SongPageModel : ObservableObject
{
    [ObservableProperty]
    private Song _song = new();
}
