using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Rest;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Services.Services;

internal class LocationService(IRestClient<Location> LocationRepository) : IRepositoryService<Location>
{
    public void Add(Location objeto)
    {
        LocationRepository.Add(objeto);
    }
    public void Delete(Location item)
    {
        LocationRepository.Delete(item);
    }
    public Location? Get(int id)
    {
        return LocationRepository.Get(id);
    }
    public Task<List<Location>> GetAll()
    {
        return LocationRepository.GetAll();
    }
    public void Update(Location objeto)
    {
        LocationRepository.Update(objeto);
    }
}