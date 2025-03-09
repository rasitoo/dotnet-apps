using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using System.Diagnostics;
using System.Text.Json;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Rest;

public class RestClientGenre(ApiClientService apiClientService) : IRestClient<Genre>
{
    public int Offset { get; set; } = 0;
    public int Limit { get; set; } = 100;

    public async Task<Genre?> Add(Genre item)
    {
        try
        {
            var response = await apiClientService.PostJsonAsync("/genres/", item);
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

    public async void Delete(Genre item)
    {
        try
        {
            var response = await apiClientService.DeleteAsync($"/genres/{item.Id}");
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

    public async Task<Genre?> Get(int id)
    {
        try
        {
            var response = await apiClientService.GetJsonAsync($"/genres/{id}");
            if (response != null)
            {
                List<Song> songs = new();
                var jsonGenre = response.RootElement;
                if (jsonGenre.TryGetProperty("songs", out var jsonSongs))
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
                        songs.Add(song);
                    }
                }
                return new Genre
                {
                    Id = jsonGenre.GetProperty("id").GetInt32(),
                    Name = jsonGenre.GetProperty("name").GetString(),
                    Songs = songs
                };
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
        return null;
    }

    public async Task<List<Genre>> GetAll(int offset = 0, int limit = 100)
    {
        try
        {
            var response = await apiClientService.GetJsonAsync($"/genres?offset={offset}&limit={limit}");
            if (response != null)
            {
                var jsonGenres = response.RootElement;
                var genres = new List<Genre>();
                foreach (var jsonGenre in jsonGenres.EnumerateArray())
                {
                    genres.Add(new Genre
                    {
                        Id = jsonGenre.GetProperty("id").GetInt32(),
                        Name = jsonGenre.GetProperty("name").GetString(),
                        Songs = new List<Song>()
                    });
                }
                return genres;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
        return new List<Genre>();
    }
    public async void Update(Genre item)
    {
        try
        {
            var response = await apiClientService.PatchJsonAsync($"/genres/{item.Id}", item);
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
}
