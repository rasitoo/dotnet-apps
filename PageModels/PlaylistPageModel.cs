using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Rest;
using System.Threading.Tasks;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.PageModels;

[QueryProperty(nameof(Id), "id")]
public partial class PlaylistPageModel(IRestClient<Playlist> playlistRestClient) : ObservableObject
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
    private async void LoadAsync()
    {
        Playlist = await playlistRestClient.Get(Id);
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
}
