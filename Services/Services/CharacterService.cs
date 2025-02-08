using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Rest;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Services.Services;

internal class CharacterService(IRestClient<Character> CharacterRepository) : IRepositoryService<Character>
{
    public void Add(Character objeto)
    {
        CharacterRepository.Add(objeto);
    }
    public void Delete(Character item)
    {
        CharacterRepository.Delete(item);
    }
    public Task<Character?> Get(int id)
    {
        return CharacterRepository.Get(id);
    }
    public Task<List<Character>> GetAll()
    {
        return CharacterRepository.GetAll();
    }
    public void Update(Character objeto)
    {
        CharacterRepository.Update(objeto);
    }
}