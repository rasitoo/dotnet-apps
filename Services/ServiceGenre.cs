using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Rest;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Services;

public class ServiceGenre(IRestClient<Genre> restClient) : IService<Genre>
{
    public int Offset { get => restClient.Offset; set => restClient.Offset = value; }
    public int Limit { get => restClient.Limit; set => restClient.Limit = value; }

    public void Add(Genre item)
    {
        restClient.Add(item);
    }

    public void Delete(Genre item)
    {
        restClient.Delete(item);
    }

    public Task<Genre?> Get(int id)
    {
        return restClient.Get(id);
    }

    public Task<List<Genre>> GetAll(int offset = 0, int Limit = 100)
    {
        return restClient.GetAll();
    }

    public void Update(Genre item)
    {
        restClient.Update(item);
    }
}
