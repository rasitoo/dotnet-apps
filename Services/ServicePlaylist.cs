using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Rest;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Services;

public class ServicePlaylist(IRestClient<Playlist> restClient) : IService<Playlist>
{
    public int Offset { get => restClient.Offset; set => restClient.Offset = value; }
    public int Limit { get => restClient.Limit; set => restClient.Limit = value; }

    public void Add(Playlist item)
    {
        restClient.Add(item);
    }

    public void Delete(Playlist item)
    {
        restClient.Delete(item);
    }

    public Task<Playlist?> Get(int id)
    {
        return restClient.Get(id);
    }

    public Task<List<Playlist>> GetAll(int offset = 0, int Limit = 100)
    {
        return restClient.GetAll();
    }

    public void Update(Playlist item)
    {
        restClient.Update(item);
    }
}
