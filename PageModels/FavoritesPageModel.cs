using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Messages;
using System.Collections.ObjectModel;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.PageModels;

public partial class FavoritesPageModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Song> _favoriteSongs = new();
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
    public FavoritesPageModel()
    {
        WeakReferenceMessenger.Default.Register<SongAddedToFavoritesMessage>(this, (r, m) =>
        {
            AddSongToFavorites(m.Value);
        });
    }

    private void AddSongToFavorites(Song value)
    {
        if(!FavoriteSongs.Contains(value))
            FavoriteSongs.Add(value);
    }
}
