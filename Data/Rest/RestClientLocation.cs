using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using System.Diagnostics;
using System.Text.Json;
using System.Windows;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Rest;

internal class RestClientLocation(ApiClientService apiClientService) : IRestClient<Location>
{
    public int Total { get; set; }
    public int TotalPages { get; set; } = 1;

    public async void Add(Location item)
    {
        try
        {
            var response = await apiClientService.PostJsonAsync("https://rickandmortyapi.com/api/location", item);
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

    public async void Delete(Location item)
    {
        try
        {
            var response = await apiClientService.DeleteAsync($"https://rickandmortyapi.com/api/location/{item.Id}");
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

    public async Task<Location?> Get(int id, int subItemPage = 0, double subItemsPerPage = 0)
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
                ResidentsNum = root.GetProperty("residents").EnumerateArray().Count(),
                Characters = characters
            };
            int start = (int)(subItemPage * subItemsPerPage);
            int end = start + (int)subItemsPerPage;
            for (int i = start; i < end && i < root.GetProperty("residents").GetArrayLength(); i++)
            {
                JsonElement residentUrl = root.GetProperty("residents")[i];
                string residentUri = residentUrl.GetString();
                try
                {
                    JsonDocument residentDoc = await apiClientService.GetJsonAsync(residentUri);
                    JsonElement residentElement = residentDoc.RootElement;

                    Character character = new()
                    {
                        Id = residentElement.GetProperty("id").GetInt32(),
                        Name = residentElement.GetProperty("name").GetString(),
                        Type = residentElement.GetProperty("status").GetString(),
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

    public async Task<List<Location>> GetAll(int page = 1)
    {
        List<Location> locations = new();

        while (page <= TotalPages)
        {
            string url = $"https://rickandmortyapi.com/api/location?page={page}";
            try
            {
                JsonDocument doc = await apiClientService.GetJsonAsync(url);
                JsonElement info = doc.RootElement.GetProperty("info");
                TotalPages = info.GetProperty("pages").GetInt32();
                Total = info.GetProperty("count").GetInt32();

                foreach (JsonElement jsonLocation in doc.RootElement.GetProperty("results").EnumerateArray())
                {
                    Location location = new()
                    {
                        Id = jsonLocation.GetProperty("id").GetInt32(),
                        Name = jsonLocation.GetProperty("name").GetString(),
                        ResidentsNum = jsonLocation.GetProperty("residents").EnumerateArray().Count(),
                        Characters = new List<Character>()
                    };
                    locations.Add(location);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            page++;
        }

        return locations;
    }

    public async void Update(Location item)
    {
        try
        {
            var response = await apiClientService.PutJsonAsync($"https://rickandmortyapi.com/api/location/{item.Id}", item);
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
