using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using System.Diagnostics;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Rest;

public class RestClientSong(ApiClientService apiClientService) : IRestClient<Song>
{
    public int Offset { get; set; } = 0;
    public int Limit { get; set; } = 100;

    public async void Add(Song item)
    {
        try
        {
            var response = await apiClientService.PostJsonAsync("/songs/", item);
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

    public async void Delete(Song item)
    {
        try
        {
            var response = await apiClientService.DeleteAsync($"/songs/{item.Id}");
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

    public async Task<Song?> Get(int id)
    {
        try
        {
            var response = await apiClientService.GetJsonAsync($"/songs/{id}");
            if (response != null)
            {
                var jsonSong = response.RootElement;
                return new Song
                {
                    Id = jsonSong.GetProperty("id").GetInt32(),
                    Title = jsonSong.GetProperty("title").GetString(),
                    Publisher = jsonSong.GetProperty("publisher").GetString(),
                    Year = jsonSong.GetProperty("year").GetInt32(),
                    Track_num = jsonSong.GetProperty("track_num").GetInt32(),
                    File = jsonSong.GetProperty("file").GetString(),
                    Album_id = jsonSong.GetProperty("album_id").GetInt32(),
                    Genre_id = jsonSong.GetProperty("genre_id").GetInt32(),
                    Album = new Album
                    {
                        Id = jsonSong.GetProperty("album").GetProperty("id").GetInt32(),
                        Title = jsonSong.GetProperty("album").GetProperty("title").GetString(),
                        Year = jsonSong.GetProperty("album").GetProperty("year").GetInt32(),
                        Picture = jsonSong.GetProperty("album").GetProperty("picture").GetString(),
                        Mbid = jsonSong.GetProperty("album").GetProperty("mbid").GetString(),
                        Artist_id = jsonSong.GetProperty("album").GetProperty("artist_id").GetInt32(),
                        Artist = new Artist
                        {
                            Id = jsonSong.GetProperty("album").GetProperty("artist").GetProperty("id").GetInt32(),
                            Name = jsonSong.GetProperty("album").GetProperty("artist").GetProperty("name").GetString(),
                            Mbid = jsonSong.GetProperty("album").GetProperty("artist").GetProperty("mbid").GetString(),
                            Artist_background = jsonSong.GetProperty("album").GetProperty("artist").GetProperty("artist_background").GetString(),
                            Artist_logo = jsonSong.GetProperty("album").GetProperty("artist").GetProperty("artist_logo").GetString(),
                            Artist_thumbnail = jsonSong.GetProperty("album").GetProperty("artist").GetProperty("artist_thumbnail").GetString(),
                            Artist_banner = jsonSong.GetProperty("album").GetProperty("artist").GetProperty("artist_banner").GetString()
                        }
                    },
                    Genre = new Genre
                    {
                        Id = jsonSong.GetProperty("genre").GetProperty("id").GetInt32(),
                        Name = jsonSong.GetProperty("genre").GetProperty("name").GetString()
                    },
                    Playlists = new List<Playlist>()
                };
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
        return null;
    }

    public async Task<List<Song>> GetAll(int offset = 0, int limit = 100)
    {
        try
        {
            var response = await apiClientService.GetJsonAsync($"/songs?offset={offset}&limit={limit}");
            if (response != null)
            {
                var jsonSongs = response.RootElement;
                var songs = new List<Song>();
                foreach (var jsonSong in jsonSongs.EnumerateArray())
                {
                    songs.Add(new Song
                    {
                        Id = jsonSong.GetProperty("id").GetInt32(),
                        Title = jsonSong.GetProperty("title").GetString(),
                        Publisher = jsonSong.GetProperty("publisher").GetString(),
                        Year = jsonSong.GetProperty("year").GetInt32(),
                        File = jsonSong.GetProperty("file").GetString(),
                        //File = apiClientService.Url + jsonSong.GetProperty("file").GetString(),
                        Album_id = jsonSong.GetProperty("album_id").GetInt32(),
                        Genre_id = jsonSong.GetProperty("genre_id").GetInt32(),
                        Album = new Album
                        {
                            Id = jsonSong.GetProperty("album").GetProperty("id").GetInt32(),
                            Title = jsonSong.GetProperty("album").GetProperty("title").GetString(),
                            Picture = jsonSong.GetProperty("album").GetProperty("picture").GetString(),
                            Artist_id = jsonSong.GetProperty("album").GetProperty("artist_id").GetInt32(),
                            Artist = new Artist
                            {
                                Id = jsonSong.GetProperty("album").GetProperty("artist").GetProperty("id").GetInt32(),
                                Name = jsonSong.GetProperty("album").GetProperty("artist").GetProperty("name").GetString()
                          
                            }
                        },
                        Genre = new Genre
                        {
                            Id = jsonSong.GetProperty("genre").GetProperty("id").GetInt32(),
                            Name = jsonSong.GetProperty("genre").GetProperty("name").GetString()
                        },
                        Playlists = new List<Playlist>()
                    });
                }
                return songs;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
        return new List<Song>();
    }

    public async void Update(Song item)
    {
        try
        {
            var response = await apiClientService.PutJsonAsync($"/songs/{item.Id}", item);
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
