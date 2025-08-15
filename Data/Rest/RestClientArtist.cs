using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using System.Diagnostics;
using System.Text.Json;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Rest;

public class RestClientArtist(ApiClientService apiClientService) : IRestClient<Artist>
{
    public int Offset { get; set; } = 0;
    public int Limit { get; set; } = 100;

    public async Task<Artist?> Add(Artist item)
    {
        try
        {
            var response = await apiClientService.PostJsonAsync("/artists/", item);
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

    public async void Delete(Artist item)
    {
        try
        {
            var response = await apiClientService.DeleteAsync($"/artists/{item.Id}");
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

    public async Task<Artist?> Get(int id)
    {

        try
        {
            var response = await apiClientService.GetJsonAsync($"/artists/{id}");
            if (response != null)
            {
                var jsonArtist = response.RootElement;
                var artist = new Artist
                {
                    Id = jsonArtist.GetProperty("id").GetInt32(),
                    Name = jsonArtist.GetProperty("name").GetString(),
                    Artist_thumbnail = jsonArtist.GetProperty("artist_thumbnail").GetString(),
                    Artist_banner = jsonArtist.GetProperty("artist_banner").GetString(),
                    Albums = new List<Album>()
                };

                if (jsonArtist.TryGetProperty("albums", out var jsonAlbums))
                {
                    foreach (var jsonAlbum in jsonAlbums.EnumerateArray())
                    {
                        var album = new Album
                        {
                            Id = jsonAlbum.GetProperty("id").GetInt32(),
                            Title = jsonAlbum.GetProperty("title").GetString(),
                            Picture = jsonAlbum.GetProperty("picture").GetString(),
                            Artist_id = jsonAlbum.GetProperty("artist_id").GetInt32(),
                            Songs = new List<Song>()
                        };

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

                                    Genre_id = jsonSong.GetProperty("genre_id").GetInt32()
                                };
                                album.Songs.Add(song);
                            }
                        }
                        artist.Albums.Add(album);
                    }
                }
                return artist;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
        return null;
    }

    public async Task<List<Artist>> GetAll(int offset = 0, int limit = 100)
    {
        try
        {
            var response = await apiClientService.GetJsonAsync($"/artists?offset={offset}&limit={limit}");
            if (response != null)
            {
                var jsonArtists = response.RootElement;
                var artists = new List<Artist>();
                foreach (var jsonArtist in jsonArtists.EnumerateArray())
                {
                    artists.Add(new Artist
                    {
                        Id = jsonArtist.GetProperty("id").GetInt32(),
                        Name = jsonArtist.GetProperty("name").GetString(),
                        Artist_thumbnail = jsonArtist.GetProperty("artist_thumbnail").GetString(),
                        Artist_banner = jsonArtist.GetProperty("artist_banner").GetString(),
                        Albums = new List<Album>()
                    });
                }
                return artists;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
        return new List<Artist>();
    }

    public async void Update(Artist item)
    {
        try
        {
            var response = await apiClientService.PatchJsonAsync($"/artists/{item.Id}", item);
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
