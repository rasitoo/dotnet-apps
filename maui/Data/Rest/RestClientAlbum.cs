using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using System.Diagnostics;
using System.Text.Json;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Rest;

public class RestClientAlbum(ApiClientService apiClientService) : IRestClient<Album>
{
    public int Offset { get; set; } = 0;
    public int Limit { get; set; } = 100;

    public async Task<Album?> Add(Album item)
    {
        try
        {
            var response = await apiClientService.PostJsonAsync("/albums/", item);
            if (!response.IsSuccessStatusCode)
            {
                Debug.WriteLine(@"\tERROR {0}", response.ReasonPhrase);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
        return null;
    }

    public async void Delete(Album item)
    {
        try
        {
            var response = await apiClientService.DeleteAsync($"/albums/{item.Id}");
            if (!response.IsSuccessStatusCode)
            {
                Debug.WriteLine(@"\tERROR {0}", response.ReasonPhrase);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
    }

    public async Task<Album?> Get(int id)
    {
        try
        {
            var response = await apiClientService.GetJsonAsync($"/albums/{id}");
            if (response != null)
            {
                var jsonAlbum = response.RootElement;
                List<Song> songs = new();
                Artist artist = new();

                if (jsonAlbum.TryGetProperty("artist", out var jsonArtistElement))
                {
                    artist = new Artist
                    {
                        Id = jsonArtistElement.GetProperty("id").GetInt32(),
                        Name = jsonArtistElement.GetProperty("name").GetString() ?? string.Empty,
                        Artist_thumbnail = jsonArtistElement.GetProperty("artist_thumbnail").GetString(),
                        Artist_banner = jsonArtistElement.GetProperty("artist_banner").GetString()
                    };

                }
                if (jsonAlbum.TryGetProperty("songs", out var jsonSongs))
                {
                    foreach (var jsonSong in jsonSongs.EnumerateArray())
                    {
                        var song = new Song
                        {
                            Id = jsonSong.GetProperty("id").GetInt32(),
                            Title = jsonSong.GetProperty("title").GetString(),
                            Publisher = jsonSong.GetProperty("publisher").GetString(),
                            Year = jsonSong.TryGetProperty("year", out var NumElement) && NumElement.ValueKind != JsonValueKind.Null ? NumElement.GetInt32() : 0,
                            Track_num = jsonSong.TryGetProperty("track_num", out NumElement) && NumElement.ValueKind != JsonValueKind.Null ? NumElement.GetInt32() : 0,
                            File = jsonSong.GetProperty("file").GetString(),
                            Album_id = jsonSong.GetProperty("album_id").GetInt32(),
                            Genre_id = jsonSong.GetProperty("genre_id").GetInt32(),
                            Artist = artist
                        };
                        songs.Add(song);
                    }
                }
                return new Album
                {
                    Id = jsonAlbum.GetProperty("id").GetInt32(),
                    Artist_id = jsonAlbum.GetProperty("artist_id").GetInt32(),
                    Title = jsonAlbum.GetProperty("title").GetString(),
                    Picture = jsonAlbum.GetProperty("picture").GetString(),

                };
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
        return null;
    }

    public async Task<List<Album>> GetAll(int offset = 0, int limit = 100)
    {
        try
        {
            var response = await apiClientService.GetJsonAsync($"/albums?offset={offset}&limit={limit}");
            if (response != null)
            {
                var jsonAlbums = response.RootElement;
                var albums = new List<Album>();
                foreach (var jsonAlbum in jsonAlbums.EnumerateArray())
                {
                    List<Song> songs = new();
                    Artist artist = new();

                    if (jsonAlbum.TryGetProperty("artist", out var jsonArtistElement))
                    {

                        artist = new Artist
                        {
                            Id = jsonArtistElement.GetProperty("id").GetInt32(),
                            Name = jsonArtistElement.GetProperty("name").GetString() ?? string.Empty,
                            Artist_thumbnail = jsonArtistElement.GetProperty("artist_thumbnail").GetString(),
                            Artist_banner = jsonArtistElement.GetProperty("artist_banner").GetString()
                        };

                    }
                    if (jsonAlbum.TryGetProperty("songs", out var jsonSongs))
                    {
                        foreach (var jsonSong in jsonSongs.EnumerateArray())
                        {
                            var song = new Song
                            {
                                Id = jsonSong.GetProperty("id").GetInt32(),
                                Title = jsonSong.GetProperty("title").GetString(),
                                Publisher = jsonSong.GetProperty("publisher").GetString(),
                                Year = jsonSong.TryGetProperty("year", out var NumElement) && NumElement.ValueKind != JsonValueKind.Null ? NumElement.GetInt32() : 0,
                                Track_num = jsonSong.TryGetProperty("track_num", out NumElement) && NumElement.ValueKind != JsonValueKind.Null ? NumElement.GetInt32() : 0,
                                File = jsonSong.GetProperty("file").GetString(),
                                Album_id = jsonSong.GetProperty("album_id").GetInt32(),
                                Genre_id = jsonSong.GetProperty("genre_id").GetInt32(),
                                Artist = artist
                            };
                            songs.Add(song);
                        }
                    }
                    albums.Add(new Album
                    {
                        Id = jsonAlbum.GetProperty("id").GetInt32(),
                        Artist_id = jsonAlbum.GetProperty("artist_id").GetInt32(),
                        Title = jsonAlbum.GetProperty("title").GetString(),
                        Picture = jsonAlbum.GetProperty("picture").GetString(),
                        Artist = artist,
                        Songs = songs
                    });
                }
                return albums;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
        return new List<Album>();
    }

    public async void Update(Album item)
    {
        try
        {
            var response = await apiClientService.PatchJsonAsync($"/albums/{item.Id}", item);
            if (!response.IsSuccessStatusCode)
            {
                Debug.WriteLine(@"\tERROR {0}", response.ReasonPhrase);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
    }

    public void UpdatePlaylist(int id1, int id2)
    {
        throw new NotImplementedException();
    }
}
