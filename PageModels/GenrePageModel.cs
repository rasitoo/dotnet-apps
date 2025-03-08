using CommunityToolkit.Mvvm.ComponentModel;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.PageModels;

[QueryProperty(nameof(Id), "id")]
public partial class GenrePageModel : ObservableObject
{
    [ObservableProperty]
    private int _id;
    partial void OnIdChanged(int value)
    {
        LoadAsync();
    }
    [ObservableProperty]
    private Genre _genre;
    async private void LoadAsync()
    {
        throw new NotImplementedException();
    }
}
