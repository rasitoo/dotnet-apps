using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using System.Diagnostics;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Rest;

class RestClientAlbum(ApiClientService apiClientService) : IRestClient<Album>
{
    public int Offset { get; set; } = 0;
    public int Limit { get; set; } = 100;

    public async void Add(Album item)
    {
        try
        {
            var response = await apiClientService.PostJsonAsync("albums/", item);
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

    public async void Delete(Album item)
    {
        try
        {
            var response = await apiClientService.DeleteAsync($"albums/{item.Id}");
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
        throw new NotImplementedException();
    }

    public async Task<List<Album>> GetAll(int offset = 0, int Limit = 0)
    {
        throw new NotImplementedException();
    }

    public async void Update(Album item)
    {
        try
        {
            var response = await apiClientService.PutJsonAsync($"albums/{item.Id}", item);
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
