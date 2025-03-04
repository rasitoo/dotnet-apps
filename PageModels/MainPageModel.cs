using CommunityToolkit.Mvvm.ComponentModel;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Services;
using System.Collections.ObjectModel;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.PageModels;

public partial class MainPageModel(IService<Artist> artistService, IService<Album> albumservice, IService<Song> songService, IService<Playlist> playlistService) : ObservableObject
{
    private readonly IService<Artist> _artistService = artistService;
    private readonly IService<Album> _albumService = albumservice;
    private readonly IService<Song> _songService = songService;
    private readonly IService<Playlist> _playlistService = playlistService;
    [ObservableProperty]
    private ObservableCollection<Artist> _artists = new ObservableCollection<Artist>();
    [ObservableProperty]
    private ObservableCollection<Album> _albums = new ObservableCollection<Album>();
    [ObservableProperty]
    private ObservableCollection<Song> _songs = new ObservableCollection<Song>();
    [ObservableProperty]
    private ObservableCollection<Playlist> _playlists = new ObservableCollection<Playlist>();
}
