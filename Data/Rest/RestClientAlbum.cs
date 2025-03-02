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
        try
        {
            var response = await apiClientService.GetJsonAsync($"albums/{id}");
            if (response != null)
            {
                var jsonAlbum = response.RootElement;
                return new Album
                {
                    Id = jsonAlbum.GetProperty("id").GetInt32(),
                    Mbid = jsonAlbum.GetProperty("mbid").GetString(),
                    Artist_id = jsonAlbum.GetProperty("artist_id").GetInt32(),
                    Title = jsonAlbum.GetProperty("title").GetString(),
                    Year = jsonAlbum.GetProperty("year").GetInt32(),
                    Picture = jsonAlbum.GetProperty("picture").GetString(),
                    Artist = new Artist
                    {
                        Id = jsonAlbum.GetProperty("artist").GetProperty("id").GetInt32(),
                        Name = jsonAlbum.GetProperty("artist").GetProperty("name").GetString(),
                        Mbid = jsonAlbum.GetProperty("artist").GetProperty("mbid").GetString(),
                        Artist_background = jsonAlbum.GetProperty("artist").GetProperty("artist_background").GetString(),
                        Artist_logo = jsonAlbum.GetProperty("artist").GetProperty("artist_logo").GetString(),
                        Artist_thumbnail = jsonAlbum.GetProperty("artist").GetProperty("artist_thumbnail").GetString(),
                        Artist_banner = jsonAlbum.GetProperty("artist").GetProperty("artist_banner").GetString()
                    },
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

    public async Task<List<Album>> GetAll(int offset = 0, int limit = 0)
    {
        try
        {
            var response = await apiClientService.GetJsonAsync($"albums?offset={offset}&limit={limit}");
            if (response != null)
            {
                var jsonAlbums = response.RootElement;
                var albums = new List<Album>();
                foreach (var jsonAlbum in jsonAlbums.EnumerateArray())
                {
                    albums.Add(new Album
                    {
                        Id = jsonAlbum.GetProperty("id").GetInt32(),
                        Mbid = jsonAlbum.GetProperty("mbid").GetString(),
                        Artist_id = jsonAlbum.GetProperty("artist_id").GetInt32(),
                        Title = jsonAlbum.GetProperty("title").GetString(),
                        Year = jsonAlbum.GetProperty("year").GetInt32(),
                        Picture = jsonAlbum.GetProperty("picture").GetString(),
                        Artist = new Artist
                        {
                            Id = jsonAlbum.GetProperty("artist").GetProperty("id").GetInt32(),
                            Name = jsonAlbum.GetProperty("artist").GetProperty("name").GetString(),
                            Mbid = jsonAlbum.GetProperty("artist").GetProperty("mbid").GetString(),
                            Artist_background = jsonAlbum.GetProperty("artist").GetProperty("artist_background").GetString(),
                            Artist_logo = jsonAlbum.GetProperty("artist").GetProperty("artist_logo").GetString(),
                            Artist_thumbnail = jsonAlbum.GetProperty("artist").GetProperty("artist_thumbnail").GetString(),
                            Artist_banner = jsonAlbum.GetProperty("artist").GetProperty("artist_banner").GetString()
                        },
                        Songs = new List<Genre>()
                    });
                }
                return albums;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
        return new List<Album>();
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
