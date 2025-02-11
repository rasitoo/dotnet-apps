using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Rest;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Services.Services;

internal class LocationService(IRestClient<Location> LocationClient) : IService<Location>
{
    public int Total
    {
        get => LocationClient.Total;
        set => LocationClient.Total = value;
    }
    public int TotalPages
    {
        get => LocationClient.Total;
        set => LocationClient.Total = value;
    }
    public void Add(Location objeto)
    {
        LocationClient.Add(objeto);
    }
    public void Delete(Location item)
    {
        LocationClient.Delete(item);
    }
    public Task<Location?> Get(int id = 1, int subItemsPage = 0, double subItemsPerPage = 0)
    {
        return LocationClient.Get(id, subItemsPage, subItemsPerPage);
    }
    public Task<List<Location>> GetAll(int page)
    {
        return LocationClient.GetAll(page);
    }
    public void Update(Location objeto)
    {
        LocationClient.Update(objeto);
    }
}