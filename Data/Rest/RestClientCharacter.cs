using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using System.Diagnostics;
using System.Text.Json;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Rest;

internal class RestClientCharacter(ApiClientService apiClientService) : IRestClient<Character>
{

    //Donde se hace el await???

    public void Add(Character item)
    {
        throw new NotImplementedException();
    }

    public void Delete(Character item)
    {
        throw new NotImplementedException();
    }

    public Character? Get(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Character>> GetAll()
    {
        int currentPage = 1;
        int totalPages = 1;
        List<Character> characters = new();

        while (currentPage <= totalPages)
        {
            string url = $"https://rickandmortyapi.com/api/character?page={currentPage}";
            try
            {
                JsonDocument doc = await apiClientService.GetJsonAsync(url);
                JsonElement info = doc.RootElement.GetProperty("info");
                //totalPages = info.GetProperty("pages").GetInt32();

                foreach (JsonElement jsonCharacter in doc.RootElement.GetProperty("results").EnumerateArray())
                {
                    Character character = new()
                    {
                        Name = jsonCharacter.GetProperty("name").GetString(),
                        //Precio = jsonCharacter.GetProperty("status").GetDouble(),
                        Location = new() { Name = jsonCharacter.GetProperty("species").GetString() },
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

            currentPage++;
        }

        return characters;
    }

    public void Update(Character item)
    {
        throw new NotImplementedException();
    }
}
