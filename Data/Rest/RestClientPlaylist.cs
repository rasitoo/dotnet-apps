using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using System.Diagnostics;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Rest;

class RestClientPlaylist(ApiClientService apiClientService) : IRestClient<Playlist>
{
    public int Offset { get; set; } = 0;
    public int Limit { get; set; } = 100;

    public async void Add(Playlist item)
    {
        try
        {
            var response = await apiClientService.PostJsonAsync("playlists/", item);
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

    public async void Delete(Playlist item)
    {
        try
        {
            var response = await apiClientService.DeleteAsync($"playlists/{item.Id}");
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
        throw new NotImplementedException();
    }

    public async Task<List<Playlist>> GetAll(int offset = 0, int Limit = 0)
    {
        throw new NotImplementedException();
    }

    public async void Update(Playlist item)
    {
        try
        {
            var response = await apiClientService.PutJsonAsync($"playlists/{item.Id}", item);
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
