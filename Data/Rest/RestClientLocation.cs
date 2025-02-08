using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using System.Diagnostics;
using System.Text.Json;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Rest;

internal class RestClientLocation(ApiClientService apiClientService) : IRestClient<Location>
{
    public void Add(Location item)
    {
        throw new NotImplementedException();
    }

    public void Delete(Location item)
    {
        throw new NotImplementedException();
    }

    public async Task<Location?> Get(int id)
    {
        var characters = new List<Character>();
        Location? location = null;

        string url = $"https://rickandmortyapi.com/api/location/{id}";
        try
        {
            JsonDocument doc = await apiClientService.GetJsonAsync(url);
            JsonElement root = doc.RootElement;

            location = new Location
            {
                Id = root.GetProperty("id").GetInt32(),
                Name = root.GetProperty("name").GetString(),
                Characters = characters
            };

            foreach (JsonElement residentUrl in root.GetProperty("residents").EnumerateArray())
            {
                string residentUri = residentUrl.GetString();
                try
                {
                    JsonDocument residentDoc = await apiClientService.GetJsonAsync(residentUri);
                    JsonElement residentElement = residentDoc.RootElement;

                    Character character = new()
                    {
                        Id = residentElement.GetProperty("id").GetInt32(),
                        Name = residentElement.GetProperty("name").GetString(),
                        Description = residentElement.GetProperty("status").GetString(),
                        ImageUri = residentElement.GetProperty("image").GetString(),
                    };

                    characters.Add(character);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(@"\tERROR {0}", ex.Message);
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
        return location;
    }
    public async Task<List<Location>> GetAll()
    {
        int currentPage = 1;
        int totalPages = 1;
        List<Location> locations = new();

        while (currentPage <= totalPages)
        {
            string url = $"https://rickandmortyapi.com/api/location?page={currentPage}";
            try
            {
                JsonDocument doc = await apiClientService.GetJsonAsync(url);
                JsonElement info = doc.RootElement.GetProperty("info");
                totalPages = info.GetProperty("pages").GetInt32();

                foreach (JsonElement jsonLocation in doc.RootElement.GetProperty("results").EnumerateArray())
                {
                    Location location = new()
                    {
                        Id = jsonLocation.GetProperty("id").GetInt32(),
                        Name = jsonLocation.GetProperty("name").GetString(),
                        Characters = new List<Character>()
                    };
                    locations.Add(location);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            currentPage++;
        }

        return locations;
    }
    public void Update(Location item)
    {
        throw new NotImplementedException();
    }

}
