using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Rest;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Services;

public class ServiceArtist(IRestClient<Artist> restClient) : IService<Artist>
{
    public int Offset { get => restClient.Offset; set => restClient.Offset = value; }
    public int Limit { get => restClient.Limit; set => restClient.Limit = value; }

    public void Add(Artist item)
    {
        restClient.Add(item);
    }

    public void Delete(Artist item)
    {
        restClient.Delete(item);
    }

    public Task<Artist?> Get(int id)
    {
        return restClient.Get(id);
    }

    public Task<List<Artist>> GetAll(int offset = 0, int Limit = 100)
    {
        return restClient.GetAll();
    }

    public void Update(Artist item)
    {
        restClient.Update(item);
    }
}
