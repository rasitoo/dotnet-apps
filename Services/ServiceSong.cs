using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Rest;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Services;

public class ServiceSong(IRestClient<Song> restClient) : IService<Song>
{
    public int Offset { get => restClient.Offset; set => restClient.Offset = value; }
    public int Limit { get => restClient.Limit; set => restClient.Limit = value; }

    public void Add(Song item)
    {
        restClient.Add(item);
    }

    public void Delete(Song item)
    {
        restClient.Delete(item);
    }

    public Task<Song?> Get(int id)
    {
        return restClient.Get(id);
    }

    public Task<List<Song>> GetAll(int offset = 0, int Limit = 100)
    {
        return restClient.GetAll();
    }

    public void Update(Song item)
    {
        restClient.Update(item);
    }
}
