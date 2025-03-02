using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using System.Diagnostics;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Rest;

class RestClientGenre(ApiClientService apiClientService) : IRestClient<Genre>
{
    public int Offset { get; set; } = 0;
    public int Limit { get; set; } = 100;

    public async void Add(Genre item)
    {
        try
        {
            var response = await apiClientService.PostJsonAsync("genres/", item);
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

    public async void Delete(Genre item)
    {
        try
        {
            var response = await apiClientService.DeleteAsync($"genres/{item.Id}");
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
            var response = await apiClientService.GetJsonAsync($"genres/{id}");
            if (response != null)
            {
                var jsonGenre = response.RootElement;
                return new Genre
                {
                    Id = jsonGenre.GetProperty("id").GetInt32(),
                    Name = jsonGenre.GetProperty("name").GetString(),
                    Songs = new List<Genre>()
                };
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
        return null;
    }

    public async Task<List<Genre>> GetAll(int offset = 0, int limit = 0)
    {
        try
        {
            var response = await apiClientService.GetJsonAsync($"genres?offset={offset}&limit={limit}");
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
                        Songs = new List<Genre>()
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
            var response = await apiClientService.PutJsonAsync($"genres/{item.Id}", item);
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
