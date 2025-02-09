using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using System.Diagnostics;
using System.Text.Json;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Rest;

internal class RestClientCharacter(ApiClientService apiClientService) : IRestClient<Character>
{

    //Donde se hace el await???
    public int Total {get;set;}
    public int TotalPages {get;set;}
    public void Add(Character item)
    {
        throw new NotImplementedException();
    }

    public void Delete(Character item)
    {
        throw new NotImplementedException();
    }

    public Task<Character?> Get(int id)
    {
        throw new NotImplementedException();
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

    public void Update(Character item)
    {
        throw new NotImplementedException();
    }
}
