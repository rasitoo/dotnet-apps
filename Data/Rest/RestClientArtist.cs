using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using System.Diagnostics;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Rest;

class RestClientArtist(ApiClientService apiClientService) : IRestClient<Artist>
{
    public int Offset { get; set; } = 0;
    public int Limit { get; set; } = 100;

    public async void Add(Artist item)
    {
        try
        {
            var response = await apiClientService.PostJsonAsync("artists/", item);
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

    public async void Delete(Artist item)
    {
        try
        {
            var response = await apiClientService.DeleteAsync($"artists/{item.Id}");
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
        throw new NotImplementedException();
    }

    public async Task<List<Artist>> GetAll(int offset = 0, int Limit = 0)
    {
        throw new NotImplementedException();
    }

    public async void Update(Artist item)
    {
        try
        {
            var response = await apiClientService.PutJsonAsync($"artists/{item.Id}", item);
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
