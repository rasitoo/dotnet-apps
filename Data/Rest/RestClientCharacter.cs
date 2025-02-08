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
        int totalPages = page+2;
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
                    Character character = new()
                    {
                        Name = jsonCharacter.GetProperty("name").GetString(),
                        //Precio = jsonCharacter.GetProperty("status").GetDouble(),
                        //Location = new() { Name = jsonCharacter.GetProperty("species").GetString() },
                        Description = jsonCharacter.GetProperty("type").GetString(),
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
