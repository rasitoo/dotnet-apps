using CommunityToolkit.Mvvm.ComponentModel;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Rest;
using System.Collections.ObjectModel;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.PageModels;

public partial class MainPageModel(IRestClient<Artist> artistService, IRestClient<Album> albumservice, IRestClient<Song> songService, IRestClient<Playlist> playlistService) : ObservableObject
{
    private readonly IRestClient<Artist> _artistService = artistService;
    private readonly IRestClient<Album> _albumService = albumservice;
    private readonly IRestClient<Song> _songService = songService;
    private readonly IRestClient<Playlist> _playlistService = playlistService;
    [ObservableProperty]
    private ObservableCollection<Artist> _artists = new ObservableCollection<Artist>();
    [ObservableProperty]
    private ObservableCollection<Album> _albums = new ObservableCollection<Album>();
    [ObservableProperty]
    private ObservableCollection<Song> _songs = new ObservableCollection<Song>();
    [ObservableProperty]
    private ObservableCollection<Playlist> _playlists = new ObservableCollection<Playlist>();
}