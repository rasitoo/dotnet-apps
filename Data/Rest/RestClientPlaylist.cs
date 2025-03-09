using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using System.Diagnostics;
using System.Text.Json;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Rest;

public class RestClientPlaylist(ApiClientService apiClientService) : IRestClient<Playlist>
{
    public int Offset { get; set; } = 0;
    public int Limit { get; set; } = 100;

    public async Task<Playlist?> Add(Playlist item)
    {
        try
        {
            var response = await apiClientService.PostJsonAsync("/playlists/", item);
            if (response != null && response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var jsonPlaylist = JsonDocument.Parse(jsonString).RootElement;
                return new Playlist
                {
                    Id = jsonPlaylist.GetProperty("id").GetInt32(),
                    Title = jsonPlaylist.GetProperty("title").GetString(),
                    Description = jsonPlaylist.GetProperty("description").GetString(),
                    Songs = new List<Song>()
                };
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
        return null;

    }

    public async void Delete(Playlist item)
    {
        try
        {
            var response = await apiClientService.DeleteAsync($"/playlists/{item.Id}");
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

    public async Task<Playlist?> Get(int id)
    {
        try
        {
            var response = await apiClientService.GetJsonAsync($"/playlists/{id}");
            if (response != null)
            {
                var jsonPlaylist = response.RootElement;
                return new Playlist
                {
                    Id = jsonPlaylist.GetProperty("id").GetInt32(),
                    Title = jsonPlaylist.GetProperty("title").GetString(),
                    Description = jsonPlaylist.GetProperty("description").GetString(),
                    Songs = new List<Song>()
                };
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
        return null;
    }

    public async Task<List<Playlist>> GetAll(int offset = 0, int limit = 100)
    {
        try
        {
            var response = await apiClientService.GetJsonAsync($"/playlists?offset={offset}&limit={limit}");
            if (response != null)
            {
                var jsonPlaylists = response.RootElement;
                var playlists = new List<Playlist>();
                foreach (var jsonPlaylist in jsonPlaylists.EnumerateArray())
                {
                    playlists.Add(new Playlist
                    {
                        Id = jsonPlaylist.GetProperty("id").GetInt32(),
                        Title = jsonPlaylist.GetProperty("title").GetString(),
                        Description = jsonPlaylist.GetProperty("description").GetString(),
                        Songs = new List<Song>()
                    });
                }
                return playlists;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
        return new List<Playlist>();
    }

    public async void Update(Playlist item)
    {
        try
        {
            var response = await apiClientService.PatchJsonAsync($"/playlists/{item.Id}", item);
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
