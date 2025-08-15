using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using System.Diagnostics;
using System.Text.Json;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Rest;

internal class RestClientCharacter(ApiClientService apiClientService) : IRestClient<Character>
{
    public int Total { get; set; }
    public int TotalPages { get; set; }

    public async void Add(Character item)
    {
        try
        {
            var response = await apiClientService.PostJsonAsync("https://rickandmortyapi.com/api/character", item);
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

    public async void Delete(Character item)
    {
        try
        {
            var response = await apiClientService.DeleteAsync($"https://rickandmortyapi.com/api/character/{item.Id}");
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

    public async Task<Character?> Get(int id, int subItemsPage = 0, double subItemsPerPage = 0)
    {
        try
        {
            var response = await apiClientService.GetJsonAsync($"https://rickandmortyapi.com/api/character/{id}");
            if (response != null)
            {
                var jsonCharacter = response.RootElement;
                var location = jsonCharacter.GetProperty("location").GetProperty("url").GetString().Split("/");
                return new Character
                {
                    Id = jsonCharacter.GetProperty("id").GetInt32(),
                    Name = jsonCharacter.GetProperty("name").GetString(),
                    Status = jsonCharacter.GetProperty("status").GetString(),
                    LocationId = int.Parse(location[^1]),
                    Type = jsonCharacter.GetProperty("type").GetString(),
                    ImageUri = jsonCharacter.GetProperty("image").GetString()
                };
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
        return null;
    }

    public async Task<List<Character>> GetAll(int page)
    {
        int totalPages = page;
        List<Character> characters = new();

        while (page <= totalPages)
        {
            string url = $"https://rickandmortyapi.com/api/character?page={page}";
            try
            {
                JsonDocument doc = await apiClientService.GetJsonAsync(url);
                JsonElement info = doc.RootElement.GetProperty("info");
                Total = info.GetProperty("count").GetInt32();
                TotalPages = info.GetProperty("pages").GetInt32();

                foreach (JsonElement jsonCharacter in doc.RootElement.GetProperty("results").EnumerateArray())
                {
                    var location = jsonCharacter.GetProperty("location").GetProperty("url").GetString().Split("/");
                    Character character = new()
                    {
                        Id = jsonCharacter.GetProperty("id").GetInt32(),
                        Name = jsonCharacter.GetProperty("name").GetString(),
                        Status = jsonCharacter.GetProperty("status").GetString(),
                        LocationId = int.Parse(location[^1]),
                        Type = jsonCharacter.GetProperty("type").GetString(),
                        ImageUri = jsonCharacter.GetProperty("image").GetString()
                    };
                    characters.Add(character);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            page++;
        }

        return characters;
    }

    public async void Update(Character item)
    {
        try
        {
            var response = await apiClientService.PutJsonAsync($"https://rickandmortyapi.com/api/character/{item.Id}", item);
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
