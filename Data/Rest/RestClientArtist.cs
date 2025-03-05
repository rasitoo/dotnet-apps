using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using System.Diagnostics;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Rest;

public class RestClientArtist(ApiClientService apiClientService) : IRestClient<Artist>
{
    public int Offset { get; set; } = 0;
    public int Limit { get; set; } = 100;

    public async void Add(Artist item)
    {
        try
        {
            var response = await apiClientService.PostJsonAsync("/artists/", item);
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
            var response = await apiClientService.DeleteAsync($"/artists/{item.Id}");
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
        try
        {
            var response = await apiClientService.GetJsonAsync($"/artists/{id}");
            if (response != null)
            {
                var jsonArtist = response.RootElement;
                return new Artist
                {
                    Id = jsonArtist.GetProperty("id").GetInt32(),
                    Name = jsonArtist.GetProperty("name").GetString(),
                    Mbid = jsonArtist.GetProperty("mbid").GetString(),
                    Artist_background = apiClientService.Url + jsonArtist.GetProperty("artist_background").GetString(),
                    Artist_logo = apiClientService.Url + jsonArtist.GetProperty("artist_logo").GetString(),
                    Artist_thumbnail = apiClientService.Url + jsonArtist.GetProperty("artist_thumbnail").GetString(),
                    Artist_banner = apiClientService.Url + jsonArtist.GetProperty("artist_banner").GetString(),
                    Albums = new List<Album>()
                };
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
        return null;
    }

    public async Task<List<Artist>> GetAll(int offset = 0, int limit = 100)
    {
        try
        {
            var response = await apiClientService.GetJsonAsync($"/artists?offset={offset}&limit={limit}");
            if (response != null)
            {
                var jsonArtists = response.RootElement;
                var artists = new List<Artist>();
                foreach (var jsonArtist in jsonArtists.EnumerateArray())
                {
                    artists.Add(new Artist
                    {
                        Id = jsonArtist.GetProperty("id").GetInt32(),
                        Name = jsonArtist.GetProperty("name").GetString(),
                        Mbid = jsonArtist.GetProperty("mbid").GetString(),
                        Artist_background = apiClientService.Url + jsonArtist.GetProperty("artist_background").GetString(),
                        Artist_logo = apiClientService.Url + jsonArtist.GetProperty("artist_logo").GetString(),
                        Artist_thumbnail = apiClientService.Url + jsonArtist.GetProperty("artist_thumbnail").GetString(),
                        Artist_banner = apiClientService.Url + jsonArtist.GetProperty("artist_banner").GetString(),
                        Albums = new List<Album>()
                    });
                }
                return artists;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
        return new List<Artist>();
    }

    public async void Update(Artist item)
    {
        try
        {
            var response = await apiClientService.PutJsonAsync($"/artists/{item.Id}", item);
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
