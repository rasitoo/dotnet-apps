using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Rest;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Services.Services;

internal class CharacterService(IRestClient<Character> CharacterClient) : IService<Character>
{
    public int Total
    {
        get => CharacterClient.Total;
        set => CharacterClient.Total = value;
    }
    public int TotalPages
    {
        get => CharacterClient.Total;
        set => CharacterClient.Total = value;
    }

    public void Add(Character objeto)
    {
        CharacterClient.Add(objeto);
    }
    public void Delete(Character item)
    {
        CharacterClient.Delete(item);
    }
    public Task<Character?> Get(int id, int subItemsPage = 0, double subItemsPerPage = 0)
    {
        return CharacterClient.Get(id, subItemsPage, subItemsPerPage);
    }
    public Task<List<Character>> GetAll(int page)
    {
        return CharacterClient.GetAll(page);
    }
    public void Update(Character objeto)
    {
        CharacterClient.Update(objeto);
    }
}
