using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Rest;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Services;

public class ServiceAlbum(IRestClient<Album> restClient): IService<Album>
{
    public int Offset { get => restClient.Offset; set => restClient.Offset = value; }
    public int Limit { get => restClient.Limit; set => restClient.Limit = value; }

    public void Add(Album item)
    {
        restClient.Add(item);
    }

    public void Delete(Album item)
    {
        restClient.Delete(item);
    }

    public Task<Album?> Get(int id)
    {
        return restClient.Get(id);
    }

    public Task<List<Album>> GetAll(int offset = 0, int Limit = 100)
    {
        return restClient.GetAll();
    }

    public void Update(Album item)
    {
        restClient.Update(item);
    }
}
