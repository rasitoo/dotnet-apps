﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Rest;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Messages;
using System.Collections.ObjectModel;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.PageModels;

[QueryProperty(nameof(Id), "id")]
public partial class GenrePageModel(IRestClient<Genre> genreRestClient, IRestClient<Album> albumRestClient) : ObservableObject
{
    [ObservableProperty]
    private int _id;
    partial void OnIdChanged(int value)
    {
        LoadAsync();
    }
    [ObservableProperty]
    private Genre _genre;
    [ObservableProperty]
    private bool _songsLoading = true;

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
    async private void LoadAsync()
    {
        Genre genre = await genreRestClient.Get(Id);
        LoadCoversAsync(genre);
        
    }
    private async void LoadCoversAsync(Genre? genre)
    {
        Dictionary<int, Album> albumsDict = new();
        if (genre.Songs != null)
        {
            foreach (Song song in genre.Songs)
            {
                if (song.Album_id != null)
                {
                    if (!albumsDict.ContainsKey(song.Album_id.Value))
                    {
                        var album = await albumRestClient.Get(song.Album_id.Value);
                        if (album != null)
                        {
                            albumsDict[song.Album_id.Value] = album;
                            song.Album = album;
                        }
                    }
                    else
                    {
                        song.Album = albumsDict[song.Album_id.Value];
                    }
                }
            }
        }
        Genre = genre;
        SongsLoading = false;

    }
    [RelayCommand]
    private void AddToFavorites(Song song)
    {
        //https://stackoverflow.com/questions/77090721/how-to-use-weakreferencemessenger-in-maui
        if (song != null)
        {
            WeakReferenceMessenger.Default.Send(new SongAddedToFavoritesMessage(song));
        }
    }
    [RelayCommand]
    private async void AddToPlaylist(Song song)
    {
        if (song != null)
        {
            await Shell.Current.GoToAsync("playlists", new ShellNavigationQueryParameters { { "song", song } });
        }
    }
}
